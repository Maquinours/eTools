using CommunityToolkit.Mvvm.ComponentModel;
using eTools_Ultimate.Helpers;
using eTools_Ultimate.Models;
using eTools_Ultimate.Models.Items;
using eTools_Ultimate.Models.Models;
using eTools_Ultimate.Models.Movers;
using eTools_Ultimate.Properties;
using eTools_Ultimate.Resources;
using eTools_Ultimate.Services;
using Microsoft.Extensions.Localization;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Windows.Data;
using System.Windows.Media;
using Wpf.Ui.Abstractions.Controls;

namespace eTools_Ultimate.ViewModels.Pages
{
    public partial class ItemsViewModel(ItemsService itemsService, MoversService moversService, CharactersService charactersService, DefinesService definesService, SoundsService soundsService, SettingsService settingsService, IStringLocalizer<Translations> localizer) : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;

        private FileSystemWatcher _modelFilesWatcher;

        private string _searchText = string.Empty;

        [ObservableProperty]
        private ICollectionView _itemsView = CollectionViewSource.GetDefaultView(itemsService.Items);

        [ObservableProperty]
        private Item[] _buffGiftedItemSuggestions = [];

        [ObservableProperty]
        private Mover[] _petMoverSuggestions = [];

        [ObservableProperty]
        private Mover[] _guildHouseNpcMoverSuggestions = [];

        [ObservableProperty]
        private Character[] _guildHouseNpcCharacterSuggestions = [];

        public ItemD3DImageHost? D3DHost
        {
            get; private set
            {
                if (field == value)
                    return;

                field = value;
                OnPropertyChanged(nameof(D3DHost));
            }
        } = null;

        public string[] ItemIdentifiers => [.. definesService.ReversedItemDefines.Values];
        public List<KeyValuePair<int, string>> JobIdentifiers => [.. definesService.ReversedJobDefines];
        public List<KeyValuePair<int, string>> PartsIdentifiers => [.. definesService.ReversedPartsDefines];
        public string[] DestIdentifiers => [.. definesService.ReversedDestDefines.Values];
        public string[] WeaponTypeIdentifiers => [.. definesService.ReversedWeaponTypeDefines.Values];
        public string[] AttackRangeIdentifiers => [.. definesService.ReversedAttackRangeDefines.Values];
        public string[] SfxIdentifiers => [.. definesService.ReversedSfxDefines.Values];
        public string[] SoundIdentifiers => [.. definesService.ReversedSoundDefines.Values];
        public string[] HandedIdentifiers => [.. definesService.ReversedHandedDefines.Values];
        public string[] ControlIdentifiers => [.. definesService.ReversedControlDefines.Values];
        public string[] AngelElementalIdentifiers => [.. definesService.ReversedElementalDefines.Values.Where(x => x.StartsWith("ELEMENTAL_ANGEL_"))];
        public bool HasExpandedDestValues => settingsService.Settings.ResourcesVersion >= 19 || settingsService.Settings.FilesFormat == FilesFormats.Florist;
        public string[] AngelModelFileNamePossibilities
        {
            get
            {
                string modelsFolderPath = settingsService.Settings.ModelsFolderPath ?? settingsService.Settings.DefaultModelsFolderPath;
                string[] modelFiles = Directory.GetFiles(modelsFolderPath, "*.o3d", SearchOption.TopDirectoryOnly);

                List<string> results = [];

                foreach (string modelFile in modelFiles)
                {
                    string? modelFileNameWithoutExtension = Path.GetFileNameWithoutExtension(modelFile);
                    if (modelFileNameWithoutExtension == null) continue;
                    string[] requiredFiles = [.. Constants.AngelModelFilesFormats.Select(x => Path.Combine(modelsFolderPath, String.Format(x, modelFileNameWithoutExtension)))];
                    if (requiredFiles.All(File.Exists))
                        results.Add(modelFileNameWithoutExtension);
                }

                return [.. results];
            }
        }

        public string[] ModelFilePossibilities
        {
            get
            {
                string modelsFolderPath = settingsService.Settings.ModelsFolderPath ?? settingsService.Settings.DefaultModelsFolderPath;
                if (string.IsNullOrEmpty(modelsFolderPath) || !Directory.Exists(modelsFolderPath))
                    return [];
                return [.. Directory.GetFiles(modelsFolderPath, "item_*.o3d", SearchOption.TopDirectoryOnly).Select(x => Path.GetFileNameWithoutExtension(x).Substring(5))];
            }
        }

