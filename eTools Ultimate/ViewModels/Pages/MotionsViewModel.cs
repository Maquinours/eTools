using eTools_Ultimate.Helpers;
using eTools_Ultimate.Models;
using eTools_Ultimate.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using Wpf.Ui;
using Wpf.Ui.Abstractions.Controls;
using Wpf.Ui.Controls;

namespace eTools_Ultimate.ViewModels.Pages
{
    public partial class MotionsViewModel(ISnackbarService snackbarService) : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;

        private string _searchText = string.Empty;

        [ObservableProperty]
        private ICollectionView _motionsView = CollectionViewSource.GetDefaultView(MotionsService.Instance.Motions);

        public List<KeyValuePair<int, string>> MotionIdentifiers => [.. DefinesService.Instance.ReversedMotionDefines];

        public D3DImageHost? D3dHost { get; private set; } = null;

        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged(nameof(this.SearchText));
                    MotionsView.Refresh();
                }
            }
        }

        public Task OnNavigatedToAsync()
        {
            if (!_isInitialized)
                InitializeViewModel();

            return Task.CompletedTask;
        }

        public Task OnNavigatedFromAsync() => Task.CompletedTask;

        private void InitializeViewModel()
        {
            MotionsView.Filter = new Predicate<object>(FilterItem);

            _isInitialized = true;
        }

        public D3DImageHost InitializeD3DHost(nint hwnd)
        {
            D3dHost = new D3DImageHost(hwnd);
            D3dHost.Initialize(hwnd);
            D3dHost.BindBackBuffer();

            CompositionTarget.Rendering += CompositionTarget_Rendering;
            MotionsView.CurrentChanging += MotionsView_CurrentChanging;
            MotionsView.CurrentChanged += MotionsView_CurrentChanged;

            LoadModel();
            PlayMotion();

            SetupCurrentMotionWatchers();

            return D3dHost;
        }

        private void CompositionTarget_Rendering(object? sender, EventArgs e)
        {
            D3dHost?.Render();
        }

        private void MotionsView_CurrentChanging(object sender, CurrentChangingEventArgs e)
        {
            TeardownCurrentMotionWatchers();
        }

        private void MotionsView_CurrentChanged(object? sender, EventArgs e)
        {
            PlayMotion();
            SetupCurrentMotionWatchers();
        }

        private void SetupCurrentMotionWatchers()
        {
            if (MotionsView.CurrentItem is not Motion motion) return;

            motion.Prop.PropertyChanged += MotionProp_PropertyChanged;
        }

        private void TeardownCurrentMotionWatchers()
        {
            if (MotionsView.CurrentItem is not Motion motion) return;
            motion.Prop.PropertyChanged -= MotionProp_PropertyChanged;
        }

        private void MotionProp_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(MotionProp.DwMotion):
                case nameof(MotionProp.DwPlay):
                    PlayMotion();
                    break;
            }
        }

        private void LoadModel()
        {
            if (D3dHost is null) return;

            string[] parts = [
                        "Part_maleHair06.o3d",
                        "Part_maleHead01.o3d",
                        "Part_maleHand.o3d",
                        "Part_maleLower.o3d",
                        "Part_maleUpper.o3d",
                        "Part_maleFoot.o3d",
                    ];
            string modelsFolderPath = Settings.Instance.ModelsFolderPath ?? Settings.Instance.DefaultModelsFolderPath;
            string[] partsPath = [.. parts.Select(part => $"{modelsFolderPath}{part}")];

            foreach (string partPath in partsPath)
            {
                NativeMethods.SetParts(D3dHost._native, partPath);
            }
        }

        private void PlayMotion()
        {
            if (D3dHost is null) return;
            if (MotionsView.CurrentItem is not Motion motion) return;

            string modelsFolderPath = Settings.Instance.ModelsFolderPath ?? Settings.Instance.DefaultModelsFolderPath;
            string root = "mvr_male";
            int motionType = motion.Prop.DwMotion;

            int moverModelType = DefinesService.Instance.Defines["OT_MOVER"];
            int maleMoverId = DefinesService.Instance.Defines["MI_MALE"];
            ModelElem? moverModel = ModelsService.Instance.GetModelByTypeAndId(moverModelType, maleMoverId);
            if (moverModel is null) return;
            ModelMotion? modelMotion = moverModel?.Motions.FirstOrDefault(m => m.IMotion == motionType);
            if (modelMotion is null) return;

            string lowerMotionKey = modelMotion.SzMotion;

            string motionFile = $@"{modelsFolderPath}{root}_{lowerMotionKey}.ani";

            //if (!File.Exists(motionFile))
            //{
            //    snackbarService.Show(
            //    title: "Unable to play motion",
            //    message: $"Motion file not found : {motionFile}",
            //    appearance: ControlAppearance.Danger,
            //    icon: null,
            //    timeout: TimeSpan.FromSeconds(3)
            //    );
            //    //ModelViewerError = $"Motion file not found: {motionFile}";
            //    return;
            //}

            NativeMethods.PlayMotion(D3dHost._native, motionFile, motion.Prop.DwPlay);

            //Auto3DRendering = true;
        }

        private bool FilterItem(object obj)
        {
            if (obj is not Motion motion) return false;
            if (string.IsNullOrEmpty(this.SearchText)) return true;
            return motion.Name.ToLower().Contains(this.SearchText.ToLower());
        }

        [RelayCommand]
        private void Save()
        {
            HashSet<string> stringIdentifiers = [];
            foreach (Motion motion in MotionsService.Instance.Motions)
            {
                stringIdentifiers.Add(motion.Prop.SzName);
                stringIdentifiers.Add(motion.Prop.SzDesc);
            }

            try
            {
                MotionsService.Instance.Save();
                StringsService.Instance.Save(Settings.Instance.MotionsTxtFilePath ?? Settings.Instance.DefaultMotionsTxtFilePath, [.. stringIdentifiers]);

                snackbarService.Show(
                    title: "Motions saved",
                    message: "Motions have been successfully saved.",
                    appearance: ControlAppearance.Success,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(3)
                    );
            } catch(Exception ex)
            {
                snackbarService.Show(
                    title: "An error has occured while saving",
                    message: ex.Message,
                    appearance: ControlAppearance.Danger,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(3)
                    );
            }
        }
    }
}
