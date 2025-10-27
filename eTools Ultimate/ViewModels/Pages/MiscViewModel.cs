using eTools_Ultimate.Models;
using eTools_Ultimate.Resources;
using eTools_Ultimate.Services;
using eTools_Ultimate.ViewModels.Windows;
using eTools_Ultimate.Views.Windows;
using FlyffModelParser;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Serilog;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Threading;
using Wpf.Ui;
using Wpf.Ui.Abstractions.Controls;
using Wpf.Ui.Controls;
using Wpf.Ui.Extensions;

namespace eTools_Ultimate.ViewModels.Pages
{
    public partial class MiscViewModel(IContentDialogService contentDialogService, ISnackbarService snackbarService, IStringLocalizer<Translations> localizer, SettingsService settingsService, ModelsService modelsService) : ObservableObject, INavigationAware
    {
        #region Properties
        private bool _isInitialized = false;

        private readonly WpfObservableRangeCollection<UnusedAsset> _unusedAssets = [];

        private AssetType? _selectedAssetType = null;

        private string _searchText = string.Empty;

        [ObservableProperty]
        private bool _isScanning = false;

        [ObservableProperty]
        private string _scanProgress = string.Empty;

        [ObservableProperty]
        private string _statusIcon = "Search24";

        [ObservableProperty]
        private string _statusColor = "Gray";
        #endregion Fields

        #region Fields
        public WpfObservableRangeCollection<UnusedAsset> UnusedAssets => _unusedAssets;

        public ICollectionView UnusedAssetsView => CollectionViewSource.GetDefaultView(UnusedAssets);

        private long TotalSize => UnusedAssets.Aggregate((long)0, (acc, asset) => acc + asset.FileSize);

        private long SelectedSize => UnusedAssets.Where(asset => asset.IsSelected).Aggregate((long)0, (acc, asset) => acc + asset.FileSize);

        public bool IsEveryFileSelected
        {
            get => !UnusedAssetsView.IsEmpty && UnusedAssetsView.Cast<UnusedAsset>().All(x => x.IsSelected);
            set
            {
                foreach (UnusedAsset asset in UnusedAssetsView)
                {
                    asset.PropertyChanged -= UnusedAsset_PropertyChanged;
                    asset.IsSelected = value;
                    asset.PropertyChanged += UnusedAsset_PropertyChanged;
                }
                OnPropertyChanged(nameof(IsEveryFileSelected));
                OnPropertyChanged(nameof(SelectedSize));
                OnPropertyChanged(nameof(SelectedSizeFormatted));
            }
        }

        public string TotalSizeFormatted => FormatFileSize(TotalSize);

