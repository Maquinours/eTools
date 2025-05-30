using eTools_Ultimate.Models;
using eTools_Ultimate.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
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
            };

            this._modelsDirectoryWatcher.Renamed += (sender, e) => OnPropertyChanged(nameof(ModelFilePossibilities));
            this._modelsDirectoryWatcher.Created += (sender, e) => OnPropertyChanged(nameof(ModelFilePossibilities));
            this._modelsDirectoryWatcher.Deleted += (sender, e) => OnPropertyChanged(nameof(ModelFilePossibilities));
            InitializeModelsDirectoryWatcherPath();

            _isInitialized = true;
        }

        private void InitializeModelsDirectoryWatcherPath()
        {
            this._modelsDirectoryWatcher.EnableRaisingEvents = false;
            this._modelsDirectoryWatcher.Path = Settings.Instance.ModelsFolderPath ?? Settings.Instance.DefaultModelsFolderPath;
            this._modelsDirectoryWatcher.EnableRaisingEvents = true;
        }

        private bool FilterItem(object obj)
        {
            if (obj is not Mover mover) return false;
            if (string.IsNullOrEmpty(this.SearchText)) return true;
            return mover.Name.ToLower().Contains(this.SearchText.ToLower());
        }
    }
}