        public int[] ModelTexturePossibilities
        {
            get
            {
                string texturesFolderPath = settingsService.Settings.TexturesFolderPath ?? settingsService.Settings.DefaultTexturesFolderPath;

                if (D3DHost == null || string.IsNullOrEmpty(texturesFolderPath) || !Directory.Exists(texturesFolderPath))
                    return [];

                List<int> availableAdditionalTextures = [];
                if (D3DHost.MaterialTextures.Length > 0)
                {
                    string textureFile = D3DHost.MaterialTextures[0];
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
                        foreach (string materialTextureFile in D3DHost.MaterialTextures)
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

        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged(nameof(this.SearchText));
                    ItemsView.Refresh();
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
            ItemsView.Filter = new Predicate<object>(FilterItem);

            ItemsView.CurrentChanged += ItemsView_CurrentChanged;
            ItemsView.CurrentChanging += ItemsView_CurrentChanging;

            InitializeModelsFileWatcher();

            _isInitialized = true;
        }

        private void ItemsView_CurrentChanging(object sender, CurrentChangingEventArgs e)
        {
            if (sender != ItemsView)
                throw new InvalidOperationException("sender != ItemsView");

            if (ItemsView.CurrentItem is Item currentItem)
                currentItem.PropertyChanged -= CurrentItem_PropertyChanged;
        }

        private void ItemsView_CurrentChanged(object? sender, EventArgs e)
        {
            if(sender != ItemsView)
                throw new InvalidOperationException("sender != ItemsView");

            if (ItemsView.CurrentItem is Item currentItem)
            {
                currentItem.PropertyChanged += CurrentItem_PropertyChanged;
                D3DHost?.CurrentModel = currentItem.Model;
            }
        }

        private void CurrentItem_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (ItemsView.CurrentItem is not Item currentItem)
                throw new InvalidOperationException("ItemsView.CurrentItem is not Item");
            if (sender != currentItem)
                throw new InvalidOperationException("sender != currentItem");

            switch (e.PropertyName)
            {
                case nameof(Item.Model):
                    D3DHost?.CurrentModel = currentItem.Model;
                    break;
            }
        }

        [MemberNotNull(nameof(_modelFilesWatcher))]
        private void InitializeModelsFileWatcher()
        {
            if (_modelFilesWatcher != null)
                throw new InvalidOperationException("_modelFilesWatcher is not null");

            string modelsFolderPath = settingsService.Settings.ModelsFolderPath ?? settingsService.Settings.DefaultModelsFolderPath;

            _modelFilesWatcher = new()
            {
                Path = Path.GetDirectoryName(modelsFolderPath) ?? throw new InvalidOperationException("Path.GetDirectoryName(iconFilePath) is null"),
                NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName
            };
            _modelFilesWatcher.Changed += (_, __) => OnPropertyChanged(nameof(AngelModelFileNamePossibilities));
            _modelFilesWatcher.Deleted += (_, __) => OnPropertyChanged(nameof(AngelModelFileNamePossibilities));
            _modelFilesWatcher.Renamed += (_, __) => OnPropertyChanged(nameof(AngelModelFileNamePossibilities));
        }

        public void InitializeD3DHost(nint hwnd)
        {
            D3DHost = new(hwnd, localizer);
            D3DHost.Initialize(hwnd);
            D3DHost.BindBackBuffer();

            D3DHost.PropertyChanged += D3DHost_PropertyChanged;

            if (ItemsView.CurrentItem is Item currentItem && currentItem.Model is Model currentModel)
                D3DHost.CurrentModel = currentModel;
        }

        private void D3DHost_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (sender != D3DHost)
                throw new InvalidOperationException("sender != D3DHost");
            if (D3DHost is null)
                throw new InvalidOperationException("D3DHost is null");

            switch(e.PropertyName)
            {
                case nameof(D3DHost.MaterialTextures):
                    OnPropertyChanged(nameof(ModelTexturePossibilities));
                    break;
            }
        }

        private bool FilterItem(object obj)
        {
            if (obj is not Item item) return false;
            if (string.IsNullOrEmpty(this.SearchText)) return true;
            string lowerSearch = this.SearchText.ToLower();
            return item.Name.Contains(lowerSearch, StringComparison.OrdinalIgnoreCase)
                //|| DefinesService.Instance.Defines.FirstOrDefault(x => x.Key.StartsWith("II_") && x.Value == item.Id).Key.Contains(lowerSearch, StringComparison.OrdinalIgnoreCase)
                ;
        }