        public string SelectedSizeFormatted => FormatFileSize(SelectedSize);

        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged();
                    UnusedAssetsView.Refresh();
                    OnPropertyChanged(nameof(IsEveryFileSelected));
                    OnPropertyChanged(nameof(SelectedSize));
                    OnPropertyChanged(nameof(SelectedSizeFormatted));
                }
            }
        }
        public AssetType? SelectedAssetType
        {
            get => _selectedAssetType;
            set
            {
                if (SelectedAssetType != value)
                {
                    _selectedAssetType = value;
                    OnPropertyChanged();
                    UnusedAssetsView.Refresh();
                    OnPropertyChanged(nameof(IsEveryFileSelected));
                    OnPropertyChanged(nameof(SelectedSize));
                    OnPropertyChanged(nameof(SelectedSizeFormatted));
                }
            }
        }
        #endregion Fields

        public Task OnNavigatedToAsync()
        {
            if (!_isInitialized)
                InitializeViewModel();

            return Task.CompletedTask;
        }

        public Task OnNavigatedFromAsync() => Task.CompletedTask;

        private void InitializeViewModel()
        {
            UnusedAssetsView.Filter = new Predicate<object>(FilterAsset);

            UnusedAssets.CollectionChanged += UnusedAssets_CollectionChanged;
            foreach (UnusedAsset asset in UnusedAssets)
            {
                asset.PropertyChanged += UnusedAsset_PropertyChanged;
            }

            _isInitialized = true;
        }

        private void UnusedAssets_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (sender != UnusedAssets)
                throw new InvalidOperationException("sender is not UnusedAssets");

            if (e.OldItems is not null)
            {
                foreach (object? oldItem in e.OldItems)
                {
                    if (oldItem is UnusedAsset asset)
                        asset.PropertyChanged -= UnusedAsset_PropertyChanged;
                }
            }
            if (e.NewItems is not null)
            {
                foreach (object? newItem in e.NewItems)
                {
                    if (newItem is UnusedAsset asset)
                        asset.PropertyChanged += UnusedAsset_PropertyChanged;
                }
            }

            OnPropertyChanged(nameof(IsEveryFileSelected));
            OnPropertyChanged(nameof(TotalSize));
            OnPropertyChanged(nameof(TotalSizeFormatted));
            OnPropertyChanged(nameof(SelectedSize));
            OnPropertyChanged(nameof(SelectedSizeFormatted));
        }

        private void UnusedAsset_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (sender is not UnusedAsset unusedAsset)
                throw new InvalidOperationException("sender is not UnusedAsset");

            switch (e.PropertyName)
            {
                case nameof(UnusedAsset.IsSelected):
                    OnPropertyChanged(nameof(IsEveryFileSelected));
                    OnPropertyChanged(nameof(SelectedSize));
                    OnPropertyChanged(nameof(SelectedSizeFormatted));
                    break;
            }
        }

        private bool FilterAsset(object obj)
        {
            if (obj is not UnusedAsset asset)
                throw new InvalidOperationException("obj is not UnusedAsset");

            if ((SelectedAssetType is null || asset.AssetType == SelectedAssetType) &&
                asset.FileName.Contains(SearchText, StringComparison.OrdinalIgnoreCase))
                return true;

            asset.PropertyChanged -= UnusedAsset_PropertyChanged;
            asset.IsSelected = false;
            asset.PropertyChanged += UnusedAsset_PropertyChanged;
            return false;
        }

        #region Commands
        [RelayCommand(IncludeCancelCommand = true)]
        private async Task ScanForUnusedAssets(CancellationToken cancellationToken)
        {
            ScanProgress = localizer["Scanning for unused assets..."];
            UnusedAssets.Clear();

            try
            {
                List<UnusedAsset> unusedAssets = [];

                await Task.Run(() =>
                {
                    // Scan models
                    ScanProgress = localizer["Scanning models..."];
                    unusedAssets.AddRange(ScanModels(cancellationToken));

                    // Scan textures
                    ScanProgress = localizer["Scanning textures..."];
                    unusedAssets.AddRange(ScanTextures(cancellationToken));

                    // Scan sounds
                    //ScanProgress = localizer["Scanning sounds..."];
                    //ScanSounds(unusedAssets);

                }, cancellationToken);

                UnusedAssets.AddRange(unusedAssets);

                ScanProgress = string.Format(localizer["Scan completed. Found {0} unused assets."], UnusedAssets.Count);
                StatusIcon = "Checkmark24";
                StatusColor = "Green";

                snackbarService.Show(
                    title: localizer["Scan completed"],
                    message: string.Format(localizer["Found {0} unused assets totaling {1}."],
                        UnusedAssets.Count,
                        TotalSizeFormatted),
                    appearance: ControlAppearance.Success,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(3)
                );
            }
            catch (Exception ex)
            {
                ScanProgress = string.Empty;
                if (ex is OperationCanceledException)
                {
                    snackbarService.Show(
                        title: localizer["Scan cancelled"],
                        message: localizer["The scan has been cancelled successfully."],
                        appearance: ControlAppearance.Success,
                        icon: null,
                        timeout: TimeSpan.FromSeconds(3)
                        );
                }
                else
                {
                    StatusIcon = "Search24";
                    StatusColor = "Gray";

                    Log.Error(ex, "Error during asset scanning");
                    snackbarService.Show(
                        title: localizer["Scan failed"],
                        message: ex.Message,
                        appearance: ControlAppearance.Danger,
                        icon: null,
                        timeout: TimeSpan.FromSeconds(5)
                    );
                }
            }
            finally
            {
                IsScanning = false;
            }
        }

        [RelayCommand]
        private async Task DeleteSelectedAssets()
        {
            UnusedAsset[] selectedAssets = [.. UnusedAssets.Where(a => a.IsSelected)];

            if (!selectedAssets.Any())
            {
                snackbarService.Show(
                    title: localizer["No selection"],
                    message: localizer["Please select assets to delete."],
                    appearance: ControlAppearance.Caution,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(2)
                );
                return;
            }

            var result = await contentDialogService.ShowSimpleDialogAsync(
                new SimpleContentDialogCreateOptions()
                {
                    Title = localizer["Delete selected assets"],
                    Content = string.Format(localizer["Are you sure you want to delete {0} selected assets? This action cannot be undone."], selectedAssets.LongLength),
                    PrimaryButtonText = localizer["Delete"],
                    CloseButtonText = localizer["Cancel"],
                }
            );

            if (result == ContentDialogResult.Primary)
            {
                StatusIcon = "Delete24";
                StatusColor = "Orange";
                try
                {
                    long deletedSize = 0;
                    int deletedCount = 0;

                    await Task.Run(() =>
                    {
                        for (int i = 0; i < selectedAssets.LongLength; i++)
                        {
                            UnusedAsset asset = selectedAssets[i];

                            Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(asset.FilePath, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);

                            Application.Current.Dispatcher.InvokeAsync(() =>
                            {
                                UnusedAssets.Remove(asset);
                            });
                            ScanProgress = string.Format(localizer["Deleting assets... ({0}%)"], Math.Floor((i + 1d) / selectedAssets.LongLength * 100));

                            deletedSize += asset.FileSize;
                            deletedCount++;
                        }
                    });

                    snackbarService.Show(
                        title: localizer["Assets deleted"],
                        message: string.Format(localizer["Successfully deleted {0} assets, freeing {1}."],
                            deletedCount,
                            FormatFileSize(deletedSize)),
                        appearance: ControlAppearance.Success,
                        icon: null,
                        timeout: TimeSpan.FromSeconds(3)
                    );
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Error during asset deletion");
                    snackbarService.Show(
                        title: localizer["Deletion failed"],
                        message: ex.Message,
                        appearance: ControlAppearance.Danger,
                        icon: null,
                        timeout: TimeSpan.FromSeconds(5)
                    );
                }
            }
        }

        [RelayCommand]
        private async Task DeleteSingleAsset(UnusedAsset asset)
        {
            if (asset == null) return;

            var result = await contentDialogService.ShowSimpleDialogAsync(
                new SimpleContentDialogCreateOptions()
                {
                    Title = localizer["Delete asset"],
                    Content = string.Format(localizer["Are you sure you want to delete '{0}'? This action cannot be undone."], asset.FileName),
                    PrimaryButtonText = localizer["Delete"],
                    CloseButtonText = localizer["Cancel"],
                }
            );

            if (result == ContentDialogResult.Primary)
            {
                // TODO: reimplement this
                //try
                //{
                //    if (File.Exists(asset.FilePath))
                //    {
                //        if (File.Exists(destPath))
                //        {
                //            destPath = Path.Combine(BinPath, $"{Path.GetFileNameWithoutExtension(asset.FilePath)}_{DateTime.Now.Ticks}{Path.GetExtension(asset.FilePath)}");
                //        }
                //        File.Move(asset.FilePath, destPath);
                //        File.AppendAllText(LogPath, $"{DateTime.Now}: Moved {asset.FilePath} to {destPath} by {Environment.MachineName}\n");
                //        TotalSizeAfter -= asset.FileSize;
                //        OnPropertyChanged(nameof(TotalSizeAfterFormatted));
                //        UnusedAssets.Remove(asset);
                //        UnusedAssetsView?.Refresh();

                //        snackbarService.Show(
                //            title: localizer["Asset moved"],
                //            message: string.Format(localizer["Successfully moved '{0}' to bin."], asset.FileName),
                //            appearance: ControlAppearance.Success,
                //            icon: null,
                //            timeout: TimeSpan.FromSeconds(2)
                //        );
                //    }
                //}
                //catch (Exception ex)
                //{
                //    Log.Error(ex, "Error deleting asset: {FilePath}", asset.FilePath);
                //    snackbarService.Show(
                //        title: localizer["Deletion failed"],
                //        message: ex.Message,
                //        appearance: ControlAppearance.Danger,
                //        icon: null,
                //        timeout: TimeSpan.FromSeconds(3)
                //    );
                //}
            }
        }

        [RelayCommand]
        private void OpenInExplorer(UnusedAsset asset)
        {
            if (asset != null && File.Exists(asset.FilePath))
                Process.Start("explorer.exe", $"/select,\"{asset.FilePath}\"");
        }

        [RelayCommand]
        private async Task ViewLog()
        { // TODO: readd this
            //if (File.Exists(LogPath))
            //{
            //var viewModel = new DeletionLogViewModel(snackbarService, LogPath);
            //var dialog = new Views.Dialogs.DeletionLogDialog(contentDialogService.GetDialogHost(), viewModel);
            //await dialog.ShowAsync();
            //}
            //else
            //{
            //    snackbarService.Show(
            //        title: localizer["No log found"],
            //        message: localizer["No deletion log exists yet."],
            //        appearance: ControlAppearance.Info,
            //        icon: null,
            //        timeout: TimeSpan.FromSeconds(2)
            //    );
            //}
        }
        #endregion Commands

        #region Private Methods
        private UnusedAsset[] ScanModels(CancellationToken cancellationToken)
        {
            HashSet<string> usedModelFiles = new(StringComparer.OrdinalIgnoreCase);

            string modelsDirectoryPath = settingsService.Settings.ModelsFolderPath ?? settingsService.Settings.DefaultModelsFolderPath;

            usedModelFiles.UnionWith(Constants.PredefinedUsedModelsFolderFiles.Select(fileName => Path.Combine(modelsDirectoryPath, fileName)));

            Settings settings = App.Services.GetRequiredService<SettingsService>().Settings;
            string modelsFolderPath = settings.ModelsFolderPath ?? settings.DefaultModelsFolderPath;

            Model[] models = modelsService.GetModels();

            for (int i = 0; i < models.Length; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();

                Model model = models[i];

                usedModelFiles.Add(model.Model3DFilePath);
                string prefix = Path.GetFileNameWithoutExtension(model.Model3DFilePath) ?? throw new InvalidOperationException("Model3DFilePath does not contain a valid file name.");

                if (model.ModelTypeIdentifier == "MODELTYPE_ANIMATED_MESH")
                    usedModelFiles.Add(Path.ChangeExtension(model.Model3DFilePath, ".chr"));

                string partsPath = $"{Path.Combine(modelsDirectoryPath, $"part_{model.Prop.SzPart}.o3d")}";
                usedModelFiles.Add(partsPath);
                string[] parts = model.Prop.SzPart.Split('/');
                if (parts.Length > 1)
                {
                    usedModelFiles.Add($"{Path.Combine(modelsDirectoryPath, $"part_{parts[0]}.o3d")}");
                    usedModelFiles.Add($"{Path.Combine(modelsDirectoryPath, $"part_{parts[1]}.o3d")}");
                }
                foreach (ModelMotion motion in model.Motions)
                {
                    string filePath = $"{Path.Combine(modelsDirectoryPath, $"{prefix}_{motion.Prop.SzMotion}.ani")}";
                    usedModelFiles.Add(filePath);
                }

                ScanProgress = $"{localizer[$"Scanning models..."]} ({Math.Floor((i + 1d) / models.Length * 100)}%)";
            }

            string[] allFiles = [.. Directory.EnumerateFiles(modelsFolderPath, "*", SearchOption.TopDirectoryOnly)];

            List<UnusedAsset> unusedAssets = [];
            foreach (string file in allFiles)
            {
                if (!usedModelFiles.Contains(file))
                {
                    FileInfo fileInfo = new(file);
                    UnusedAsset asset = new(fileInfo);
                    unusedAssets.Add(asset);
                }
            }

            return [.. unusedAssets];
        }

        private UnusedAsset[] ScanTextures(CancellationToken cancellationToken)
        {
            string modelsFolderPath = settingsService.Settings.ModelsFolderPath ?? settingsService.Settings.DefaultModelsFolderPath;
            string texturesFolderPath = settingsService.Settings.TexturesFolderPath ?? settingsService.Settings.DefaultTexturesFolderPath;

            Dictionary<string, HashSet<int>> modelsTexturesList = Constants.PredefinedUsedModelsFolderFiles.Where(x => x.EndsWith(".o3d")).ToDictionary(x => Path.Combine(modelsFolderPath, x), x => new HashSet<int>(Enumerable.Range(0, 10)));

            foreach (Model model in modelsService.GetModels())
            {
                List<string> modelFilePaths = [model.Model3DFilePath, Path.Combine(modelsFolderPath, $"part_{model.Prop.SzPart}.o3d")];

                string[] partsPaths = model.Prop.SzPart.Split('/');
                if (partsPaths.Length > 1)
                {
                    modelFilePaths.Add(Path.Combine(modelsFolderPath, $"part_{partsPaths[0]}.o3d"));
                    modelFilePaths.Add(Path.Combine(modelsFolderPath, $"part_{partsPaths[1]}.o3d"));
                }

                foreach (string modelFilePath in modelFilePaths)
                {
                    if (!modelsTexturesList.ContainsKey(modelFilePath))
                        modelsTexturesList.Add(modelFilePath, []);
                    HashSet<int> textures = modelsTexturesList[modelFilePath];
                    textures.Add(model.Prop.NTextureEx);
                }
            }

            HashSet<string> usedTextures = new(Constants.PredefinedUsedTexturesFolderFiles.Select(x => Path.Combine(texturesFolderPath, x)), StringComparer.OrdinalIgnoreCase);

            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < modelsTexturesList.Count; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();

                KeyValuePair<string, HashSet<int>> modelTextures = modelsTexturesList.ElementAt(i);
                string modelFile = modelTextures.Key;

                if (File.Exists(modelFile))
                {
                    try
                    {
                        ModelParser modelParser = new();
                        modelParser.Load(modelFile);
                        string[] textureNames = modelParser.GetTextureNames();
                        foreach (string textureName in textureNames)
                        {
                            string textureFileName = textureName.TrimEnd('\0');
                            string textureFileExtension = Path.GetExtension(textureFileName);
                            string textureFileNameWithoutExtension = Path.GetFileNameWithoutExtension(textureFileName);

                            foreach (int textureEx in modelTextures.Value)
                                usedTextures.Add(Path.Combine(texturesFolderPath, textureEx == 0 ? textureFileName : $"{textureFileNameWithoutExtension}-et{textureEx:00}{textureFileExtension}"));
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex, $"Error while reading textures of model file {modelFile}");
                    }
                }
                ScanProgress = $"{localizer[$"Scanning textures..."]} ({Math.Floor((i + 1d) / modelsTexturesList.Count * 100)}%)";
            }
            stopwatch.Stop();
            System.Diagnostics.Debug.WriteLine($"Unused textures loading took {stopwatch.ElapsedMilliseconds}ms to run");

            List<string> allTextureFiles = [.. Directory.EnumerateFiles(texturesFolderPath, "*", SearchOption.TopDirectoryOnly)];

            string[] unusedTextureFiles = [.. allTextureFiles.FindAll(file => !usedTextures.Contains(file))];

            return [..unusedTextureFiles.Select(file =>
            {
                FileInfo fileInfo = new(file);
                return new UnusedAsset(fileInfo);
            })];
        }

        private string FormatFileSize(long bytes)
        {
            double len = bytes;
            if (len >= 1000000000)
            {
                len /= 1000000000;
                return $"{len:0.##} Gb";
            }
            else if (len >= 1000000)
            {
                len /= 1000000;
                return $"{len:0.##} Mb";
            }
            else if (len >= 1000)
            {
                len /= 1000;
                return $"{len:0.##} Kb";
            }
            else
            {
                return $"{len:0.##} B";
            }
        }
        #endregion Private Methods
    }

    public enum AssetType
    {
        Model,
        Animation,
        Bones,
        Texture,
        Unknown
    };

    public partial class UnusedAsset(FileInfo info) : ObservableObject
    {
        private FileInfo _info = info;
        private bool _isSelected = false;

        public string FileName => _info.Name;
        public string FilePath => _info.FullName;
        public long FileSize => _info.Length;
        public DateTime LastModified => _info.LastWriteTime;

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged();
                }
            }
        }

        public AssetType AssetType => _info.Extension.ToLowerInvariant() switch
        {
            ".o3d" => AssetType.Model,
            ".ani" => AssetType.Animation,
            ".chr" => AssetType.Bones,
            ".dds" => AssetType.Texture,
            _ => AssetType.Unknown
        };

        public string FormattedFileSize
        {
            get
            {
                double len = FileSize;
                if (len >= 1000000000)
                {
                    len /= 1000000000;
                    return $"{len:0.##} Gb";
                }
                else if (len >= 1000000)
                {
                    len /= 1000000;
                    return $"{len:0.##} Mb";
                }
                else if (len >= 1000)
                {
                    len /= 1000;
                    return $"{len:0.##} Kb";
                }
                else
                {
                    return $"{len:0.##} B";
                }
            }
        }
    }
}
