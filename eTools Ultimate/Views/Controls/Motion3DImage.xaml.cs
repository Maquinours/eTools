using eTools_Ultimate.Helpers;
using eTools_Ultimate.Models;
using eTools_Ultimate.Models.Models;
using eTools_Ultimate.Models.Motions;
using eTools_Ultimate.Models.Movers;
using eTools_Ultimate.Resources;
using eTools_Ultimate.Services;
using eTools_Ultimate.ViewModels.Pages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Ui;
using Wpf.Ui.Controls;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace eTools_Ultimate.Views.Controls
{
    /// <summary>
    /// Logique d'interaction pour Motion3DImage.xaml
    /// </summary>
    [ObservableObject]
    public partial class Motion3DImage : UserControl
    {
        private readonly ISnackbarService _snackbarService = App.Services.GetRequiredService<ISnackbarService>();
        private readonly IStringLocalizer<Translations> _localizer = App.Services.GetRequiredService<IStringLocalizer<Translations>>();
        private readonly SettingsService _settingsService = App.Services.GetRequiredService<SettingsService>();
        private readonly DefinesService _definesService = App.Services.GetRequiredService<DefinesService>();
        private readonly ModelsService _modelsService = App.Services.GetRequiredService<ModelsService>();

        private readonly D3DImageHost _d3dHost = new();

        private System.Windows.Point _lastMousePosition;

        [ObservableProperty]
        private Model3DImageError? _error = null;

        [ObservableProperty]
        private Gender _modelGender = Gender.Male;

        public static readonly DependencyProperty MotionProperty = DependencyProperty.Register(
            nameof(Motion),
            typeof(Motion),
            typeof(Motion3DImage),
            new PropertyMetadata(null, OnMotionChanged)
        );

        public Motion Motion
        {
            get => (Motion)GetValue(MotionProperty);
            set => SetValue(MotionProperty, value);
        }

        public Motion3DImage()
        {
            InitializeComponent();
        }

        private void LoadModel()
        {
            if (!_d3dHost.IsInitialized) return;

            _d3dHost.Clear();

            string[] parts = ModelGender switch
            {
                Gender.Male => [
                    "Part_maleHair06.o3d",
                        "Part_maleHead01.o3d",
                        "Part_maleHand.o3d",
                        "Part_maleLower.o3d",
                        "Part_maleUpper.o3d",
                        "Part_maleFoot.o3d",
                    ],
                Gender.Female => [
                    "Part_femaleHair06.o3d",
                        "Part_femaleHead01.o3d",
                        "Part_femaleHand.o3d",
                        "Part_femaleLower.o3d",
                        "Part_femaleUpper.o3d",
                        "Part_femaleFoot.o3d",
                    ],
                _ => throw new InvalidOperationException("LoadModel exception : ModelPreviewGender is neither MALE nor FEMALE")
            };

            string modelsFolderPath = _settingsService.Settings.ModelsFolderPath ?? _settingsService.Settings.DefaultModelsFolderPath;
            string[] partsPath = [.. parts.Select(part => $"{modelsFolderPath}{part}")];

            foreach (string partPath in partsPath)
                _d3dHost.SetParts(partPath);

            _d3dHost.Zoom(720);

            PlayMotion();
        }

        private void PlayMotion()
        {
            if (!_d3dHost.IsInitialized) return;

            _d3dHost.StopMotion();

            if (Motion == null) return;

            string moverIdentifier = ModelGender switch
            {
                Gender.Male => "MI_MALE",
                Gender.Female => "MI_FEMALE",
                _ => throw new InvalidOperationException("ModelGender is neither Male nor Female")
            };

            int moverModelType = _definesService.Defines["OT_MOVER"];

            if (!_definesService.Defines.TryGetValue(moverIdentifier, out int moverId))
            {
                _snackbarService.Show(
               title: _localizer["Unable to play motion"],
               message: string.Format(_localizer["No mover found with ID {0}."], moverIdentifier),
               appearance: ControlAppearance.Danger,
               icon: null,
               timeout: TimeSpan.FromSeconds(3)
              
               );
                return;
            }

            Model? moverModel = _modelsService.GetModelByTypeAndId(moverModelType, (uint)moverId);

            if (moverModel is null)
            {
                _snackbarService.Show(
                title: _localizer["Unable to play motion"],
                message: string.Format(_localizer["Mover {0} has no model associated."], moverIdentifier),
                appearance: ControlAppearance.Danger,
                icon: null,
                timeout: TimeSpan.FromSeconds(3)
                );
                return;
            }

            ModelMotion? modelMotion = moverModel.Motions.FirstOrDefault(m => m.IMotion == Motion.DwMotion);

            if (modelMotion is null)
            {
                _snackbarService.Show(
                title: _localizer["Unable to play motion"],
                message: string.Format(_localizer["Mover model {0} has no {1} motion assigned."], moverIdentifier, Motion.MotionIdentifier),
                appearance: ControlAppearance.Danger,
                icon: null,
                timeout: TimeSpan.FromSeconds(3)
                );
                return;
            }

            string modelsFolderPath = _settingsService.Settings.ModelsFolderPath ?? _settingsService.Settings.DefaultModelsFolderPath;
            string root = $"mvr_{moverModel.SzName}";
            string lowerMotionKey = modelMotion.SzMotion;

            string motionFile = $@"{modelsFolderPath}{root}_{lowerMotionKey}.ani";

            if (!File.Exists(motionFile))
            {
                _snackbarService.Show(
                title: _localizer["Unable to play motion"],
                message: string.Format(_localizer["Motion file not found : {0}"], motionFile),
                appearance: ControlAppearance.Danger,
                icon: null,
                timeout: TimeSpan.FromSeconds(3)
                );
                return;
            }

            _d3dHost.PlayMotion(motionFile, (int)Motion.DwPlay);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (!_d3dHost.IsInitialized)
            {
                var window = Window.GetWindow(this);
                if (window == null)
                    return;

                nint hwnd = new WindowInteropHelper(window).Handle;

                _d3dHost.Initialize(hwnd);
                _d3dHost.BindBackBuffer();
                DxImage.Source = _d3dHost;
                LoadModel();
                CompositionTarget.Rendering += CompositionTarget_Rendering;
            }
        }

        private void CompositionTarget_Rendering(object? sender, EventArgs e)
        {
            _d3dHost.Render();
        }

        partial void OnModelGenderChanged(Gender value)
        {
            LoadModel();
        }

        private void DxImage_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var window = Window.GetWindow((DependencyObject)sender);
            var posInWindow = e.GetPosition(window);

            _lastMousePosition = window.PointToScreen(posInWindow);

            Mouse.Capture(this);

            MouseMove += OnMouseMove;
            MouseRightButtonUp += OnMouseRightButtonUp;
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            var window = Window.GetWindow((DependencyObject)sender);
            var posInWindow = e.GetPosition(window);
            var mousePosition = window.PointToScreen(posInWindow);

            Vector deltaPosition = _lastMousePosition - mousePosition;

            _lastMousePosition = mousePosition;

            _d3dHost.RotateCamera((int)deltaPosition.X, (int)deltaPosition.Y);
        }

        private void OnMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            MouseMove -= OnMouseMove;
            MouseRightButtonUp -= OnMouseRightButtonUp;

            Mouse.Capture(null);
        }

        private void DxImage_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            _d3dHost.Zoom(e.Delta);
            e.Handled = true;
        }

        private static void OnMotionChanged(
        DependencyObject d,
        DependencyPropertyChangedEventArgs e)
        {
            var control = (Motion3DImage)d;
            var oldMotion = e.OldValue as Motion;
            var newMotion = e.NewValue as Motion;

            control.OnMotionChanged(oldMotion, newMotion);
        }

        private void OnMotionChanged(Motion? oldMotion, Motion? newMotion)
        {
            if (Motion != newMotion)
                throw new InvalidOperationException("PlayedMotion != newMotion");

            oldMotion?.PropertyChanged -= Motion_PropertyChanged;
            newMotion?.PropertyChanged += Motion_PropertyChanged;

            PlayMotion();
        }

        private void Motion_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (sender != Motion)
                throw new InvalidOperationException("sender != Motion");

            switch (e.PropertyName)
            {
                case nameof(Motion.DwMotion):
                case nameof(Motion.DwPlay):
                    PlayMotion();
                    break;
            }
        }

        [RelayCommand]
        private void ChangeModelGender()
        {
            ModelGender = ModelGender switch
            {
                Gender.Male => Gender.Female,
                Gender.Female => Gender.Male,
                _ => throw new InvalidOperationException("ModelGender is neither Male nor Female")
            };
        }

        [RelayCommand]
        private void PlayCurrentMotion()
        {
            PlayMotion();
        }
    }
}
