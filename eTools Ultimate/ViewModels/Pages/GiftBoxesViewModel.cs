using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using eTools_Ultimate.Models;
using eTools_Ultimate.Services;
using eTools_Ultimate.ViewModels.Controls.Dialogs;
using eTools_Ultimate.Views.Dialogs;
using eTools_Ultimate.Views.Pages;
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
    public partial class GiftBoxesViewModel(IContentDialogService contentDialogService, ISnackbarService snackbarService, GiftBoxesService giftBoxesService) : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;

        private string _searchText = string.Empty;

        [ObservableProperty]
        private ICollectionView _giftboxesView = CollectionViewSource.GetDefaultView(giftBoxesService.GiftBoxes);

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
        private async Task AddGiftboxItem()
        {
            if (GiftboxesView.CurrentItem is not GiftBox giftbox) return;

            var contentDialog = new AddGiftboxItemDialog(contentDialogService.GetDialogHost());

            if (await contentDialog.ShowAsync() == ContentDialogResult.Primary)
            {
                if (contentDialog.DataContext is not AddGiftBoxItemDialogViewModel contentDialogViewModel) return;

                if (contentDialogViewModel.ItemsView.CurrentItem is not Item item) return;

                int quantity = contentDialogViewModel.Quantity;
                int probability = (int)(contentDialogViewModel.Probability / 100d * 1_000_000);

                GiftBoxItemProp giftBoxItemProp = new(dwItem: item.Prop.DwId, dwProbability: probability, nNum: quantity);
                GiftBoxItem giftBoxItem = new(giftBoxItemProp);

                giftbox.Items.Add(giftBoxItem);
            }
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

            if (result == ContentDialogResult.Primary)
            {
                giftbox.Items.Remove(item);
                item.Dispose();
            }
        }

        // TODO: add & remove giftbox

        [RelayCommand]
        private async Task Save()
        {
            try
            {
                await Task.Run(giftBoxesService.Save);

                snackbarService.Show(
                    title: "GiftBoxes saved",
                    message: "GiftBoxes have been successfully saved.",
                    appearance: ControlAppearance.Success,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(3)
                    );
            }
            catch (Exception ex)
            {
                snackbarService.Show(
                    title: "An error has occured while saving GiftBoxes",
                    message: ex.Message,
                    appearance: ControlAppearance.Danger,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(3)
                    );
            }
        }
    }
}
