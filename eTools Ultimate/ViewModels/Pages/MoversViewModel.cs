using eTools_Ultimate.Helpers;
using eTools_Ultimate.Models;
using eTools_Ultimate.Services;
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
using Wpf.Ui.Abstractions.Controls;

namespace eTools_Ultimate.ViewModels.Pages
{
    public partial class MoversViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;

        [ObservableProperty]
        private IEnumerable<DataColor> _colors;

        private string _searchText = string.Empty;

        [ObservableProperty]
        private ICollectionView _moversView = CollectionViewSource.GetDefaultView(MoversService.Instance.Movers);

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

        private string[] _object3DMaterialTextures = [];
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

        public List<KeyValuePair<int, string>> MoverIdentifiers => DefinesService.Instance.ReversedMoverDefines.ToList();
        public List<KeyValuePair<int, string>> BelligerenceIdentifiers => DefinesService.Instance.ReversedBelligerenceDefines.ToList();
        public List<KeyValuePair<int, string>> AiIdentifiers => DefinesService.Instance.ReversedAiDefines.ToList();

        private FileSystemWatcher _modelsDirectoryWatcher = new()
        {
            Filter = "mvr_*.o3d",
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

        public Task OnNavigatedToAsync()
        {
            if (!_isInitialized)
                InitializeViewModel();

            return Task.CompletedTask;
        }

        public Task OnNavigatedFromAsync() => Task.CompletedTask;

        private void InitializeViewModel()
        {
            var random = new Random();
            var colorCollection = new List<DataColor>();

            for (int i = 0; i < 8192; i++)
                colorCollection.Add(
                    new DataColor
                    {
                        Color = new SolidColorBrush(
                            Color.FromArgb(
                                (byte)200,
                                (byte)random.Next(0, 250),
                                (byte)random.Next(0, 250),
                                (byte)random.Next(0, 250)
                            )
                        )
                    }
                );

            Colors = colorCollection;

            MoversView.Filter = new Predicate<object>(FilterItem);

            Settings.Instance.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(Settings.ModelsFolderPath) || e.PropertyName == nameof(Settings.DefaultModelsFolderPath))
                {
                    InitializeModelsDirectoryWatcherPath();
                    OnPropertyChanged(nameof(ModelFilePossibilities));
                }
                else if(e.PropertyName == nameof(Settings.TexturesFolderPath) || e.PropertyName == nameof(Settings.DefaultTexturesFolderPath))
                {
                    InitializeTexturesDirectoryWatcherPath();
                    OnPropertyChanged(nameof(ModelTexturesPossibilities));
                }
            };

            this._modelsDirectoryWatcher.Renamed += (sender, e) => OnPropertyChanged(nameof(ModelFilePossibilities));
            this._modelsDirectoryWatcher.Created += (sender, e) => OnPropertyChanged(nameof(ModelFilePossibilities));
            this._modelsDirectoryWatcher.Deleted += (sender, e) => OnPropertyChanged(nameof(ModelFilePossibilities));
            InitializeModelsDirectoryWatcherPath();

            this._texturesDirectoryWatcher.Renamed += OnTextureFileChanged;
            this._texturesDirectoryWatcher.Created += OnTextureFileChanged;
            this._texturesDirectoryWatcher.Deleted += OnTextureFileChanged;
            InitializeTexturesDirectoryWatcherPath();

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

        private void OnTextureFileChanged(object sender, FileSystemEventArgs e)
        {
            string fileName = Path.GetFileName(e.FullPath);

            foreach(string materialTexture in Object3DMaterialTextures)
            {
                string prefix = $"{materialTexture}-et";
                string suffix = ".dds";

                if(fileName.StartsWith(prefix, StringComparison.OrdinalIgnoreCase) && fileName.EndsWith(suffix, StringComparison.OrdinalIgnoreCase) && fileName.Length == prefix.Length + 2 + suffix.Length)
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

        private bool FilterItem(object obj)
        {
            if (obj is not Mover mover) return false;
            if (string.IsNullOrEmpty(this.SearchText)) return true;
            return mover.Name.ToLower().Contains(this.SearchText.ToLower());
        }

        public void UpdateModelTexturesPossibilities()
        {
            OnPropertyChanged(nameof(ModelTexturesPossibilities));
        }
    }
}
