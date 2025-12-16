using eTools_Ultimate.Helpers;
using eTools_Ultimate.Models;
using eTools_Ultimate.Models.Items;
using eTools_Ultimate.Models.Movers;
using eTools_Ultimate.Services;
using eTools_Ultimate.ViewModels.Controls.Dialogs;
using eTools_Ultimate.ViewModels.Pages;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Interop;
using Wpf.Ui.Abstractions.Controls;
using Wpf.Ui.Controls;

namespace eTools_Ultimate.Views.Pages
{
    public partial class ItemsPage : Page, INavigableView<ItemsViewModel>
    {
        private Point _lastMousePosition;
        private bool _isMouseDragging = false;

        public ItemsViewModel ViewModel { get; }

        public ItemsPage(ItemsViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = viewModel;

            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
        }

        private void VirtualizingGridView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
        }

        private void ItemsListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Handle selection change if needed
        }

        // Event handler for the Add button
        private void AddButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                // For now, use simple MessageBox
                // Once WPF UI is properly set up, this can be replaced with ContentDialog
                var result = System.Windows.MessageBox.Show(
                    "Test",
                    "Add Item",
                    System.Windows.MessageBoxButton.OKCancel,
                    System.Windows.MessageBoxImage.Information);

                if (result == System.Windows.MessageBoxResult.OK)
                {
                    // Here the logic for adding a new item could be implemented
                    Console.WriteLine("Item is being added");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(
                    $"Error opening dialog: {ex.Message}",
                    "Error",
                    System.Windows.MessageBoxButton.OK,
                    System.Windows.MessageBoxImage.Error);

                Console.WriteLine($"Error: {ex.Message}\n{ex.StackTrace}");
            }
        }

        // Event handler for the Delete button
        private void DeleteButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                // For now, use simple MessageBox
                // Once WPF UI is properly set up, this can be replaced with ContentDialog
                var result = System.Windows.MessageBox.Show(
                    "Are you sure you want to permanently delete this item?",
                    "Delete Item",
                    System.Windows.MessageBoxButton.YesNo,
                    System.Windows.MessageBoxImage.Warning);

                if (result == System.Windows.MessageBoxResult.Yes)
                {
                    // Here the logic for deleting the selected item could be implemented
                    Console.WriteLine("Item is being deleted");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(
                    $"Error opening dialog: {ex.Message}",
                    "Error",
                    System.Windows.MessageBoxButton.OK,
                    System.Windows.MessageBoxImage.Error);

                Console.WriteLine($"Error: {ex.Message}\n{ex.StackTrace}");
            }
        }

        // Event handler for the Save button
        private void SaveButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                // For now, use simple MessageBox
                // Once WPF UI is properly set up, this can be replaced with ContentDialog
                var result = System.Windows.MessageBox.Show(
                    "Do you want to save the changes?",
                    "Save",
                    System.Windows.MessageBoxButton.YesNo,
                    System.Windows.MessageBoxImage.Question);

                if (result == System.Windows.MessageBoxResult.Yes)
                {
                    // Here the logic for saving the item could be implemented
                    Console.WriteLine("Item is being saved");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(
                    $"Error saving: {ex.Message}",
                    "Error",
                    System.Windows.MessageBoxButton.OK,
                    System.Windows.MessageBoxImage.Error);

                Console.WriteLine($"Error: {ex.Message}\n{ex.StackTrace}");
            }
        }

        private void BuffGiftedItemAutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason != AutoSuggestionBoxTextChangeReason.UserInput) return;

            ViewModel.RefreshBuffGiftedItemSuggestions(args.Text);
            args.Handled = true;
        }

        private void BuffGiftedItemAutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            if (args.SelectedItem is not Item selectedItem) return;

            sender.Text = selectedItem.Identifier;
            args.Handled = true;
        }

        private void PetMoverAutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason != AutoSuggestionBoxTextChangeReason.UserInput) return;

            ViewModel.RefreshPetMoverSuggestions(args.Text);
            args.Handled = true;
        }

        private void PetMoverAutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            if (args.SelectedItem is not Mover selectedMover) return;

            sender.Text = selectedMover.Identifier;
            args.Handled = true;
        }

        private void GuildHouseNpcMoverAutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason != AutoSuggestionBoxTextChangeReason.UserInput) return;

            ViewModel.RefreshGuildHouseNpcMoverSuggestions(args.Text);
            args.Handled = true;
        }

        private void GuildHouseNpcMoverAutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            if (args.SelectedItem is not Mover selectedMover) return;

            sender.Text = selectedMover.Identifier;
            args.Handled = true;
        }

        private void GuildHouseNpcCharacterAutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason != AutoSuggestionBoxTextChangeReason.UserInput) return;

            ViewModel.RefreshGuildHouseNpcCharacterSuggestions(args.Text);
            args.Handled = true;
        }

        private void GuildHouseNpcCharacterAutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            if (args.SelectedItem is not Character selectedMover) return;

            sender.Text = selectedMover.SzKey;
            args.Handled = true;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var hwnd = new WindowInteropHelper(Window.GetWindow(this)).Handle;

            ViewModel.InitializeD3DHost(hwnd);
        }

        private void ModelViewerImage_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var currentPosition = e.GetPosition(null);
            _isMouseDragging = true;
            _lastMousePosition = currentPosition;
        }

        private void ModelViewerImage_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            if (ViewModel.D3DHost is null) return;

            ViewModel.D3DHost.Zoom(e.Delta);

            //if (!ViewModel.Auto3DRendering)
            ViewModel.D3DHost.Render();

            e.Handled = true;
        }

        private void Page_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (!_isMouseDragging) return;
            if (ViewModel.D3DHost is null) return;

            Point mousePosition = e.GetPosition(null);
            Vector deltaPosition = _lastMousePosition - mousePosition;

            NativeMethods.RotateCamera(ViewModel.D3DHost._native, (int)(deltaPosition.X), (int)(deltaPosition.Y));

            _lastMousePosition = mousePosition;
            //if (!ViewModel.Auto3DRendering)
            ViewModel.D3DHost.Render();
        }

        private void Page_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _isMouseDragging = false;
        }
    }
}
