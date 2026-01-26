using eTools_Ultimate.Helpers;
using eTools_Ultimate.Models;
using eTools_Ultimate.Models.GiftBoxes;
using eTools_Ultimate.Models.Models;
using eTools_Ultimate.Models.Movers;
using eTools_Ultimate.Resources;
using eTools_Ultimate.Services;
using eTools_Ultimate.ViewModels.Controls.Dialogs;
using eTools_Ultimate.Views.Dialogs;
using Microsoft.Extensions.Localization;
using Serilog;
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
    public partial class MoversViewModel(IContentDialogService contentDialogService, ISnackbarService snackbarService, IStringLocalizer<Translations> localizer, MoversService moversService, ModelsService modelsService, StringsService stringsService, SettingsService settingsService, DefinesService definesService, SoundsService soundsService) : ObservableObject, INavigationAware
    {
        #region Properties
        private bool _isInitialized = false;

        [ObservableProperty]
        private ICollectionView _moversView = CollectionViewSource.GetDefaultView(moversService.Movers);

        private string _searchText = string.Empty;

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
        private bool _showSoundsSection = true;
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

        public string[] ModelFilePossibilities
        {
            get
            {
                string modelsFolderPath = settingsService.Settings.ModelsFolderPath ?? settingsService.Settings.DefaultModelsFolderPath;
                if (string.IsNullOrEmpty(modelsFolderPath) || !Directory.Exists(modelsFolderPath))
                    return [];
                return [.. Directory.GetFiles(modelsFolderPath, "mvr_*.o3d", SearchOption.TopDirectoryOnly).Select(x => Path.GetFileNameWithoutExtension(x).Substring(4))];
            }
        }

        public string[] Object3DMaterialTextures
        {
            get;
            set
            {
                if (field != value)
                {
                    field = value;
                    OnPropertyChanged(nameof(Object3DMaterialTextures));
                    OnPropertyChanged(nameof(ModelTexturesPossibilities));
                }
            }
        } = [];

        public int[] ModelTexturesPossibilities
        {
            get
            {
                string texturesFolderPath = settingsService.Settings.TexturesFolderPath ?? settingsService.Settings.DefaultTexturesFolderPath;

                if (string.IsNullOrEmpty(texturesFolderPath) || !Directory.Exists(texturesFolderPath))
                    return [];

                List<int> availableAdditionalTextures = [];
                if (Object3DMaterialTextures.Length > 0)
                {
                    string textureFile = Object3DMaterialTextures[0];
                    var pattern = $"{Path.GetFileNameWithoutExtension(textureFile)}-et??{Path.GetExtension(textureFile)}";
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
                            if (!File.Exists($"{texturesFolderPath}{Path.GetFileNameWithoutExtension(materialTextureFile)}-et{textureIndex:D2}{Path.GetExtension(materialTextureFile)}"))
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
                string modelsFolderPath = settingsService.Settings.ModelsFolderPath ?? settingsService.Settings.DefaultModelsFolderPath;
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

        public Mover3DModelViewerConfig ModelViewerConfig { get; } = new();

        public List<KeyValuePair<int, string>> MoverIdentifiers => [.. definesService.ReversedMoverDefines];
        public List<KeyValuePair<int, string>> BelligerenceIdentifiers => [.. definesService.ReversedBelligerenceDefines];
        public List<KeyValuePair<int, string>> AiIdentifiers => [.. definesService.ReversedAiDefines];
        public List<KeyValuePair<int, string>> MotionIdentifiers => [.. definesService.ReversedMotionTypeDefines];
        public List<KeyValuePair<int, string>> SoundIdentifiers => [.. definesService.ReversedSoundDefines];
        public List<KeyValuePair<int, string>> RankIdentifiers => [.. definesService.ReversedRankDefines];
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
            MoversView.Filter = new Predicate<object>(FilterItem);

            settingsService.Settings.PropertyChanged += Settings_PropertyChanged;

            this._modelsDirectoryWatcher.Renamed += ModelFile_Changed;
            this._modelsDirectoryWatcher.Created += ModelFile_Changed;
            this._modelsDirectoryWatcher.Deleted += ModelFile_Changed;
            try
            {
                InitializeModelsDirectoryWatcherPath();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error during MoversViewModel models directory watcher initialization.");
            }

            this._motionDirectoryWatcher.Renamed += ModelMotionFile_Changed;
            this._motionDirectoryWatcher.Created += ModelMotionFile_Changed;
            this._motionDirectoryWatcher.Deleted += ModelMotionFile_Changed;
            try
            {
                InitializeMotionsDirectoryWatcherPath();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error during MoversViewModel motions directory watcher initialization.");
            }

            this._texturesDirectoryWatcher.Renamed += ModelTextureFile_Changed;
            this._texturesDirectoryWatcher.Created += ModelTextureFile_Changed;
            this._texturesDirectoryWatcher.Deleted += ModelTextureFile_Changed;
            try
            {
                InitializeTexturesDirectoryWatcherPath();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error during MoversViewModel textures directory watcher initialization.");
            }

            MoversView.CurrentChanging += CurrentMover_Changing;
            MoversView.CurrentChanged += CurrentMover_Changed;

            if (MoversView.CurrentItem is Mover mover)
            {
                mover.PropertyChanged += CurrentMover_PropertyChanged;
                if (mover.Model is not null)
                {
                    mover.Model.PropertyChanged += CurrentMoverModel_PropertyChanged;
                    mover.Model.MotionsView.CurrentChanged += MotionsView_CurrentChanged;
                }
            }

            _isInitialized = true;
        }

        private void InitializeModelsDirectoryWatcherPath()
        {
            this._modelsDirectoryWatcher.EnableRaisingEvents = false;
            this._modelsDirectoryWatcher.Path = settingsService.Settings.ModelsFolderPath ?? settingsService.Settings.DefaultModelsFolderPath;
            this._modelsDirectoryWatcher.EnableRaisingEvents = true;
        }

        private void InitializeTexturesDirectoryWatcherPath()
        {
            this._texturesDirectoryWatcher.EnableRaisingEvents = false;
            this._texturesDirectoryWatcher.Path = settingsService.Settings.TexturesFolderPath ?? settingsService.Settings.DefaultTexturesFolderPath;
            this._texturesDirectoryWatcher.EnableRaisingEvents = true;
        }

        private void InitializeMotionsDirectoryWatcherPath()
        {
            _motionDirectoryWatcher.EnableRaisingEvents = false;
            if (MoversView.CurrentItem is not Mover mover) return;
            if (mover.Model is null) return;
            string? prefix = Path.GetFileNameWithoutExtension(mover.Model.Model3DFilePath);
            if (prefix is null) return;
            _motionDirectoryWatcher.Path = settingsService.Settings.ModelsFolderPath ?? settingsService.Settings.DefaultModelsFolderPath;
            _motionDirectoryWatcher.Filter = $"{prefix}_*.ani";
            _motionDirectoryWatcher.EnableRaisingEvents = true;
        }

        private bool FilterItem(object obj)
        {
            if (obj is not Mover mover) return false;
            if (string.IsNullOrEmpty(SearchText)) return true;
            return mover.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase) || mover.Identifier.Contains(SearchText, StringComparison.OrdinalIgnoreCase);
        }

        #region Event handlers
        private void Settings_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(Settings.ModelsFolderPath):
                case nameof(Settings.DefaultModelsFolderPath):
                    {
                        OnPropertyChanged(nameof(ModelFilePossibilities));
                        OnPropertyChanged(nameof(ModelMotionFilePossibilities));
                        try
                        {
                            InitializeModelsDirectoryWatcherPath();
                        }
                        catch (Exception ex)
                        {
                            Log.Error(ex, "Error during MoversViewModel models directory watcher re-initialization.");
                        }
                        try
                        {
                            InitializeMotionsDirectoryWatcherPath();
                        }
                        catch (Exception ex)
                        {
                            Log.Error(ex, "Error during MoversViewModel motions directory watcher re-initialization.");
                        }
                        break;
                    }
                case nameof(Settings.TexturesFolderPath):
                case nameof(Settings.DefaultTexturesFolderPath):
                    {
                        try
                        {
                            InitializeTexturesDirectoryWatcherPath();
                        }
                        catch (Exception ex)
                        {
                            Log.Error(ex, "Error during MoversViewModel textures directory watcher re-initialization.");
                        }
                        OnPropertyChanged(nameof(ModelTexturesPossibilities));
                        break;
                    }
            }
        }

        private void ModelFile_Changed(object sender, FileSystemEventArgs e)
        {
            OnPropertyChanged(nameof(ModelFilePossibilities));
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

            if (MoversView.CurrentItem is not Mover mover)
                throw new InvalidOperationException("MoversViewModel::ModelMotionFile_Changed exception : MoversView.CurrentItem is not Mover");
            if (mover.Model is null)
                throw new InvalidOperationException("MoversViewModel::ModelMotionFile_Changed exception : mover.Model is null");
            if (mover.Model.MotionsView.CurrentItem is not ModelMotion currentMotion) return;

            string folder = settingsService.Settings.ModelsFolderPath ?? settingsService.Settings.DefaultModelsFolderPath;
            string? prefix = Path.GetFileNameWithoutExtension(mover.Model.Model3DFilePath);
            if (prefix is null) return;
            string suffix = currentMotion.SzMotion;
            string filePath = $"{folder}{prefix}_{suffix}.ani";

            if (e.FullPath == filePath || (e is RenamedEventArgs renamedEvent && renamedEvent.OldFullPath == filePath))
                StopMotion();
        }

        private void CurrentMover_Changing(object sender, CurrentChangingEventArgs e)
        {
            if (MoversView.CurrentItem is not Mover mover) return;
            mover.PropertyChanged -= CurrentMover_PropertyChanged;
            if (mover.Model is not null)
            {
                mover.Model.PropertyChanged -= CurrentMoverModel_PropertyChanged;
                mover.Model.MotionsView.CurrentChanged -= MotionsView_CurrentChanged;
            }

            StopMotion();
        }

        private void CurrentMover_Changed(object? sender, EventArgs e)
        {
            if (MoversView.CurrentItem is Mover mover)
            {
                mover.PropertyChanged += CurrentMover_PropertyChanged;
                if (mover.Model is not null)
                {
                    mover.Model.PropertyChanged += CurrentMoverModel_PropertyChanged;
                    mover.Model.MotionsView.CurrentChanged += MotionsView_CurrentChanged;
                }
            }

            OnPropertyChanged(nameof(ModelTexturesPossibilities));
            OnPropertyChanged(nameof(ModelMotionFilePossibilities));
            try
            {
                InitializeMotionsDirectoryWatcherPath();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error during MoversViewModel motions directory watcher re-initialization.");
            }
        }

        private void CurrentMover_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (sender is not Mover)
                throw new InvalidOperationException("MoversViewModel::CurrentMover_PropertyChanged exception: called with non Mover sender");
            if (MoversView.CurrentItem is not Mover mover)
                throw new InvalidOperationException("MoversViewModel::CurrentMover_PropertyChanged exception: called when MoversView currentItem is not a mover");
            if (sender != mover)
                throw new InvalidOperationException("MoversViewModel::CurrentMover_PropertyChanged exception: called with non current mover sender.");

            if (e.PropertyName == nameof(Mover.Model))
            {
                if (e is not PropertyChangedExtendedEventArgs extendedArgs) throw new InvalidOperationException("Model property changed args is not PropertyChangedExtendedEventArgs");
                if (extendedArgs.OldValue is Model oldModel)
                {
                    oldModel.PropertyChanged -= CurrentMoverModel_PropertyChanged;
                    oldModel.MotionsView.CurrentChanged -= MotionsView_CurrentChanged;
                }
                if (extendedArgs.NewValue is Model newModel)
                {
                    newModel.PropertyChanged += CurrentMoverModel_PropertyChanged;
                    newModel.MotionsView.CurrentChanged += MotionsView_CurrentChanged;
                }

                OnPropertyChanged(nameof(ModelTexturesPossibilities));
                OnPropertyChanged(nameof(ModelMotionFilePossibilities));
                try
                {
                    InitializeMotionsDirectoryWatcherPath();
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Error during MoversViewModel motions directory watcher re-initialization.");
                }
            }
        }

        private void CurrentMoverModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (sender is not Model model)
                throw new InvalidOperationException("MoversViewModel::CurrentMoverModel_PropertyChanged exception: sender is not Model");
            if (MoversView.CurrentItem is not Mover mover)
                throw new InvalidOperationException("MoversViewModel::CurrentMoverModel_PropertyChanged exception: called when MoversView currentItem is not a mover");
            if (model != mover.Model)
                throw new InvalidOperationException("MoversViewModel::CurrentMoverModel_PropertyChanged exception: called with non current mover model sender.");

            switch (e.PropertyName)
            {
                case nameof(Mover.Model.Model3DFilePath):
                    OnPropertyChanged(nameof(ModelTexturesPossibilities));
                    OnPropertyChanged(nameof(ModelMotionFilePossibilities));
                    try
                    {
                        InitializeMotionsDirectoryWatcherPath();
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex, "Error during MoversViewModel motions directory watcher re-initialization.");
                    }
                    break;
            }
        }

        private void MotionsView_CurrentChanged(object? sender, EventArgs e)
        {
            if (sender is not ICollectionView motionsView) throw new InvalidOperationException("MoversViewModel::MotionsView_CurrentChanged exception: sender is not ICollectionView");
            if (MoversView.CurrentItem is not Mover mover)
                throw new InvalidOperationException("MoversViewModel::MotionsView_CurrentChanged exception: MoversView.CurrentItem is not Mover");
            if (mover.Model is null)
                throw new InvalidOperationException("MoversViewModel::MotionsView_CurrentChanged exception: mover.Model is null");
            if (motionsView != mover.Model.MotionsView)
                throw new InvalidOperationException("MoversViewModel::MotionsView_CurrentChanged exception: sender is not equal to mover model motions view");

            StopMotion();
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
            string? modelsFolderPath = Path.GetDirectoryName(settingsService.Settings.ModelsFolderPath ?? settingsService.Settings.DefaultModelsFolderPath);

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
            MoverReferenceModelDialog contentDialog = new(contentDialogService.GetDialogHost());

            if (await contentDialog.ShowAsync() == ContentDialogResult.Primary)
            {
                if (contentDialog.DataContext is not MoverReferenceModelViewModel contentDialogViewModel) return;
                if (contentDialogViewModel.MoversView.CurrentItem is not Mover referenceMover) return;

                ModelViewerConfig.ReferenceMover = referenceMover;
            }
        }

        [RelayCommand]
        private void PlaySound(Sound? sound)
        {
            if (sound is not null)
                soundsService.PlaySound(sound);
        }

        [RelayCommand]
        private void SelectSndDmg2File()
        {
            if (MoversView.CurrentItem is not Mover mover) return;

            string initialPath = mover.SndDmg2?.FilePath ?? settingsService.Settings.SoundsFolderPath ?? settingsService.Settings.DefaultSoundsFolderPath;

            string? filePath = FileFolderSelector.SelectFile(initialPath, eTools_Ultimate.Resources.Texts.SelectSoundFile, "Sound file|*.wav");
            if (filePath is null) return;

            Sound? newSound = soundsService.Sounds.FirstOrDefault(x => x.FilePath.Equals(filePath, StringComparison.OrdinalIgnoreCase));
            if (newSound is null) return;
            mover.DwSndDmg2 = newSound.Prop.Id;
        }

        [RelayCommand]
        private void SelectSndIdle1File()
        {
            if (MoversView.CurrentItem is not Mover mover) return;

            string initialPath = mover.SndIdle1?.FilePath ?? settingsService.Settings.SoundsFolderPath ?? settingsService.Settings.DefaultSoundsFolderPath;

            string? filePath = FileFolderSelector.SelectFile(initialPath, eTools_Ultimate.Resources.Texts.SelectSoundFile, "Sound file|*.wav");
            if (filePath is null) return;

            Sound? newSound = soundsService.Sounds.FirstOrDefault(x => x.FilePath.Equals(filePath, StringComparison.OrdinalIgnoreCase));
            if (newSound is null) return;
            mover.DwSndIdle1 = newSound.Prop.Id;
        }

        [RelayCommand(CanExecute = nameof(CanOpenDropList))]
        private async Task OpenDropList(object? parameter)
        {
            if (parameter is not Mover mover) throw new InvalidOperationException("parameter is not Mover");

            MoverDropListDialog dropListDialog = new(contentDialogService.GetDialogHost(), mover);

            await dropListDialog.ShowAsync();
        }

        private static bool CanOpenDropList(object? parameter) => parameter is Mover mover && mover.Type == MoverType.MONSTER;

        [RelayCommand]
        private void AddMover()
        {
            Mover newMover = moversService.CreateMover();
            MoversView.Refresh();
            MoversView.MoveCurrentTo(newMover);
        }

        [RelayCommand]
        private async Task RemoveMover()
        {
            if (MoversView.CurrentItem is not Mover mover) return;

            ContentDialogResult result = await contentDialogService.ShowSimpleDialogAsync(
                new SimpleContentDialogCreateOptions()
                {
                    Title = localizer["Remove a mover"],
                    Content = String.Format(localizer["Are you sure you want to remove the mover {0} ?"], mover.Name),
                    PrimaryButtonText = localizer["Remove"],
                    CloseButtonText = localizer["Cancel"],
                }
            );
            if (result == ContentDialogResult.Primary)
            {
                moversService.RemoveMover(mover);
                MoversView.Refresh();
            }
        }

        [RelayCommand]
        private void AddMoverMotion()
        {
            if (MoversView.CurrentItem is not Mover mover) return;
            if (mover.Model is null) return;

            ModelMotion motion = new(Constants.NullId, "");
            mover.Model.Motions.Add(motion);
            mover.Model.MotionsView.Refresh();
            mover.Model.MotionsView.MoveCurrentTo(motion);
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
                    Title = localizer["Remove a motion"],
                    Content = String.Format(localizer["Are you sure you want to remove the motion {0} from the mover {1} ?"], motion.MotionTypeIdentifier, mover.Identifier),
                    PrimaryButtonText = localizer["Remove"],
                    CloseButtonText = localizer["Cancel"],
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

            string folderPath = settingsService.Settings.ModelsFolderPath ?? settingsService.Settings.DefaultModelsFolderPath; // Models folder path
            string filterPrefix = $"{Constants.ModelFilenameRoot[mover.Model.DwType]}_{mover.Model.SzName}_"; // Filter prefix for motion files
            string filter = $"{filterPrefix}*.ani"; // Entire filter
            string[] filePossibilities = [.. Directory.GetFiles(folderPath, filter).Select(x => Path.GetFileNameWithoutExtension(x)[filterPrefix.Length..])]; // All .ani files for this model
            string[] motionTypeDefines = [.. definesService.ReversedMotionTypeDefines.Select(x => x.Value)]; // All motion type identifiers

            int generatedCount = 0;
            foreach (string filePossibility in filePossibilities)
            {
                string potentialTypeIdentifier = $"MTI_{filePossibility}";
                string? typeIdentifier = motionTypeDefines.FirstOrDefault(x => x.Equals(potentialTypeIdentifier, StringComparison.OrdinalIgnoreCase));

                if (typeIdentifier is null) continue; // No valid motion type identifier found

                uint typeId = (uint)definesService.Defines[typeIdentifier]; // type ID from type identifier

                if (mover.Model.Motions.Any(x => x.IMotion == typeId)) continue; // Motion with this type already exists

                ModelMotion modelMotion = new(typeId, filePossibility);
                mover.Model.Motions.Add(modelMotion);
                generatedCount++;
            }

            if (generatedCount == 0)
                snackbarService.Show(
                    title: localizer["No motions generated"],
                    message: localizer["No motions could be bound automatically."],
                    appearance: ControlAppearance.Caution,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(2)
                    );
            else
                snackbarService.Show(
                    title: localizer["Motions generated"],
                    message: String.Format(localizer[generatedCount > 1 ? "{0} motions have been bound automatically." : "{0} motion has been bound automatically."], generatedCount),
                    appearance: ControlAppearance.Success,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(2)
                    );
        }

        [RelayCommand]
        private void PlayMotion()
        {
            if (MoversView.CurrentItem is not Mover mover) return;
            if (mover.Model is null) return;
            if (mover.Model.MotionsView.CurrentItem is not ModelMotion motion) return;

            ModelViewerConfig.PlayedMotion = motion;
        }

        [RelayCommand]
        private void StopMotion()
        {
            ModelViewerConfig.PlayedMotion = null;
        }

        [RelayCommand]
        private async Task Save()
        {
            try
            {
                await Task.Run(() =>
                {
                    HashSet<string> stringIdentifiers = [];
                    foreach (Mover mover in moversService.Movers)
                    {
                        stringIdentifiers.Add(mover.SzName);
                        stringIdentifiers.Add(mover.SzComment);
                    }
                    Task.WaitAll(
                        Task.Run(moversService.Save),
                        Task.Run(modelsService.Save),
                        Task.Run(() => stringsService.Save(settingsService.Settings.PropMoverTxtFilePath ?? settingsService.Settings.DefaultPropMoverTxtFilePath, [.. stringIdentifiers]))
                        );
                });

                snackbarService.Show(
                    title: localizer["Movers and motions saved"],
                    message: localizer["Movers and motions have been successfully saved."],
                    appearance: ControlAppearance.Success,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(3)
                    );
            }
            catch (Exception ex)
            {
                snackbarService.Show(
                    title: localizer["Error saving movers and motions"],
                    message: ex.Message,
                    appearance: ControlAppearance.Danger,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(3)
                    );
            }
        }

        private static bool CanCopyIdentifier(Mover mover) => mover.Identifier != mover.DwId.ToString();

        [RelayCommand(CanExecute = nameof(CanCopyIdentifier))]
        private void CopyIdentifier(Mover mover)
        {
            try
            {
                System.Windows.Clipboard.SetText(mover.Identifier);

                snackbarService.Show(
                        title: localizer["Identifier copied"],
                        message: localizer["The identifier has been copied to the clipboard."],
                        appearance: ControlAppearance.Success,
                        icon: null,
                        timeout: TimeSpan.FromSeconds(3)
                        );
            }
            catch (Exception ex)
            {
                Log.Error("Error while copying mover identifier", ex);
                snackbarService.Show(
                    title: localizer["Copy failed"],
                    message: localizer["The identifier could not be copied to the clipboard."],
                    appearance: ControlAppearance.Danger,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(3)
                    );
            }
        }

        [RelayCommand]
        private void CopyId(Mover mover)
        {
            try
            {
                System.Windows.Clipboard.SetText(mover.DwId.ToString());

                snackbarService.Show(
                        title: localizer["ID copied"],
                        message: localizer["The ID has been copied to the clipboard."],
                        appearance: ControlAppearance.Success,
                        icon: null,
                        timeout: TimeSpan.FromSeconds(3)
                        );
            }
            catch (Exception ex)
            {
                Log.Error("Error while copying mover ID", ex);
                snackbarService.Show(
                    title: localizer["Copy failed"],
                    message: localizer["The ID could not be copied to the clipboard."],
                    appearance: ControlAppearance.Danger,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(3)
                    );
            }
        }

        private static bool CanCopyNameIdentifier(Mover mover) => mover.Name != mover.SzName;

        [RelayCommand(CanExecute = nameof(CanCopyNameIdentifier))]
        private void CopyNameIdentifier(Mover mover)
        {
            try
            {
                System.Windows.Clipboard.SetText(mover.SzName);

                snackbarService.Show(
                        title: localizer["Name identifier copied"],
                        message: localizer["The name identifier has been copied to the clipboard."],
                        appearance: ControlAppearance.Success,
                        icon: null,
                        timeout: TimeSpan.FromSeconds(3)
                        );
            }
            catch (Exception ex)
            {
                Log.Error("Error while copying mover name identifier", ex);
                snackbarService.Show(
                    title: localizer["Copy failed"],
                    message: localizer["The name identifier could not be copied to the clipboard."],
                    appearance: ControlAppearance.Danger,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(3)
                    );
            }
        }

        [RelayCommand]
        private void CopyName(Mover mover)
        {
            try
            {
                System.Windows.Clipboard.SetText(mover.Name);

                snackbarService.Show(
                        title: localizer["Name copied"],
                        message: localizer["The name has been copied to the clipboard."],
                        appearance: ControlAppearance.Success,
                        icon: null,
                        timeout: TimeSpan.FromSeconds(3)
                        );
            }
            catch (Exception ex)
            {
                Log.Error("Error while copying mover name", ex);
                snackbarService.Show(
                    title: localizer["Copy failed"],
                    message: localizer["The name could not be copied to the clipboard."],
                    appearance: ControlAppearance.Danger,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(3)
                    );
            }
        }
        #endregion
    }

    public sealed partial class Mover3DModelViewerConfig : ObservableObject
    {
        [ObservableProperty]
        private Mover? _referenceMover = null;

        [ObservableProperty]
        private ModelMotion? _playedMotion = null;
    }
}
