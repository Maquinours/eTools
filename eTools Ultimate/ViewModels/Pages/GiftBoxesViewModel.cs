using eTools_Ultimate.Models;
using eTools_Ultimate.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
    public partial class GiftBoxesViewModel(IContentDialogService contentDialogService) : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;

        private string _searchText = string.Empty;

        [ObservableProperty]
        private ICollectionView _giftboxesView = CollectionViewSource.GetDefaultView(GiftBoxesService.Instance.GiftBoxes);

        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged(nameof(this.SearchText));
                    GiftboxesView.Refresh();
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
            GiftboxesView.Filter = new Predicate<object>(FilterItem);

            _isInitialized = true;
        }

        private bool FilterItem(object obj)
        {
            if (obj is not GiftBox giftbox) return false;
            if (string.IsNullOrEmpty(this.SearchText)) return true;
            Item? item = giftbox.Item;
            return item == null || item.Name.ToLower().Contains(this.SearchText.ToLower());
        }

        [RelayCommand]
        private async Task RemoveGiftboxItem(GiftBoxItem item)
        {
            if (GiftboxesView.CurrentItem is not GiftBox giftbox) return;
            if (!giftbox.Items.Contains(item)) return;

            ContentDialogResult result = await contentDialogService.ShowSimpleDialogAsync(
                 new SimpleContentDialogCreateOptions()
                 {
                     Title = "Remove giftbox item",
                     Content = $"Are you sure you want to remove {item.Item?.Name} from the giftbox {giftbox.Item?.Name} ?",
                     PrimaryButtonText = "Remove",
                     CloseButtonText = "Cancel",
                 }
                );

            if(result == ContentDialogResult.Primary)
            {
                giftbox.Items.Remove(item);
                item.Dispose();
            }
        }
    }
}
