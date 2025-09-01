using eTools_Ultimate.Helpers;
using eTools_Ultimate.Models;
using eTools_Ultimate.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using Wpf.Ui;
using Wpf.Ui.Abstractions.Controls;
using Wpf.Ui.Controls;
using Wpf.Ui.Extensions;

namespace eTools_Ultimate.ViewModels.Pages
{
    enum ModelGender
    {
        MALE,
        FEMALE
    }

    public partial class MotionsViewModel(ISnackbarService snackbarService, IContentDialogService contentDialogService) : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;

        private string _searchText = string.Empty;

        private ModelGender _modelPreviewGender = ModelGender.MALE;

        private ModelGender ModelPreviewGender
        {
            get => _modelPreviewGender;
            set
            {
                if (_modelPreviewGender != value)
                {
                    _modelPreviewGender = value;
                    OnPropertyChanged(nameof(ModelPreviewGender));
                    LoadModel();
                    PlayMotion();
                }
            }
        }

        [ObservableProperty]
        private ICollectionView _motionsView = CollectionViewSource.GetDefaultView(MotionsService.Instance.Motions);

        public List<KeyValuePair<int, string>> MotionIdentifiers => [.. DefinesService.Instance.ReversedMotionDefines];
        public string[] AnimationIdentifiers // TODO : we need to throw a "property changed" event when male or female model motion changes, but not a priority.
        {
            get
            {
                int moverModelType = DefinesService.Instance.Defines["OT_MOVER"];
                int maleMoverId = DefinesService.Instance.Defines["MI_MALE"];
                int femaleMoverId = DefinesService.Instance.Defines["MI_FEMALE"];
                ModelElem? maleMoverModel = ModelsService.Instance.GetModelByTypeAndId(moverModelType, maleMoverId);
                ModelElem? femaleMoverModel = ModelsService.Instance.GetModelByTypeAndId(moverModelType, maleMoverId);
                if (maleMoverModel is null || femaleMoverModel is null) return [];
                ModelMotion[] maleMotions = [.. maleMoverModel.Motions];
                ModelMotion[] femaleMotions = [.. femaleMoverModel.Motions];

                ModelMotion[] common = [.. maleMotions.Where(m => femaleMotions.Any(f => f.IMotion == m.IMotion))];

                string[] commonIdentifiers = [.. common.Select(x => DefinesService.Instance.ReversedMotionTypeDefines[x.IMotion])];

                return commonIdentifiers;
            }
        }

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

            NativeMethods.DeleteModel(D3dHost._native);
            string[] parts = ModelPreviewGender switch
            {
                ModelGender.MALE => [
                    "Part_maleHair06.o3d",
                        "Part_maleHead01.o3d",
                        "Part_maleHand.o3d",
                        "Part_maleLower.o3d",
                        "Part_maleUpper.o3d",
                        "Part_maleFoot.o3d",
                    ],
                ModelGender.FEMALE => [
                    "Part_femaleHair06.o3d",
                        "Part_femaleHead01.o3d",
                        "Part_femaleHand.o3d",
                        "Part_femaleLower.o3d",
                        "Part_femaleUpper.o3d",
                        "Part_femaleFoot.o3d",
                    ],
                _ => throw new InvalidOperationException("MotionsViewModel::LoadModel exception : ModelPreviewGender is neither MALE nor FEMALE")
            };

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

            NativeMethods.StopMotion(D3dHost._native);

            int motionType = motion.Prop.DwMotion;

            string moverIdentifier = ModelPreviewGender switch
            {
                ModelGender.MALE => "MI_MALE",
                ModelGender.FEMALE => "MI_FEMALE",
                _ => throw new InvalidOperationException("MotionsViewModel::PlayMotion exception : ModelPreviewGender is neither MALE nor FEMALE")
            };

            int moverModelType = DefinesService.Instance.Defines["OT_MOVER"];
            int moverId = DefinesService.Instance.Defines[moverIdentifier];
            ModelElem? moverModel = ModelsService.Instance.GetModelByTypeAndId(moverModelType, moverId);
            if (moverModel is null) return;
            ModelMotion? modelMotion = moverModel.Motions.FirstOrDefault(m => m.IMotion == motionType);
            if (modelMotion is null) return;

