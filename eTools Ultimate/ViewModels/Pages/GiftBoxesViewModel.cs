using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using eTools_Ultimate.Models.GiftBoxes;
using eTools_Ultimate.Models.Items;
using eTools_Ultimate.Resources;
using eTools_Ultimate.Services;
using eTools_Ultimate.ViewModels.Controls.Dialogs;
using eTools_Ultimate.Views.Dialogs;
using eTools_Ultimate.Views.Pages;
using Microsoft.Extensions.Localization;
using Serilog;
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
    public partial class GiftBoxesViewModel(IContentDialogService contentDialogService, ISnackbarService snackbarService, IStringLocalizer<Translations> localizer, GiftBoxesService giftBoxesService) : ObservableObject, INavigationAware
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
            if (obj is not Giftbox giftbox) return false;
            if (string.IsNullOrEmpty(this.SearchText)) return true;
            Item? item = giftbox.Item;
            return item == null || item.Name.ToLower().Contains(this.SearchText.ToLower());
        }

        [RelayCommand]
        private async Task AddGiftbox()
        {
            AddGiftboxDialog contentDialog = new(contentDialogService.GetDialogHost());

            if (await contentDialog.ShowAsync() == ContentDialogResult.Primary)
            {
                if (contentDialog.DataContext is not AddGiftboxDialogViewModel contentDialogViewModel) throw new InvalidOperationException("GiftboxesViewModel::AddGiftbox exception : contentDialog.DataContext is not AddGiftboxDialogViewModel");
                if (contentDialogViewModel.ItemsView.CurrentItem is not Item item) return;
                if (giftBoxesService.GiftBoxes.Any(gb => gb.DwItem == item.DwId)) return;

                Giftbox giftbox = giftBoxesService.NewGiftbox(item);

                GiftboxesView.Refresh();
                GiftboxesView.MoveCurrentTo(giftbox);
            }
        }

        [RelayCommand]
        private async Task RemoveGiftbox()
        {
            if (GiftboxesView.CurrentItem is not Giftbox giftbox) return;

            ContentDialogResult result = await contentDialogService.ShowSimpleDialogAsync(
                 new SimpleContentDialogCreateOptions()
                 {
                     Title = localizer["Remove giftbox"],
                     Content = String.Format(localizer["Are you sure you want to remove the giftbox {0} ?"], giftbox.Item?.Name),
                     PrimaryButtonText = localizer["Remove"],
                     CloseButtonText = localizer["Cancel"],
                 }
                );
            if (result == ContentDialogResult.Primary)
                giftBoxesService.RemoveGiftbox(giftbox);
        }

        [RelayCommand]
        private async Task AddGiftboxItem()
        {
            if (GiftboxesView.CurrentItem is not Giftbox giftbox) return;

            var contentDialog = new AddGiftboxItemDialog(contentDialogService.GetDialogHost());

            if (await contentDialog.ShowAsync() == ContentDialogResult.Primary)
            {
                if (contentDialog.DataContext is not AddGiftBoxItemDialogViewModel contentDialogViewModel) return;

                if (contentDialogViewModel.ItemsView.CurrentItem is not Item item) return;

                int quantity = contentDialogViewModel.Quantity;
                uint probability = (uint)(contentDialogViewModel.Probability / 100d * 1_000_000);

                GiftboxItem giftBoxItem = new(dwItem: item.DwId, dwProbability: probability, nNum: quantity);

                giftbox.Items.Add(giftBoxItem);
            }
        }

        [RelayCommand]
        private async Task RemoveGiftboxItem(GiftboxItem item)
        {
            if (GiftboxesView.CurrentItem is not Giftbox giftbox) return;
            if (!giftbox.Items.Contains(item)) return;

            ContentDialogResult result = await contentDialogService.ShowSimpleDialogAsync(
                 new SimpleContentDialogCreateOptions()
                 {
                     Title = localizer["Remove giftbox item"],
                     Content = String.Format(localizer["Are you sure you want to remove the item {0} from the giftbox {1} ?"], item.Item?.Name, giftbox.Item?.Name),
                     PrimaryButtonText = localizer["Remove"],
                     CloseButtonText = localizer["Cancel"],
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
                    title: localizer["Giftboxes saved"],
                    message: localizer["Giftboxes have been successfully saved."],
                    appearance: ControlAppearance.Success,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(3)
                    );
            }
            catch (Exception ex)
            {
                snackbarService.Show(
                    title: localizer["Error saving giftboxes"],
                    message: ex.Message,
                    appearance: ControlAppearance.Danger,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(3)
                    );
            }
        }

        private static bool CanCopyItemIdentifier(Giftbox giftbox) => giftbox.ItemIdentifier != giftbox.DwItem.ToString();

        [RelayCommand(CanExecute = nameof(CanCopyItemIdentifier))]
        private void CopyItemIdentifier(Giftbox giftbox)
        {
            try
            {
                System.Windows.Clipboard.SetText(giftbox.ItemIdentifier);

                snackbarService.Show(
                        title: localizer["Item identifier copied"],
                        message: localizer["The item identifier has been copied to the clipboard."],
                        appearance: ControlAppearance.Success,
                        icon: null,
                        timeout: TimeSpan.FromSeconds(3)
                        );
            }
            catch (Exception ex)
            {
                Log.Error("Error while copying giftbox item identifier", ex);
                snackbarService.Show(
                    title: localizer["Copy failed"],
                    message: localizer["The item identifier could not be copied to the clipboard."],
                    appearance: ControlAppearance.Danger,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(3)
                    );
            }
        }

        [RelayCommand]
        private void CopyItemId(Giftbox giftbox)
        {
            try
            {
                System.Windows.Clipboard.SetText(giftbox.DwItem.ToString());

                snackbarService.Show(
                        title: localizer["Item ID copied"],
                        message: localizer["The item ID has been copied to the clipboard."],
                        appearance: ControlAppearance.Success,
                        icon: null,
                        timeout: TimeSpan.FromSeconds(3)
                        );
            }
            catch (Exception ex)
            {
                Log.Error("Error while copying giftbox item ID", ex);
                snackbarService.Show(
                    title: localizer["Copy failed"],
                    message: localizer["The item ID could not be copied to the clipboard."],
                    appearance: ControlAppearance.Danger,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(3)
                    );
            }
        }

        private static bool CanCopyItemNameIdentifier(Giftbox giftbox) => giftbox.Item != null && giftbox.Item.Name != giftbox.Item.SzName;

        [RelayCommand(CanExecute = nameof(CanCopyItemNameIdentifier))]
        private void CopyItemNameIdentifier(Giftbox giftbox)
        {
            try
            {
                System.Windows.Clipboard.SetText(giftbox.Item?.SzName ?? "");

                snackbarService.Show(
                        title: localizer["Item name identifier copied"],
                        message: localizer["The item name identifier has been copied to the clipboard."],
                        appearance: ControlAppearance.Success,
                        icon: null,
                        timeout: TimeSpan.FromSeconds(3)
                        );
            }
            catch (Exception ex)
            {
                Log.Error("Error while copying giftbox item name", ex);
                snackbarService.Show(
                    title: localizer["Copy failed"],
                    message: localizer["The item name could not be copied to the clipboard."],
                    appearance: ControlAppearance.Danger,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(3)
                    );
            }
        }

        private static bool CanCopyItemName(Giftbox giftbox) => giftbox.Item != null;

        [RelayCommand(CanExecute = nameof(CanCopyItemName))]
        private void CopyItemName(Giftbox giftbox)
        {
            try
            {
                System.Windows.Clipboard.SetText(giftbox.Item?.Name ?? "");

                snackbarService.Show(
                        title: localizer["Item name copied"],
                        message: localizer["The item name has been copied to the clipboard."],
                        appearance: ControlAppearance.Success,
                        icon: null,
                        timeout: TimeSpan.FromSeconds(3)
                        );
            }
            catch (Exception ex)
            {
                Log.Error("Error while copying giftbox item name", ex);
                snackbarService.Show(
                    title: localizer["Copy failed"],
                    message: localizer["The item name could not be copied to the clipboard."],
                    appearance: ControlAppearance.Danger,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(3)
                    );
            }
        }
    }
}
