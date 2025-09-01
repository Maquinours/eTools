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
    public partial class GiftBoxesViewModel(IContentDialogService contentDialogService, ISnackbarService snackbarService) : ObservableObject, INavigationAware
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

        [RelayCommand]
        private async Task EditGiftboxItem(GiftBoxItem item)
        {
            try
            {
                // Debug: Log that the command was called
                System.Diagnostics.Debug.WriteLine($"EditGiftboxItem command called for item: {item.Item?.Name}");

                // First, try a simple message box to test if the command is working
                var testResult = await contentDialogService.ShowSimpleDialogAsync(
                    new SimpleContentDialogCreateOptions()
                    {
                        Title = "Test",
                        Content = $"Edit command called for item: {item.Item?.Name}",
                        CloseButtonText = "OK",
                    }
                );

                System.Diagnostics.Debug.WriteLine("Test dialog shown successfully");

                // Now try the actual edit dialog using ContentDialog instead of Window
                System.Diagnostics.Debug.WriteLine("Creating EditGiftboxItemDialog as ContentDialog...");

                // Create a simple content dialog for editing
                var editResult = await contentDialogService.ShowSimpleDialogAsync(
                    new SimpleContentDialogCreateOptions()
                    {
                        Title = $"Edit {item.Item?.Name}",
                        Content = $"Editing item: {item.Item?.Name}\nQuantity: {item.Prop.NNum}\nProbability: {item.Prop.DwProbability}",
                        PrimaryButtonText = "Save",
                        CloseButtonText = "Cancel",
                    }
                );

                System.Diagnostics.Debug.WriteLine($"Edit dialog result: {editResult}");

                if (editResult == ContentDialogResult.Primary)
                {
                    // Dialog was saved, refresh the view
                    GiftboxesView.Refresh();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in EditGiftboxItem: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Stack trace: {ex.StackTrace}");

                // Show error dialog to user
                await contentDialogService.ShowSimpleDialogAsync(
                    new SimpleContentDialogCreateOptions()
                    {
                        Title = "Error",
                        Content = $"An error occurred while opening the edit dialog: {ex.Message}",
                        CloseButtonText = "OK",
                    }
                );
            }
        }

        [RelayCommand]
        private async Task Save()
        {
            try
            {
                await Task.Run(GiftBoxesService.Instance.Save);

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