            string modelsFolderPath = Settings.Instance.ModelsFolderPath ?? Settings.Instance.DefaultModelsFolderPath;
            string root = $"mvr_{moverModel.SzName}";
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
        private async Task Save()
        {
            try
            {
                await Task.Run(() =>
                {
                    HashSet<string> stringIdentifiers = [];
                    foreach (Motion motion in MotionsService.Instance.Motions)
                    {
                        stringIdentifiers.Add(motion.Prop.SzName);
                        stringIdentifiers.Add(motion.Prop.SzDesc);
                    }

                    MotionsService.Instance.Save();
                    StringsService.Instance.Save(Settings.Instance.MotionsTxtFilePath ?? Settings.Instance.DefaultMotionsTxtFilePath, [.. stringIdentifiers]);
                });

                snackbarService.Show(
                    title: "Motions saved",
                    message: "Motions have been successfully saved.",
                    appearance: ControlAppearance.Success,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(3)
                    );
            }
            catch (Exception ex)
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

        [RelayCommand]
        private void ChangeModelPreviewGender()
        {
            ModelPreviewGender = ModelPreviewGender switch
            {
                ModelGender.MALE => ModelGender.FEMALE,
                ModelGender.FEMALE => ModelGender.MALE,
                _ => throw new InvalidOperationException("MotionsViewModel::ChangeModelPreviewGender exception : ModelPreviewGender is neither MALE nor FEMALE")
            };
        }

        [RelayCommand]
        private void PlayModelPreviewMotion()
        {
            PlayMotion();
        }

        [RelayCommand]
        private void Add()
        {
            Settings settings = Settings.Instance;

            string szName = StringsService.Instance.GetNextStringIdentifier("IDS_PROPMOTION_TXT_");
            StringsService.Instance.AddString(szName, "");
            string szDesc = StringsService.Instance.GetNextStringIdentifier("IDS_PROPMOTION_TXT_");
            StringsService.Instance.AddString(szDesc, "");

            MotionProp prop = new(nVer: Settings.Instance.ResourcesVersion, dwId: -1, dwMotion: 0, szIconName: "", dwPlay: 0, szName: szName, szDesc: szDesc);
            Motion motion = new(prop);
            MotionsService.Instance.Motions.Add(motion);
            MotionsView.Refresh();
            MotionsView.MoveCurrentTo(motion);
        }

        [RelayCommand]
        private async Task Delete()
        {
            if (MotionsView.CurrentItem is not Motion motion) return;

            ContentDialogResult result = await contentDialogService.ShowSimpleDialogAsync(
                new SimpleContentDialogCreateOptions()
                {
                    Title = "Delete a motion",
                    Content = $"Are you sure you want to delete the motion {motion.Identifier} ?",
                    PrimaryButtonText = "Delete",
                    CloseButtonText = "Cancel",
                }
            );
            if (result == ContentDialogResult.Primary)
            {
                MotionsService.Instance.Motions.Remove(motion);
                motion.Dispose();
                MotionsView.Refresh();
            }
        }

        [RelayCommand]
        private void SelectIconFile()
        {
            if (MotionsView.CurrentItem is not Motion motion) return;

            string? filePath = FileFolderSelector.SelectFile(motion.IconFilePath, "Select an icon file", "DDS image|*.dds");

            string? initialDirectoryPath = Path.GetDirectoryName(motion.IconFilePath);
            string? directoryPath = Path.GetDirectoryName(filePath);
            string? fileExtension = Path.GetExtension(filePath);
            string? fileName = Path.GetFileName(filePath);

            if (filePath is null ||
                directoryPath is null ||
                fileExtension is null ||
                fileName is null ||
                !directoryPath.Equals(initialDirectoryPath, StringComparison.OrdinalIgnoreCase) ||
                !fileExtension.Equals(".dds"))
                return;

            motion.Prop.SzIconName = fileName;
        }
    }
}