        public void RefreshBuffGiftedItemSuggestions(string searchText)
        {
            List<Item> newSuggestions = [];

            foreach (Item item in itemsService.Items)
            {
                if (item.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase) || item.Identifier.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                    newSuggestions.Add(item);
            }

            BuffGiftedItemSuggestions = [.. newSuggestions];
        }

        public void RefreshPetMoverSuggestions(string searchText)
        {
            List<Mover> newSuggestions = [];

            foreach (Mover mover in moversService.Movers)
            {
                if (mover.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase) || mover.Identifier.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                    newSuggestions.Add(mover);
            }

            PetMoverSuggestions = [.. newSuggestions];
        }

        public void RefreshGuildHouseNpcMoverSuggestions(string searchText)
        {
            List<Mover> newSuggestions = [];

            foreach (Mover mover in moversService.Movers)
            {
                if (mover.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase) || mover.Identifier.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                    newSuggestions.Add(mover);
            }

            GuildHouseNpcMoverSuggestions = [.. newSuggestions];
        }

        public void RefreshGuildHouseNpcCharacterSuggestions(string searchText)
        {
            List<Character> newSuggestions = [];

            foreach (Character character in charactersService.Characters)
            {
                if (character.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase) || character.SzKey.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                    newSuggestions.Add(character);
            }

            GuildHouseNpcCharacterSuggestions = [.. newSuggestions];
        }

        [RelayCommand]
        private void PlaySound(uint soundId)
        {
            Sound? sound = soundsService.Sounds.FirstOrDefault(x => x.Prop.Id == soundId);

            if (sound == null) return;

            soundsService.PlaySound(sound);
        }

        [RelayCommand]
        private void SelectSndAttack1File()
        {
            if (ItemsView.CurrentItem is not Item item) return;

            Sound? initialSound = soundsService.Sounds.FirstOrDefault(x => x.Prop.Id == item.DwSndAttack1);

            string initialPath = initialSound?.FilePath ?? settingsService.Settings.SoundsFolderPath ?? settingsService.Settings.DefaultSoundsFolderPath;

            string? filePath = FileFolderSelector.SelectFile(initialPath, eTools_Ultimate.Resources.Texts.SelectSoundFile, "Sound file|*.wav");
            if (filePath is null) return;

            Sound? newSound = soundsService.Sounds.FirstOrDefault(x => x.FilePath.Equals(filePath, StringComparison.OrdinalIgnoreCase));
            if (newSound is null) return;
            item.DwSndAttack1 = newSound.Prop.Id;
        }

        [RelayCommand]
        private void SelectSndAttack2File()
        {
            if (ItemsView.CurrentItem is not Item item) return;

            Sound? initialSound = soundsService.Sounds.FirstOrDefault(x => x.Prop.Id == item.DwSndAttack2);

            string initialPath = initialSound?.FilePath ?? settingsService.Settings.SoundsFolderPath ?? settingsService.Settings.DefaultSoundsFolderPath;

            string? filePath = FileFolderSelector.SelectFile(initialPath, eTools_Ultimate.Resources.Texts.SelectSoundFile, "Sound file|*.wav");
            if (filePath is null) return;

            Sound? newSound = soundsService.Sounds.FirstOrDefault(x => x.FilePath.Equals(filePath, StringComparison.OrdinalIgnoreCase));
            if (newSound is null) return;
            item.DwSndAttack2 = newSound.Prop.Id;
        }

        [RelayCommand]
        private void SelectPaperingTextureFile()
        {
            if (ItemsView.CurrentItem is not Item item) return;

            string initialFolderPath = settingsService.Settings.TexturesFolderPath ?? settingsService.Settings.DefaultTexturesFolderPath;
            string initialPath = Path.Combine(initialFolderPath, item.SzTextFileName);

            string? filePath = FileFolderSelector.SelectFile(initialPath, "", "Images|*.png;*.jpg;*.jpeg;*.bmp;*.dds");

            string? folderPath = Path.GetDirectoryName(filePath);
            string? fileName = Path.GetFileName(filePath);
            string? initialDirectoryPath = Path.GetDirectoryName(initialFolderPath);


            if (folderPath == null || fileName == null || initialDirectoryPath == null || !folderPath.Equals(initialDirectoryPath, StringComparison.OrdinalIgnoreCase))
                return;

            item.SzTextFileName = fileName;
        }
    }
}
