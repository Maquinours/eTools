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

        [ObservableProperty]
        private ObservableCollection<UnusedAsset> _unusedAssets = [];

        [ObservableProperty]
        private ICollectionView? _unusedAssetsView;

        [ObservableProperty]
        private bool _isScanning = false;

        [ObservableProperty]
        private string _scanProgress = string.Empty;

        [ObservableProperty]
        private long _totalSizeBefore = 0;

        [ObservableProperty]
        private long _totalSizeAfter = 0;

        [ObservableProperty]
        private long _selectedSize = 0;

        [ObservableProperty]
        private bool _selectAllChecked = false;

        public string TotalSizeBeforeFormatted => FormatFileSize(TotalSizeBefore);

        public string TotalSizeAfterFormatted => FormatFileSize(TotalSizeAfter);

        public string SelectedSizeFormatted => FormatFileSize(SelectedSize);

        [ObservableProperty]
        private bool _hasSelectedAssets = false;

        [ObservableProperty]
        private string _statusIcon = "Search24";

        [ObservableProperty]
        private ObservableCollection<string> _assetTypes = new() { "All", "Model", "Texture", "Sound" };

        [ObservableProperty]
        private string _selectedAssetType = "All";

        public ICollectionView FilteredAssets => UnusedAssetsView;

        [ObservableProperty]
        private string _statusColor = "Gray";

        private string BinPath => Path.Combine(Path.GetDirectoryName(settingsService.Settings.ModelsFolderPath ?? settingsService.Settings.DefaultModelsFolderPath) ?? "", "bin_models");

        private string LogPath => Path.Combine(BinPath, "deletion_log.txt");

        private string _searchText = string.Empty;

        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged(nameof(SearchText));
                    UnusedAssetsView?.Refresh();
                }
            }
        }

        partial void OnSelectedAssetTypeChanged(string value)
        {
            UnusedAssetsView?.Refresh();
        }
        #endregion Properties

        public Task OnNavigatedToAsync()
        {
            if (!_isInitialized)
                InitializeViewModel();

            return Task.CompletedTask;
        }

        public Task OnNavigatedFromAsync() => Task.CompletedTask;

        private void InitializeViewModel()
        {
            UnusedAssetsView = CollectionViewSource.GetDefaultView(UnusedAssets);
            UnusedAssetsView.Filter = new Predicate<object>(FilterAsset);
            _isInitialized = true;
        }

        private bool FilterAsset(object obj)
        {
            if (obj is not UnusedAsset asset) return false;

            // Type filter
            if (SelectedAssetType != "All" && asset.AssetType != SelectedAssetType) return false;

            // Search filter
            if (string.IsNullOrEmpty(SearchText)) return true;

            return asset.FileName.ToLower().Contains(SearchText.ToLower()) ||
                    asset.FilePath.ToLower().Contains(SearchText.ToLower()) ||
                    asset.AssetType.ToLower().Contains(SearchText.ToLower());
        }

        #region Commands
        [RelayCommand]
        private async Task ScanForUnusedAssets()
        {
            IsScanning = true;
            StatusIcon = "ArrowClockwise24";
            StatusColor = "Orange";
            ScanProgress = localizer["Scanning for unused assets..."];
            UnusedAssets.Clear();
            TotalSizeBefore = 0;
            TotalSizeAfter = 0;
            SelectedSize = 0;

            try
            {
                await Task.Run(() =>
                {
                    var unusedAssets = new List<UnusedAsset>();
                    List<string> usedModelFiles = [];

                    // Scan models
                    ScanProgress = localizer["Scanning models..."];
                    unusedAssets.AddRange(ScanModels(ref usedModelFiles));

                    // Scan textures
                    ScanProgress = localizer["Scanning textures..."];
                    unusedAssets.AddRange(ScanTextures(usedModelFiles));

                    // Scan sounds
                    //ScanProgress = localizer["Scanning sounds..."];
                    //ScanSounds(unusedAssets);

                    // Update UI on main thread
                    App.Current.Dispatcher.Invoke(() =>
                    {
                        foreach (var asset in unusedAssets) // Limit to 10 files for testing
                        {
                            UnusedAssets.Add(asset);
                            TotalSizeBefore += asset.FileSize;
                        }
                        TotalSizeAfter = TotalSizeBefore;
                        OnPropertyChanged(nameof(TotalSizeBeforeFormatted));
                        OnPropertyChanged(nameof(TotalSizeAfterFormatted));
                    });
                });

                ScanProgress = string.Format(localizer["Scan completed. Found {0} unused assets."], UnusedAssets.Count);
                StatusIcon = "Checkmark24";
                StatusColor = "Green";

                snackbarService.Show(
                    title: localizer["Scan completed"],
                    message: string.Format(localizer["Found {0} unused assets totaling {1}."],
                        UnusedAssets.Count,
                        FormatFileSize(TotalSizeBefore)),
                    appearance: ControlAppearance.Success,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(3)
                );
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error during asset scanning");
                snackbarService.Show(
                    title: localizer["Scan failed"],
                    message: ex.Message,
                    appearance: ControlAppearance.Danger,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(5)
                );
            }
            finally
            {
                IsScanning = false;
            }
        }

        [RelayCommand]
        private async Task DeleteSelectedAssets()
        {
            var selectedAssets = UnusedAssets.Where(a => a.IsSelected).ToList();

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
                    Content = string.Format(localizer["Are you sure you want to delete {0} selected assets? This action cannot be undone."], selectedAssets.Count),
                    PrimaryButtonText = localizer["Delete"],
                    CloseButtonText = localizer["Cancel"],
                }
            );

            if (result == ContentDialogResult.Primary)
            {
                try
                {
                    long deletedSize = 0;
                    int deletedCount = 0;

                    Directory.CreateDirectory(BinPath);

                    foreach (var asset in selectedAssets)
                    {
                        try
                        {
                            if (File.Exists(asset.FilePath))
                            {
                                string destPath = Path.Combine(BinPath, Path.GetFileName(asset.FilePath));
                                if (File.Exists(destPath))
                                {
                                    destPath = Path.Combine(BinPath, $"{Path.GetFileNameWithoutExtension(asset.FilePath)}_{DateTime.Now.Ticks}{Path.GetExtension(asset.FilePath)}");
                                }
                                File.Move(asset.FilePath, destPath);
                                File.AppendAllText(LogPath, $"{DateTime.Now}: Moved {asset.FilePath} to {destPath} by {Environment.MachineName}\n");
                                deletedSize += asset.FileSize;
                                deletedCount++;
                                UnusedAssets.Remove(asset);
                            }
                        }
                        catch (Exception ex)
                        {
                            Log.Warning(ex, "Failed to move asset: {FilePath}", asset.FilePath);
                        }
                    }

                    TotalSizeAfter -= deletedSize;
                    SelectedSize = 0; // Since selected are deleted
                    OnPropertyChanged(nameof(TotalSizeAfterFormatted));
                    OnPropertyChanged(nameof(SelectedSizeFormatted));
                    UnusedAssetsView?.Refresh();

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
        private void SelectAllAssets()
        {
            SelectAllChecked = !SelectAllChecked;

            foreach (var asset in UnusedAssets)
            {
                asset.IsSelected = SelectAllChecked;
            }

            SelectedSize = UnusedAssets.Where(a => a.IsSelected).Sum(a => a.FileSize);
            OnPropertyChanged(nameof(SelectedSizeFormatted));
            HasSelectedAssets = UnusedAssets.Any(a => a.IsSelected);
        }


        [RelayCommand]
        private void ClearSelection()
        {
            SelectAllChecked = false;
            foreach (var asset in UnusedAssets)
            {
                asset.IsSelected = false;
            }
            SelectedSize = 0;
            OnPropertyChanged(nameof(SelectedSizeFormatted));
            HasSelectedAssets = false;
        }

        [RelayCommand]
        private void SelectAsset(UnusedAsset asset)
        {
            if (asset != null)
            {
                asset.IsSelected = !asset.IsSelected;
                SelectedSize = UnusedAssets.Where(a => a.IsSelected).Sum(a => a.FileSize);
                OnPropertyChanged(nameof(SelectedSizeFormatted));
                HasSelectedAssets = UnusedAssets.Any(a => a.IsSelected);

                // Update SelectAllChecked based on current selection
                SelectAllChecked = UnusedAssets.All(a => a.IsSelected);
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
                try
                {
                    if (File.Exists(asset.FilePath))
                    {
                        Directory.CreateDirectory(BinPath);
                        string destPath = Path.Combine(BinPath, Path.GetFileName(asset.FilePath));
                        if (File.Exists(destPath))
                        {
                            destPath = Path.Combine(BinPath, $"{Path.GetFileNameWithoutExtension(asset.FilePath)}_{DateTime.Now.Ticks}{Path.GetExtension(asset.FilePath)}");
                        }
                        File.Move(asset.FilePath, destPath);
                        File.AppendAllText(LogPath, $"{DateTime.Now}: Moved {asset.FilePath} to {destPath}\n");
                        TotalSizeAfter -= asset.FileSize;
                        OnPropertyChanged(nameof(TotalSizeAfterFormatted));
                        UnusedAssets.Remove(asset);
                        UnusedAssetsView?.Refresh();

                        snackbarService.Show(
                            title: localizer["Asset moved"],
                            message: string.Format(localizer["Successfully moved '{0}' to bin."], asset.FileName),
                            appearance: ControlAppearance.Success,
                            icon: null,
                            timeout: TimeSpan.FromSeconds(2)
                        );
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Error deleting asset: {FilePath}", asset.FilePath);
                    snackbarService.Show(
                        title: localizer["Deletion failed"],
                        message: ex.Message,
                        appearance: ControlAppearance.Danger,
                        icon: null,
                        timeout: TimeSpan.FromSeconds(3)
                    );
                }
            }
        }

        [RelayCommand]
        private void OpenInExplorer(UnusedAsset asset)
        {
            if (asset != null && File.Exists(asset.FilePath))
            {
                Process.Start("explorer.exe", $"/select,\"{asset.FilePath}\"");
            }
        }

        [RelayCommand]
        private async Task ViewLog()
        {
            //if (File.Exists(LogPath))
            //{
            var viewModel = new DeletionLogViewModel(snackbarService, LogPath);
            var dialog = new Views.Dialogs.DeletionLogDialog(contentDialogService.GetDialogHost(), viewModel);
            await dialog.ShowAsync();
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
        private UnusedAsset[] ScanModels(ref List<string> usedModels)
        {
            HashSet<string> usedModelFiles = new(StringComparer.OrdinalIgnoreCase);

            string modelsDirectoryPath = settingsService.Settings.ModelsFolderPath ?? settingsService.Settings.DefaultModelsFolderPath;

            usedModelFiles.UnionWith(new List<string>([
                ..Enumerable.Range(0, 100).Select(i => string.Format("Part_maleHair{0:00}.o3d", i)), ..Enumerable.Range(0, 100).Select(i => string.Format("Part_femaleHair{0:00}.o3d", i)),
                ..Enumerable.Range(0, 100).Select(i => string.Format("Part_maleHead{0:00}.o3d", i)), ..Enumerable.Range(0, 100).Select(i => string.Format("Part_femaleHead{0:00}.o3d", i)),
                "Part_maleUpper.o3d", "Part_femaleUpper.o3d",
                "Part_maleLower.o3d", "Part_femaleLower.o3d",
                "Part_maleHand.o3d", "Part_femaleHand.o3d",
                "Part_maleFoot.o3d", "Part_femaleFoot.o3d",
                "arrow.o3d", "etc_arrow.o3d",
                "Mvr_Guidepang.o3d", "Mvr_Guidepang.chr",
                "Mvr_McGuidepang.o3d", "Mvr_McGuidepang.chr",
                "Mvr_AsGuidepang.o3d", "Mvr_AsGuidepang.chr",
                "Mvr_MgGuidepang.o3d", "Mvr_MgGuidepang.chr",
                "Mvr_AcrGuidepang.o3d", "Mvr_AcrGuidepang.chr",
                "Shadow.o3d"])
                .Select(fileName => Path.Combine(modelsDirectoryPath, fileName)));

            Settings settings = App.Services.GetRequiredService<SettingsService>().Settings;
            string modelsFolderPath = settings.ModelsFolderPath ?? settings.DefaultModelsFolderPath;

            foreach (Model model in modelsService.GetModels())
            {
                usedModelFiles.Add(model.Model3DFilePath);
                string? directoryPath = Path.GetDirectoryName(model.Model3DFilePath);
                string? prefix = Path.GetFileNameWithoutExtension(model.Model3DFilePath);
                if (model.ModelTypeIdentifier == "MODELTYPE_ANIMATED_MESH")
                    usedModelFiles.Add(Path.ChangeExtension(model.Model3DFilePath, ".chr"));

                if (directoryPath is not null)
                {
                    string partsPath = $"{Path.Combine(directoryPath, $"part_{model.Prop.SzPart}.o3d")}";
                    usedModelFiles.Add(partsPath);
                    string[] parts = model.Prop.SzPart.Split('/');
                    if (parts.Length > 1)
                    {
                        usedModelFiles.Add($"{Path.Combine(directoryPath, $"part_{parts[0]}.o3d")}");
                        usedModelFiles.Add($"{Path.Combine(directoryPath, $"part_{parts[1]}.o3d")}");
                    }
                }
                if (directoryPath is not null && prefix is not null)
                {
                    foreach (ModelMotion motion in model.Motions)
                    {
                        string filePath = $"{Path.Combine(directoryPath, $"{prefix}_{motion.Prop.SzMotion}.ani")}";
                        usedModelFiles.Add(filePath);
                    }
                }
            }

            List<string> allModelFiles = [.. Directory.EnumerateFiles(modelsFolderPath, "*", SearchOption.TopDirectoryOnly)];

            string[] unusedModelFiles = [.. allModelFiles.FindAll(file => !usedModelFiles.Contains(file))];

            usedModels.AddRange(usedModelFiles);

            return [..unusedModelFiles.Select(file =>
            {
                FileInfo fileInfo = new(file);
                return new UnusedAsset()
                {
                    FileName = fileInfo.Name,
                    FilePath = fileInfo.FullName,
                    AssetType = fileInfo.Extension == ".o3d" ? "Model" : "Unknown",
                    FileSize = fileInfo.Length,
                    LastModified = fileInfo.LastWriteTime
                };
            })];
        }

        private UnusedAsset[] ScanTextures(List<string> usedModelFiles)
        {

            string texturesFolderPath = settingsService.Settings.TexturesFolderPath ?? settingsService.Settings.DefaultTexturesFolderPath;

            List<string> tempUsedTextureFiles = [];

            Stopwatch stopwatch = Stopwatch.StartNew();
            foreach (string modelFile in usedModelFiles)
            {
                if (Path.GetExtension(modelFile) == ".o3d" && File.Exists(modelFile))
                {
                    ModelParser modelParser = new();
                    modelParser.Load(modelFile);
                    string[] texturePaths = [.. modelParser.GetTextureNames().Select(textureName => Path.Combine(texturesFolderPath, textureName.TrimEnd('\0')))];
                    tempUsedTextureFiles.AddRange(texturePaths);
                }
            }

            //Parallel.ForEach(usedModelFiles, modelFile =>
            //{
            //    if (Path.GetExtension(modelFile) == ".o3d" && File.Exists(modelFile))
            //    {
            //        ModelParser modelParser = new();
            //        modelParser.Load(modelFile);
            //        string[] texturePaths = [.. modelParser.GetTextureNames().Select(textureName => Path.Combine(texturesFolderPath, textureName))];
            //        foreach (string texturePath in texturePaths)
            //            tempUsedTextureFiles.Add(texturePath);
            //    }
            //});
            stopwatch.Stop();
            System.Diagnostics.Debug.WriteLine($"Unused textures loading took {stopwatch.ElapsedMilliseconds}ms to run");

            HashSet<string> usedTextureFiles = new(tempUsedTextureFiles, StringComparer.OrdinalIgnoreCase);

            List<string> allTextureFiles = [.. Directory.EnumerateFiles(texturesFolderPath, "*", SearchOption.TopDirectoryOnly)];

            string[] unusedTextureFiles = [.. allTextureFiles.FindAll(file => !usedTextureFiles.Contains(file))];

            return [..unusedTextureFiles.Select(file =>
            {
                FileInfo fileInfo = new(file);
                return new UnusedAsset()
                {
                    FileName = fileInfo.Name,
                    FilePath = fileInfo.FullName,
                    AssetType = "Texture",
                    FileSize = fileInfo.Length,
                    LastModified = fileInfo.LastWriteTime
                };
            })];
        }

        private void ScanSounds(List<UnusedAsset> unusedAssets)
        {
            var soundsPath = settingsService.Settings.SoundsFolderPath ?? settingsService.Settings.DefaultSoundsFolderPath;
            if (string.IsNullOrEmpty(soundsPath) || !Directory.Exists(soundsPath))
                return;

            var soundFiles = Directory.GetFiles(soundsPath, "*.wav", SearchOption.TopDirectoryOnly);

            foreach (var soundFile in soundFiles)
            {
                var fileName = Path.GetFileName(soundFile);
                var fileInfo = new FileInfo(soundFile);

                // Check if sound is referenced in any mover
                if (!IsSoundReferenced(fileName))
                {
                    unusedAssets.Add(new UnusedAsset
                    {
                        FileName = fileName,
                        FilePath = soundFile,
                        AssetType = "Sound",
                        FileSize = fileInfo.Length,
                        LastModified = fileInfo.LastWriteTime
                    });
                }
            }
        }

        private bool IsModelReferenced(string fileName)
        {
            // This would need to be implemented based on your data structure
            // For now, return false to show all models as unused (for demonstration)
            return false;
        }

        private bool IsTextureReferenced(string fileName)
        {
            // This would need to be implemented based on your data structure
            // For now, return false to show all textures as unused (for demonstration)
            return false;
        }

        private bool IsSoundReferenced(string fileName)
        {
            // This would need to be implemented based on your data structure
            // For now, return false to show all sounds as unused (for demonstration)
            return false;
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

    public partial class UnusedAsset : ObservableObject
    {
        [ObservableProperty]
        private string _fileName = string.Empty;

        [ObservableProperty]
        private string _filePath = string.Empty;

        [ObservableProperty]
        private string _assetType = string.Empty;

        [ObservableProperty]
        private long _fileSize = 0;

        [ObservableProperty]
        private DateTime _lastModified = DateTime.MinValue;

        [ObservableProperty]
        private bool _isSelected = false;

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
