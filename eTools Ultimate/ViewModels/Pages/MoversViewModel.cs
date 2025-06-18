using eTools_Ultimate.Helpers;
using eTools_Ultimate.Models;
using eTools_Ultimate.Services;
using eTools_Ultimate.ViewModels.Controls.Dialogs;
using eTools_Ultimate.Views.Dialogs;
using Notification.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.TextFormatting;
using Wpf.Ui;
using Wpf.Ui.Abstractions.Controls;
using Wpf.Ui.Controls;
using Wpf.Ui.Extensions;

namespace eTools_Ultimate.ViewModels.Pages
{
    public partial class MoversViewModel(IContentDialogService contentDialogService) : ObservableObject, INavigationAware
    {
        #region Properties
        private bool _isInitialized = false;

        public D3DImageHost? D3dHost { get; private set; } = null;

        [ObservableProperty]
        private bool _auto3DRendering = false;

        [ObservableProperty]
        private ICollectionView _moversView = CollectionViewSource.GetDefaultView(MoversService.Instance.Movers);

        private string _searchText = string.Empty;

        private string[] _object3DMaterialTextures = [];

        private string? _modelViewerError = null;

        #region File system watchers
        private FileSystemWatcher _modelsDirectoryWatcher = new()
        {
            Filter = "mvr_*.o3d",
            NotifyFilter = NotifyFilters.FileName,
            IncludeSubdirectories = false,
            EnableRaisingEvents = false
        };

        private FileSystemWatcher _motionDirectoryWatcher = new()
        {
            NotifyFilter = NotifyFilters.FileName,
            IncludeSubdirectories = false,
            EnableRaisingEvents = false
        };

        private FileSystemWatcher _texturesDirectoryWatcher = new()
        {
            Filter = "*.dds",
            NotifyFilter = NotifyFilters.FileName,
            IncludeSubdirectories = false,
            EnableRaisingEvents = false
        };
        #endregion File system watchers

        #region Filter properties
        [ObservableProperty]
        private bool _showBasicInformationSection = true;
        [ObservableProperty]
        private bool _showStatsSection = true;
        [ObservableProperty]
        private bool _showBattleSection = true;
        [ObservableProperty]
        private bool _showDefensiveStatsSection = true;
        [ObservableProperty]
        private bool _showElementalSection = true;
        [ObservableProperty]
        private bool _showModelSection = true;
        #endregion Filter properties
        #endregion Properties

