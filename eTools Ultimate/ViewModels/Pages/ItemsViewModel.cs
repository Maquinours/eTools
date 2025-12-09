using CommunityToolkit.Mvvm.ComponentModel;
using eTools_Ultimate.Helpers;
using eTools_Ultimate.Models;
using eTools_Ultimate.Models.Items;
using eTools_Ultimate.Models.Movers;
using eTools_Ultimate.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Media;
using Wpf.Ui.Abstractions.Controls;

namespace eTools_Ultimate.ViewModels.Pages
{
    public partial class ItemsViewModel(ItemsService itemsService, DefinesService definesService, SoundsService soundsService, SettingsService settingsService) : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;

        private string _searchText = string.Empty;

        [ObservableProperty]
        private ICollectionView _itemsView = CollectionViewSource.GetDefaultView(itemsService.Items);

        public string[] ItemIdentifiers => [.. definesService.ReversedItemDefines.Values];
        public List<KeyValuePair<int, string>> JobIdentifiers => [.. definesService.ReversedJobDefines];
        public List<KeyValuePair<int, string>> PartsIdentifiers => [.. definesService.ReversedPartsDefines];
        public string[] DestIdentifiers => [.. definesService.ReversedDestDefines.Values];
        public string[] WeaponTypeIdentifiers => [.. definesService.ReversedWeaponTypeDefines.Values];
        public string[] AttackRangeIdentifiers => [.. definesService.ReversedAttackRangeDefines.Values];
        public string[] SfxIdentifiers => [.. definesService.ReversedSfxDefines.Values];
        public string[] SoundIdentifiers => [.. definesService.ReversedSoundDefines.Values];
        public string[] HandedIdentifiers => [.. definesService.ReversedHandedDefines.Values];
        public bool HasExpandedDestValues => settingsService.Settings.ResourcesVersion >= 19 || settingsService.Settings.FilesFormat == FilesFormats.Florist;

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

            _isInitialized = true;
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
    }
}
