using eTools_Ultimate.Helpers;
using eTools_Ultimate.Models;
using eTools_Ultimate.Services;
using eTools_Ultimate.Views.Dialogs;
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
using System.Windows.Media;
using System.Windows.Media.TextFormatting;
using Wpf.Ui;
using Wpf.Ui.Abstractions.Controls;

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
                string root = Path.GetFileNameWithoutExtension(mover.Model.Model3DFilePath);
                return [.. Directory.GetFiles(modelsFolderPath, $"{root}_*.ani", SearchOption.TopDirectoryOnly).Select(x => Path.GetFileNameWithoutExtension(x).Substring($"{root}_".Length))];
            }
        }

        public List<KeyValuePair<int, string>> MoverIdentifiers => DefinesService.Instance.ReversedMoverDefines.ToList();
        public List<KeyValuePair<int, string>> BelligerenceIdentifiers => DefinesService.Instance.ReversedBelligerenceDefines.ToList();
        public List<KeyValuePair<int, string>> AiIdentifiers => DefinesService.Instance.ReversedAiDefines.ToList();
        public List<KeyValuePair<int, string>> MotionIdentifiers => DefinesService.Instance.ReversedMotionTypeDefines.ToList();
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
            if (D3dHost is null) return;
            if (MoversView.CurrentItem is not Mover mover) return;
            if ((DefinesService.Instance.Defines.TryGetValue("MI_MALE", out int maleValue) && mover.Id == maleValue) || (DefinesService.Instance.Defines.TryGetValue("MI_FEMALE", out int femaleValue) && mover.Id == femaleValue)) return;

            //CompositionTarget.Rendering -= CompositionTarget_Rendering;
            Auto3DRendering = false;
            NativeMethods.LoadModel(D3dHost._native, mover.Model.Model3DFilePath);

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

            int textureEx = mover.Model.NTextureEx;
            NativeMethods.SetTextureEx(D3dHost._native, textureEx);
            if (!Auto3DRendering)
                D3dHost.Render();
        }

        private void SetScale()
        {
            if (D3dHost is null) return;
            if (MoversView.CurrentItem is not Mover mover) return;

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
            mover.Model.PropertyChanged -= CurrentMoverModel_PropertyChanged;
        }

        private void CurrentMover_Changed(object? sender, EventArgs e)
        {
            if (MoversView.CurrentItem is not Mover mover) return;
            mover.PropertyChanged += CurrentMover_PropertyChanged;
            mover.Model.PropertyChanged += CurrentMoverModel_PropertyChanged;

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
            var referenceModelContentDialog = new MoverReferenceModelDialog(contentDialogService.GetDialogHost());

            await referenceModelContentDialog.ShowAsync();
        }
        #endregion
    }
}