        #region Fields
        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged(nameof(this.SearchText));
                    MoversView.Refresh();
                }
            }
        }

        public string ModelViewerError
        {
            get => _modelViewerError;
            set
            {
                if (_modelViewerError != value)
                {
                    _modelViewerError = value;
                    OnPropertyChanged(nameof(ModelViewerError));
                    OnPropertyChanged(nameof(HasModelViewerError));
                }
            }
        }

        public bool HasModelViewerError => ModelViewerError is not null;

        public string[] ModelFilePossibilities
        {
            get
            {
                Settings settings = Settings.Instance;
                string modelsFolderPath = settings.ModelsFolderPath ?? settings.DefaultModelsFolderPath;
                if (string.IsNullOrEmpty(modelsFolderPath) || !Directory.Exists(modelsFolderPath))
                    return [];
                return [.. Directory.GetFiles(modelsFolderPath, "mvr_*.o3d", SearchOption.TopDirectoryOnly).Select(x => Path.GetFileNameWithoutExtension(x).Substring(4))];
            }
        }

        public string[] Object3DMaterialTextures 
        {
            get => _object3DMaterialTextures;
            set
            {
                if (_object3DMaterialTextures != value)
                {
                    _object3DMaterialTextures = value;
                    OnPropertyChanged(nameof(Object3DMaterialTextures));
                    OnPropertyChanged(nameof(ModelTexturesPossibilities));
                }
            }
        }

        public int[] ModelTexturesPossibilities
        {
            get
            {
                Settings settings = Settings.Instance;
                string texturesFolderPath = settings.TexturesFolderPath ?? settings.DefaultTexturesFolderPath;

                if (string.IsNullOrEmpty(texturesFolderPath) || !Directory.Exists(texturesFolderPath))
                    return [];

                List<int> availableAdditionalTextures = [];
                if (Object3DMaterialTextures.Length > 0)
                {
                    string textureFile = Object3DMaterialTextures[0];
                    var pattern = $"{textureFile}-et??.dds";
                    string[] files = [.. Directory.GetFiles(texturesFolderPath, pattern, SearchOption.TopDirectoryOnly).Select(x => Path.GetFileNameWithoutExtension(x))];
                    foreach (string file in files)
                    {
                        string fileName = file;
                        if (int.TryParse(fileName.AsSpan(fileName.Length - 2), out int index))
                            availableAdditionalTextures.Add(index);
                    }
                    for (int i = availableAdditionalTextures.Count - 1; i >= 0; i--)
                    {
                        int textureIndex = availableAdditionalTextures[i];
                        foreach (string materialTextureFile in Object3DMaterialTextures)
                        {
                            if (!File.Exists($"{texturesFolderPath}{materialTextureFile}-et{textureIndex:D2}.dds"))
                            {
                                availableAdditionalTextures.Remove(textureIndex);
                                break;
                            }
                        }
                    }
                }

                return [0, .. availableAdditionalTextures];
            }
        }

        public string[] ModelMotionFilePossibilities
        {
            get
            {
                Settings settings = Settings.Instance;
                string modelsFolderPath = settings.ModelsFolderPath ?? settings.DefaultModelsFolderPath;
                if (string.IsNullOrEmpty(modelsFolderPath) || !Directory.Exists(modelsFolderPath))
                    return [];
                if (MoversView.CurrentItem is not Mover mover)
                    return [];
                if (mover.Model is null)
                    return [];
                string root = Path.GetFileNameWithoutExtension(mover.Model.Model3DFilePath);
                return [.. Directory.GetFiles(modelsFolderPath, $"{root}_*.ani", SearchOption.TopDirectoryOnly).Select(x => Path.GetFileNameWithoutExtension(x).Substring($"{root}_".Length))];
            }
        }

        public List<KeyValuePair<int, string>> MoverIdentifiers => DefinesService.Instance.ReversedMoverDefines.ToList();
        public List<KeyValuePair<int, string>> BelligerenceIdentifiers => DefinesService.Instance.ReversedBelligerenceDefines.ToList();
        public List<KeyValuePair<int, string>> AiIdentifiers => DefinesService.Instance.ReversedAiDefines.ToList();
        public List<KeyValuePair<int, string>> MotionIdentifiers => DefinesService.Instance.ReversedMotionTypeDefines.ToList();
        public List<KeyValuePair<int, string>> SoundIdentifiers => DefinesService.Instance.ReversedSoundDefines.ToList();
        #endregion Fields

        public Task OnNavigatedToAsync()
        {
            if (!_isInitialized)
                InitializeViewModel();

            return Task.CompletedTask;
        }

        public Task OnNavigatedFromAsync() => Task.CompletedTask;

        public D3DImageHost InitializeD3DHost(nint hwnd)
        {
            D3dHost = new D3DImageHost(hwnd);
            D3dHost.Initialize(hwnd);
            D3dHost.BindBackBuffer();
            LoadModel();
            return D3dHost;
        }

        private void InitializeViewModel()
        {
            MoversView.Filter = new Predicate<object>(FilterItem);

            Settings.Instance.PropertyChanged += Settings_PropertyChanged;

            this._modelsDirectoryWatcher.Renamed += ModelFile_Changed;
            this._modelsDirectoryWatcher.Created += ModelFile_Changed;
            this._modelsDirectoryWatcher.Deleted += ModelFile_Changed;
            InitializeModelsDirectoryWatcherPath();

            this._motionDirectoryWatcher.Renamed += ModelMotionFile_Changed;
            this._motionDirectoryWatcher.Created += ModelMotionFile_Changed;
            this._motionDirectoryWatcher.Deleted += ModelMotionFile_Changed;
            InitializeMotionsDirectoryWatcherPath();

            this._texturesDirectoryWatcher.Renamed += ModelTextureFile_Changed;
            this._texturesDirectoryWatcher.Created += ModelTextureFile_Changed;
            this._texturesDirectoryWatcher.Deleted += ModelTextureFile_Changed;
            InitializeTexturesDirectoryWatcherPath();

            MoversView.CurrentChanging += CurrentMover_Changing;
            MoversView.CurrentChanged += CurrentMover_Changed;

            if (MoversView.CurrentItem is Mover mover)
            {
                mover.PropertyChanged += CurrentMover_PropertyChanged;
                if (mover.Model is not null)
                    mover.Model.PropertyChanged += CurrentMoverModel_PropertyChanged;
            }

            _isInitialized = true;
        }

        private void InitializeModelsDirectoryWatcherPath()
        {
            this._modelsDirectoryWatcher.EnableRaisingEvents = false;
            this._modelsDirectoryWatcher.Path = Settings.Instance.ModelsFolderPath ?? Settings.Instance.DefaultModelsFolderPath;
            this._modelsDirectoryWatcher.EnableRaisingEvents = true;
        }

        private void InitializeTexturesDirectoryWatcherPath()
        {
            this._texturesDirectoryWatcher.EnableRaisingEvents = false;
            this._texturesDirectoryWatcher.Path = Settings.Instance.TexturesFolderPath ?? Settings.Instance.DefaultTexturesFolderPath;
            this._texturesDirectoryWatcher.EnableRaisingEvents = true;
        }

        private void InitializeMotionsDirectoryWatcherPath()
        {
            this._motionDirectoryWatcher.EnableRaisingEvents = false;
            if (MoversView.CurrentItem is not Mover mover) return;
            if (mover.Model is null) return;
            string? prefix = Path.GetFileNameWithoutExtension(mover.Model.Model3DFilePath);
            if (prefix is null) return;
            this._motionDirectoryWatcher.Path = Settings.Instance.ModelsFolderPath ?? Settings.Instance.DefaultModelsFolderPath;
            this._motionDirectoryWatcher.Filter = $"{prefix}_*.ani";
            this._motionDirectoryWatcher.EnableRaisingEvents = true;
        }

        private bool FilterItem(object obj)
        {
            if (obj is not Mover mover) return false;
            if (string.IsNullOrEmpty(this.SearchText)) return true;
            return mover.Name.ToLower().Contains(this.SearchText.ToLower());
        }

        #region 3D model viewer methods
        private void LoadModel()
        {
            Auto3DRendering = false;
            ModelViewerError = null;
            if (D3dHost is null) return;
            NativeMethods.DeleteModel(D3dHost._native); // Clear the previous model if any
            NativeMethods.DeleteReferenceModel(D3dHost._native); // Clear the reference model if any
            D3dHost.Render();
            if (MoversView.CurrentItem is not Mover mover)
            {
                ModelViewerError = "No mover selected.";
                return;
            }
            if (mover.Model is null)
            {
                ModelViewerError = "No model associated with the selected mover.";
                return;
            }
            if ((DefinesService.Instance.Defines.TryGetValue("MI_MALE", out int maleValue) && mover.Id == maleValue) || (DefinesService.Instance.Defines.TryGetValue("MI_FEMALE", out int femaleValue) && mover.Id == femaleValue)) return;
            if(!File.Exists(mover.Model.Model3DFilePath))
            {
                ModelViewerError = $"Model file not found: {mover.Model.Model3DFilePath}";
                return;
            }

            //CompositionTarget.Rendering -= CompositionTarget_Rendering;
            NativeMethods.LoadModel(D3dHost._native, mover.Model.Model3DFilePath);
            // TODO: Add a reset method to handle ListView unselection.

            SetModelTexture();
            SetScale();

            int texturesLength = NativeMethods.GetMaterialTexturesSize(D3dHost._native);

            List<string> textureFiles = [];
            for (int i = 0; i < texturesLength; i++)
            {
                IntPtr textureName = NativeMethods.GetMaterialTexture(D3dHost._native, i);
                string? texture = Marshal.PtrToStringAnsi(textureName);
                texture = Path.GetFileNameWithoutExtension(texture);
                if (texture is not null)
                    textureFiles.Add(texture);
            }
            Object3DMaterialTextures = [.. textureFiles];
            D3dHost.Render();
        }

        private void SetModelTexture()
        {
            if (D3dHost is null) return;
            if (MoversView.CurrentItem is not Mover mover) return;
            if(mover.Model is null) return;



            int textureEx = mover.Model.NTextureEx;
            NativeMethods.SetTextureEx(D3dHost._native, textureEx);
            if (!Auto3DRendering)
                D3dHost.Render();
        }

        private void SetScale()
        {
            if (D3dHost is null) return;
            if (MoversView.CurrentItem is not Mover mover) return;
            if (mover.Model is null) return;

            float scale = mover.Model.FScale;
            NativeMethods.SetScale(D3dHost._native, scale);
            if (!Auto3DRendering)
                D3dHost.Render();
        }
        #endregion 3D model viewer methods

        #region Event handlers
        private void Settings_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch(e.PropertyName)
            {
                case nameof(Settings.ModelsFolderPath):
                case nameof(Settings.DefaultModelsFolderPath):
                    {
                        OnPropertyChanged(nameof(ModelFilePossibilities));
                        OnPropertyChanged(nameof(ModelMotionFilePossibilities));
                        InitializeModelsDirectoryWatcherPath();
                        InitializeMotionsDirectoryWatcherPath();
                        break;
                    }
                case nameof(Settings.TexturesFolderPath):
                case nameof(Settings.DefaultTexturesFolderPath):
                    {
                        InitializeTexturesDirectoryWatcherPath();
                        OnPropertyChanged(nameof(ModelTexturesPossibilities));
                        break;
                    }
            }
        }

        private void ModelFile_Changed(object sender, FileSystemEventArgs e)
        {
            OnPropertyChanged(nameof(ModelFilePossibilities));
            if (MoversView.CurrentItem is not Mover mover) return;
            if (mover.Model is null) return;

            string modelPath = mover.Model.Model3DFilePath;

            if (e.FullPath == modelPath || (e is RenamedEventArgs renamedArgs && renamedArgs.OldFullPath == modelPath))
            {
                LoadModel();
            }
        }

        private void ModelTextureFile_Changed(object sender, FileSystemEventArgs e)
        {
            string fileName = Path.GetFileName(e.FullPath);

            foreach (string materialTexture in Object3DMaterialTextures)
            {
                string prefix = $"{materialTexture}-et";
                string suffix = ".dds";

                if (fileName.StartsWith(prefix, StringComparison.OrdinalIgnoreCase) && fileName.EndsWith(suffix, StringComparison.OrdinalIgnoreCase) && fileName.Length == prefix.Length + 2 + suffix.Length)
                {
                    string textureIndex = fileName.Substring(prefix.Length, 2);
                    if (textureIndex.All(char.IsDigit))
                    {
                        OnPropertyChanged(nameof(ModelTexturesPossibilities));
                        break;
                    }
                }
            }
        }

        private void ModelMotionFile_Changed(object sender, FileSystemEventArgs e)
        {
            OnPropertyChanged(nameof(ModelMotionFilePossibilities));
        }

        private void CurrentMover_Changing(object sender, CurrentChangingEventArgs e)
        {
            if (MoversView.CurrentItem is not Mover mover) return;
            mover.PropertyChanged -= CurrentMover_PropertyChanged;
            if(mover.Model is not null)
                mover.Model.PropertyChanged -= CurrentMoverModel_PropertyChanged;
        }

        private void CurrentMover_Changed(object? sender, EventArgs e)
        {
            if (MoversView.CurrentItem is Mover mover)
            {
                mover.PropertyChanged += CurrentMover_PropertyChanged;
                if (mover.Model is not null)
                    mover.Model.PropertyChanged += CurrentMoverModel_PropertyChanged;
            }

            OnPropertyChanged(nameof(ModelTexturesPossibilities));
            OnPropertyChanged(nameof(ModelMotionFilePossibilities));
            InitializeMotionsDirectoryWatcherPath();
            LoadModel();
        }

        private void CurrentMover_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Mover.Model))
            {
                if (e is not PropertyChangedExtendedEventArgs extendedArgs) return;
                if (extendedArgs.OldValue is ModelElem oldModel)
                    oldModel.PropertyChanged -= CurrentMoverModel_PropertyChanged;
                if (extendedArgs.NewValue is ModelElem newModel)
                    newModel.PropertyChanged += CurrentMoverModel_PropertyChanged;

                OnPropertyChanged(nameof(ModelTexturesPossibilities));
                OnPropertyChanged(nameof(ModelMotionFilePossibilities));
                InitializeMotionsDirectoryWatcherPath();
                LoadModel();
            }
        }

        private void CurrentMoverModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Mover.Model.Model3DFilePath))
            {
                OnPropertyChanged(nameof(ModelTexturesPossibilities));
                OnPropertyChanged(nameof(ModelMotionFilePossibilities));
                InitializeMotionsDirectoryWatcherPath();
                LoadModel();
            }
            else if(e.PropertyName == nameof(Mover.Model.NTextureEx))
            {
                SetModelTexture();
            }
            else if(e.PropertyName == nameof(Mover.Model.FScale))
            {
                SetScale();
            }
        }
        #endregion Event handlers

        #region Commands
        [RelayCommand]
        private void SelectModelFile()
        {
            if (MoversView.CurrentItem is not Mover mover) return;
            if (mover.Model is null) return;

            string? filePath = FileFolderSelector.SelectFile(mover.Model.Model3DFilePath, eTools_Ultimate.Resources.Texts.SelectMoverModelFile, $"{eTools_Ultimate.Resources.Texts.Mover3DFile}|mvr_*.o3d");

            string? directoryPath = Path.GetDirectoryName(filePath);
            string? fileName = Path.GetFileNameWithoutExtension(filePath);
            string? fileExtension = Path.GetExtension(filePath);
            string? modelsFolderPath = Path.GetDirectoryName(Settings.Instance.ModelsFolderPath ?? Settings.Instance.DefaultModelsFolderPath);

            if (
                filePath is null ||
                directoryPath is null ||
                fileName is null ||
                fileExtension is null ||
                !directoryPath.Equals(modelsFolderPath, StringComparison.OrdinalIgnoreCase) ||
                !fileName.StartsWith("mvr_", StringComparison.OrdinalIgnoreCase) ||
                !fileExtension.Equals(".o3d", StringComparison.OrdinalIgnoreCase)
                )
                return;

            mover.Model.SzName = fileName.Substring(4);
        }

        [RelayCommand]
        private async Task ShowReferenceModelContentDialog()
        {
            if(D3dHost is null) return;

            var contentDialog = new MoverReferenceModelDialog(contentDialogService.GetDialogHost());

            if(await contentDialog.ShowAsync() == Wpf.Ui.Controls.ContentDialogResult.Primary)
            {
                if (contentDialog.DataContext is not MoverReferenceModelViewModel contentDialogViewModel) return;

                //if (contentDialogViewModel.MoversView.CurrentItem is null) // TODO: remove reference model
                if (contentDialogViewModel.MoversView.CurrentItem is not Mover referenceMover) return;
                if(referenceMover.Model is not ModelElem referenceModel) return;
                NativeMethods.SetReferenceModel(D3dHost._native, referenceModel.Model3DFilePath);
                NativeMethods.SetReferenceScale(D3dHost._native, referenceModel.FScale);
                NativeMethods.SetReferenceTextureEx(D3dHost._native, referenceModel.NTextureEx);
                if (!Auto3DRendering)
                    D3dHost.Render();
            }
        }

        [RelayCommand]
        private void PlaySound(Sound? sound)
        {
            if(sound is not null)
                SoundsService.Instance.PlaySound(sound);
        }

        [RelayCommand]
        private void SelectSndDmg2File()
        {
            if (MoversView.CurrentItem is not Mover mover) return;

            string initialPath = mover.SndDmg2?.FilePath ?? Settings.Instance.SoundsFolderPath ?? Settings.Instance.DefaultSoundsFolderPath;

            string? filePath = FileFolderSelector.SelectFile(initialPath, eTools_Ultimate.Resources.Texts.SelectSoundFile, "Sound file|*.wav");
            if (filePath is null) return;

            Sound? newSound = SoundsService.Instance.Sounds.FirstOrDefault(x => x.FilePath.Equals(filePath, StringComparison.OrdinalIgnoreCase));
            if (newSound is null) return;
            mover.Prop.DwSndDmg2 = newSound.Prop.Id;
        }

        [RelayCommand]
        private void SelectSndIdle1File()
        {
            if (MoversView.CurrentItem is not Mover mover) return;

            string initialPath = mover.SndIdle1?.FilePath ?? Settings.Instance.SoundsFolderPath ?? Settings.Instance.DefaultSoundsFolderPath;

            string? filePath = FileFolderSelector.SelectFile(initialPath, eTools_Ultimate.Resources.Texts.SelectSoundFile, "Sound file|*.wav");
            if (filePath is null) return;

            Sound? newSound = SoundsService.Instance.Sounds.FirstOrDefault(x => x.FilePath.Equals(filePath, StringComparison.OrdinalIgnoreCase));
            if (newSound is null) return;
            mover.Prop.DwSndIdle1 = newSound.Prop.Id;
        }

        [RelayCommand]
        private async Task AddMover()
        {
            ContentDialogResult result = await contentDialogService.ShowSimpleDialogAsync(
                new SimpleContentDialogCreateOptions()
                {
                    Title = "Add a new mover",
                    Content = "Are you sure you want to add a new mover ?",
                    PrimaryButtonText = "Add",
                    CloseButtonText = "Cancel",
                }
            );
            if(result == ContentDialogResult.Primary)
            {
                Mover newMover = MoversService.Instance.CreateMover();
                MoversView.MoveCurrentTo(newMover);
                MoversView.Refresh();
            }
        }

        [RelayCommand]
        private async Task RemoveMover()
        {
            if (MoversView.CurrentItem is not Mover mover) return;

            ContentDialogResult result = await contentDialogService.ShowSimpleDialogAsync(
                new SimpleContentDialogCreateOptions()
                {
                    Title = "Remove a mover",
                    Content = $"Are you sure you want to remove the mover {mover.Identifier} ?",
                    PrimaryButtonText = "Remove",
                    CloseButtonText = "Cancel",
                }
            );
            if (result == ContentDialogResult.Primary)
            {
                MoversService.Instance.RemoveMover(mover);
                MoversView.Refresh();
            }
        }

        [RelayCommand]
        private async Task AddMoverMotion()
        {
            if (MoversView.CurrentItem is not Mover mover) return;
            if (mover.Model is null) return;

            ContentDialogResult result = await contentDialogService.ShowSimpleDialogAsync(
                new SimpleContentDialogCreateOptions()
                {
                    Title = "Add a motion",
                    Content = $"Are you sure you want to add a motion to the mover {mover.Identifier} ?",
                    PrimaryButtonText = "Add",
                    CloseButtonText = "Cancel",
                }
            );
            if (result == ContentDialogResult.Primary)
            {
                ModelMotion motion = new(-1, "");
                mover.Model.Motions.Add(motion);
                mover.Model.MotionsView.MoveCurrentTo(motion);
                mover.Model.MotionsView.Refresh();
            }
        }

        [RelayCommand]
        private async Task RemoveMoverMotion()
        {
            if (MoversView.CurrentItem is not Mover mover) return;
            if (mover.Model is null) return;
            if (mover.Model.MotionsView.CurrentItem is not ModelMotion motion) return;

            ContentDialogResult result = await contentDialogService.ShowSimpleDialogAsync(
                new SimpleContentDialogCreateOptions()
                {
                    Title = "Remove a motion",
                    Content = $"Are you sure you want to remove the motion {motion.MotionTypeIdentifier} from the mover {mover.Identifier} ?",
                    PrimaryButtonText = "Remove",
                    CloseButtonText = "Cancel",
                }
            );
            if (result == ContentDialogResult.Primary)
            {
                mover.Model.Motions.Remove(motion);
                mover.Model.MotionsView.Refresh();
            }
        }

        [RelayCommand]
        private void GenerateMoverMotions()
        {
            if (MoversView.CurrentItem is not Mover mover) return;
            if (mover.Model is null) return;

            string folderPath = Settings.Instance.ModelsFolderPath ?? Settings.Instance.DefaultModelsFolderPath; // Models folder path
            string filterPrefix = $"{Constants.ModelFilenameRoot[mover.Model.DwType]}_{mover.Model.SzName}_"; // Filter prefix for motion files
            string filter = $"{filterPrefix}*.ani"; // Entire filter
            string[] filePossibilities = [..Directory.GetFiles(folderPath, filter).Select(x => Path.GetFileNameWithoutExtension(x)[filterPrefix.Length..])]; // All .ani files for this model
            string[] motionTypeDefines = [.. DefinesService.Instance.ReversedMotionTypeDefines.Select(x => x.Value)]; // All motion type identifiers

            int generatedCount = 0;
            foreach (string filePossibility in filePossibilities)
            {
                string potentialTypeIdentifier = $"MTI_{filePossibility}";
                string? typeIdentifier = motionTypeDefines.FirstOrDefault(x => x.Equals(potentialTypeIdentifier, StringComparison.OrdinalIgnoreCase));

                if (typeIdentifier is null) continue; // No valid motion type identifier found

                int typeId = DefinesService.Instance.Defines[typeIdentifier]; // type ID from type identifier

                if (mover.Model.Motions.Any(x => x.IMotion == typeId)) continue; // Motion with this type already exists

                ModelMotion modelMotion = new(typeId, filePossibility);
                mover.Model.Motions.Add(modelMotion);
                generatedCount++;
            }

            var notificationManager = new NotificationManager();
            notificationManager.Show(
                title: "Motions generated",
                message: generatedCount > 1 ? $"{generatedCount} motions have been bound automatically." : $"{generatedCount} motion has been bound automatically",
                type:NotificationType.Success, "WindowArea"
                );
        }
        #endregion
    }
}
