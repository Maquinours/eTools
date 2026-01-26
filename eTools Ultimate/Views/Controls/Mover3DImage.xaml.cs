using eTools_Ultimate.Helpers;
using eTools_Ultimate.Models.Models;
using eTools_Ultimate.Models.Motions;
using eTools_Ultimate.Models.Movers;
using eTools_Ultimate.Resources;
using eTools_Ultimate.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
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
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace eTools_Ultimate.Views.Controls
{
    /// <summary>
    /// Logique d'interaction pour Mover3DImage.xaml
    /// </summary>
    [ObservableObject]
    public partial class Mover3DImage : UserControl
    {
        private readonly D3DImageHost _d3dHost = new();

        private readonly SettingsService _settingsService;
        private readonly IStringLocalizer<Translations> _localizer;
        private readonly ISnackbarService _snackbarService;

        private System.Windows.Point _lastMousePosition;

        [ObservableProperty]
        private Model3DImageError? _error = null;

        public static readonly DependencyProperty MoverProperty = DependencyProperty.Register(
            nameof(Mover),
            typeof(Mover),
            typeof(Mover3DImage),
            new PropertyMetadata(null, OnMoverChanged)
        );

        public static readonly DependencyProperty ReferenceMoverProperty = DependencyProperty.Register(
            nameof(ReferenceMover),
            typeof(Mover),
            typeof(Mover3DImage),
            new PropertyMetadata(null, OnReferenceMoverChanged)
        );

        public static readonly DependencyProperty PlayedMotionProperty = DependencyProperty.Register(
            nameof(PlayedMotion),
            typeof(ModelMotion),
            typeof(Mover3DImage),
            new PropertyMetadata(null, OnPlayedMotionChanged)
        );

        public static readonly DependencyProperty MaterialTexturesProperty = DependencyProperty.Register(
            nameof(MaterialTextures),
            typeof(string[]),
            typeof(Mover3DImage),
            new PropertyMetadata(Array.Empty<string>())
        );

        public Mover? Mover
        {
            get => (Mover)GetValue(MoverProperty);
            set => SetValue(MoverProperty, value);
        }

        public Mover? ReferenceMover
        {
            get => (Mover)GetValue(ReferenceMoverProperty);
            set => SetValue(ReferenceMoverProperty, value);
        }

        public ModelMotion? PlayedMotion
        {
            get => (ModelMotion)GetValue(PlayedMotionProperty);
            set => SetValue(PlayedMotionProperty, value);
        }

        public string[] MaterialTextures
        {
            get => (string[])GetValue(MaterialTexturesProperty);
            set => SetValue(MaterialTexturesProperty, value);
        }

        private Model? Model
        {
            get;
            set
            {
                if (value == field)
                    return;

                if (field is not null)
                    field.PropertyChanged -= OnModelPropertyChanged;
                if (value is not null)
                    value.PropertyChanged += OnModelPropertyChanged;

                field = value;

                LoadModel();
            }
        }

        private Model? ReferenceModel
        {
            get;
            set
            {
                if (value == field)
                    return;

                if (field is not null)
                    field.PropertyChanged -= OnReferenceModelPropertyChanged;
                if (value is not null)
                    value.PropertyChanged += OnReferenceModelPropertyChanged;

                field = value;

                LoadReferenceModel();
            }
        }

        public Mover3DImage()
        {
            _settingsService = App.Services.GetRequiredService<SettingsService>();
            _localizer = App.Services.GetRequiredService<IStringLocalizer<Translations>>();
            _snackbarService = App.Services.GetRequiredService<ISnackbarService>();

            InitializeComponent();
        }

        private static void OnMoverChanged(
        DependencyObject d,
        DependencyPropertyChangedEventArgs e)
        {
            var control = (Mover3DImage)d;
            var oldMover = e.OldValue as Mover;
            var newMover = e.NewValue as Mover;

            control.OnMoverChanged(oldMover, newMover);
        }
        private static void OnReferenceMoverChanged(
        DependencyObject d,
        DependencyPropertyChangedEventArgs e)
        {
            var control = (Mover3DImage)d;
            var oldMover = e.OldValue as Mover;
            var newMover = e.NewValue as Mover;

            control.OnReferenceMoverChanged(oldMover, newMover);
        }

        private static void OnPlayedMotionChanged(
        DependencyObject d,
        DependencyPropertyChangedEventArgs e)
        {
            var control = (Mover3DImage)d;
            var oldMotion = e.OldValue as ModelMotion;
            var newMotion = e.NewValue as ModelMotion;

            control.OnPlayedMotionChanged(oldMotion, newMotion);
        }

        private void OnMoverChanged(Mover? oldMover, Mover? newMover)
        {
            if (Mover != newMover)
                throw new InvalidOperationException("Mover != newMover");

            Model = newMover?.Model;
        }

        private void OnReferenceMoverChanged(Mover? oldMover, Mover? newMover)
        {
            if (ReferenceMover != newMover)
                throw new InvalidOperationException("ReferenceMover != newMover");

            ReferenceModel = newMover?.Model;

            if (ReferenceMover != null && ReferenceModel == null)
            {
                ReferenceMover = null;
                _snackbarService.Show(
                    title: _localizer["Unable to display reference mover"],
                    message: _localizer["This reference mover does not have an model associated."],
                    appearance: ControlAppearance.Caution,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(2)
                    );
            }
        }

        private void OnPlayedMotionChanged(ModelMotion? oldMotion, ModelMotion? newMotion)
        {
            if(PlayedMotion != newMotion)
                throw new InvalidOperationException("PlayedMotion != newMotion");

            if (oldMotion != null)
                oldMotion.PropertyChanged -= OnPlayedMotionPropertyChanged;
            if (newMotion != null) 
                newMotion.PropertyChanged += OnPlayedMotionPropertyChanged;

            PlayMotion();
        }

        private void OnModelPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (sender != Model)
                throw new InvalidOperationException("sender != Model");
            if (Model == null)
                throw new InvalidOperationException("Model == null");

            switch (e.PropertyName)
            {
                case nameof(Model.Model3DFilePath):
                    LoadModel();
                    break;
                case nameof(Model.NTextureEx):
                    _d3dHost.SetModelTexture(Model.NTextureEx);
                    break;
                case nameof(Model.FScale):
                    _d3dHost.SetScale(Model.FScale);
                    break;
            }
        }

        private void OnReferenceModelPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (sender != ReferenceModel)
                throw new InvalidOperationException("sender != ReferenceModel");
            if (ReferenceModel == null)
                throw new InvalidOperationException("ReferenceModel == null");

            switch (e.PropertyName)
            {
                case nameof(ReferenceModel.Model3DFilePath):
                    LoadReferenceModel();
                    break;
                case nameof(ReferenceModel.NTextureEx):
                    _d3dHost.SetReferenceModelTexture(ReferenceModel.NTextureEx);
                    break;
                case nameof(ReferenceModel.FScale):
                    _d3dHost.SetReferenceScale(ReferenceModel.FScale);
                    break;
            }
        }

        private void OnPlayedMotionPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (sender != PlayedMotion)
                throw new InvalidOperationException("sender != PlayedMotion");
            if (PlayedMotion == null)
                throw new InvalidOperationException("PlayedMotion == null");

            switch (e.PropertyName)
            {
                case nameof(PlayedMotion.SzMotion):
                    PlayedMotion = null;
                    break;
            }
        }

        private void LoadModel()
        {
            if (!_d3dHost.IsInitialized) return;

            _d3dHost.Clear();

            Error = null;

            if (Mover is null) return;

            if (Model is null)
            {
                Error = new(_localizer["No model associated"], _localizer["No model associated with the selected mover."]);
                //ModelViewerError = localizer["No model associated with the ControlAppearanceselected mover."];
                return;
            }

            if (Mover.Identifier == "MI_MALE" || Mover.Identifier == "MI_FEMALE")
            {
                string[] parts = Mover.Identifier switch
                {
                    "MI_MALE" => [
                        "Part_maleHair06.o3d",
                        "Part_maleHead01.o3d",
                        "Part_maleHand.o3d",
                        "Part_maleLower.o3d",
                        "Part_maleUpper.o3d",
                        "Part_maleFoot.o3d",
                    ],
                    "MI_FEMALE" => [
                        "Part_femaleHair06.o3d",
                        "Part_femaleHead01.o3d",
                        "Part_femaleHand.o3d",
                        "Part_femaleLower.o3d",
                        "Part_femaleUpper.o3d",
                        "Part_femaleFoot.o3d",
                    ],
                    _ => throw new InvalidOperationException($"Mover model is loaded like player but is not player. Identifier => {Mover.Identifier}")
                };
                string modelsFolderPath = _settingsService.Settings.ModelsFolderPath ?? _settingsService.Settings.DefaultModelsFolderPath;
                string[] partsPath = [.. parts.Select(part => $"{modelsFolderPath}{part}")];

                if (!partsPath.All(File.Exists))
                {
                    Error = new(_localizer["Model file not found"], String.Format(_localizer["File {0} not found."], partsPath));
                    //ModelViewerError = String.Format(localizer["Unable to find file: {0}"], partPath);
                    return;
                }

                foreach (string partPath in partsPath)
                    _d3dHost.SetParts(partPath);
            }
            else
            {
                if (!File.Exists(Model.Model3DFilePath))
                {
                    Error = new(_localizer["Model file not found"], String.Format(_localizer["File {0} not found."], Model.Model3DFilePath));
                    //ModelViewerError = String.Format(localizer["Unable to find file: {0}"], mover.Model.Model3DFilePath);
                    return;
                }
                //CompositionTarget.Rendering -= CompositionTarget_Rendering;
                _d3dHost.LoadModel(Model.Model3DFilePath);
            }

            _d3dHost.SetModelTexture(Model.NTextureEx);
            _d3dHost.SetScale(Model.FScale);
            PlayMotion();

            MaterialTextures = _d3dHost.GetMaterialTextures();
        }

        public void LoadReferenceModel()
        {
            if (!_d3dHost.IsInitialized) return;

            _d3dHost.DeleteReferenceModel();

            if (ReferenceMover is null) return;
            if (ReferenceModel is null) return;
            if (ReferenceMover.Model != ReferenceModel)
                throw new InvalidOperationException("ReferenceMover.Model != ReferenceModel");

            if (ReferenceMover.Identifier == "MI_MALE" || ReferenceMover.Identifier == "MI_FEMALE")
            {
                string[] parts = ReferenceMover.Identifier switch
                {
                    "MI_MALE" => [
                        "Part_maleHair06.o3d",
                            "Part_maleHead01.o3d",
                            "Part_maleHand.o3d",
                            "Part_maleLower.o3d",
                            "Part_maleUpper.o3d",
                            "Part_maleFoot.o3d",
                    ],
                    "MI_FEMALE" => [
                        "Part_femaleHair06.o3d",
                            "Part_femaleHead01.o3d",
                            "Part_femaleHand.o3d",
                            "Part_femaleLower.o3d",
                            "Part_femaleUpper.o3d",
                            "Part_femaleFoot.o3d",
                    ],
                    _ => throw new InvalidOperationException($"MoverViewModel::ShowReferenceModelContentDialog exception : mover model is loaded like player but is not player. Identifier => {ReferenceMover.Identifier}")
                };
                string modelsFolderPath = _settingsService.Settings.ModelsFolderPath ?? _settingsService.Settings.DefaultModelsFolderPath;
                string[] partsPath = [.. parts.Select(part => $"{modelsFolderPath}{part}")];

                if (!partsPath.All(File.Exists))
                {
                    _snackbarService.Show(
                    title: _localizer["Unable to display reference mover"],
                    message: String.Format(_localizer["Model file {0} could not be found."], partsPath),
                    appearance: ControlAppearance.Danger,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(2)
                    );
                    //ModelViewerError = String.Format(localizer["Unable to find file: {0}"], partPath);
                    return;
                }

                foreach (string partPath in partsPath)
                    _d3dHost.SetReferenceParts(partPath);
            }
            else
            {
                if (!File.Exists(ReferenceModel.Model3DFilePath))
                {
                    _snackbarService.Show(
                    title: _localizer["Unable to display reference mover"],
                    message: String.Format(_localizer["Model file {0} could not be found."], ReferenceModel.Model3DFilePath),
                    appearance: ControlAppearance.Danger,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(2)
                    );
                    //ModelViewerError = $"Model file not found: {referenceMover.Model.Model3DFilePath}";
                    return;
                }
                _d3dHost.SetReferenceModel(ReferenceModel.Model3DFilePath);
            }

            _d3dHost.SetReferenceModelTexture(ReferenceModel.NTextureEx);
            _d3dHost.SetReferenceScale(ReferenceModel.FScale);
        }

        private void PlayMotion()
        {
            _d3dHost.StopMotion();

            if (PlayedMotion != null)
            {
                if (Model == null || !Model.Motions.Contains(PlayedMotion))
                    throw new InvalidOperationException("Model.Motions does not contains PlayedMotion");

                string modelsFolderPath = _settingsService.Settings.ModelsFolderPath ?? _settingsService.Settings.DefaultModelsFolderPath;
                string root = Path.GetFileNameWithoutExtension(Model.Model3DFilePath);
                string lowerMotionKey = PlayedMotion.SzMotion;

                string motionFilePath = Path.Combine(modelsFolderPath, $"{root}_{lowerMotionKey}.ani");

                if (!File.Exists(motionFilePath))
                {
                    _snackbarService.Show(
                    title: _localizer["Unable to play motion"],
                    message: String.Format(_localizer["Motion file {0} could not be found."], motionFilePath),
                    appearance: ControlAppearance.Danger,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(2)
                    );
                }

                _d3dHost.PlayMotion(motionFilePath);
            }
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
    }

    public record Model3DImageError(string Title, string Description);
}
