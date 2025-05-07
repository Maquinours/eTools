using eTools_Ultimate.Models;
using eTools_Ultimate.Services;
using eTools_Ultimate.ViewModels.Pages;
using System.Windows.Controls;
using Wpf.Ui.Abstractions.Controls;

namespace eTools_Ultimate.Views.Pages
{
    public partial class TextClientPage : Page, INavigableView<TextClientViewModel>
    {
        public TextClientViewModel ViewModel { get; }

        public TextClientPage(TextClientViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }
        private void AddButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (TextFilesListView.SelectedItem is not Text text) return;
            try
            {
                // For now, use simple MessageBox
                // Once WPF UI is properly set up, this can be replaced with ContentDialog
                var result = System.Windows.MessageBox.Show(
                    "Are you sure you want to create a new text client?",
                    "Add Item",
                    System.Windows.MessageBoxButton.OKCancel,
                    System.Windows.MessageBoxImage.Information);

                if (result == System.Windows.MessageBoxResult.OK)
                {
                    // Here the logic for adding a new item could be implemented
                    Text newText = TextsService.Instance.AddText();
                    this.ViewModel.TextsView.Refresh();
                    this.ViewModel.TextsView.MoveCurrentTo(newText);
                    this.TextFilesListView.ScrollIntoView(newText);
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
            if (TextFilesListView.SelectedItem is not Text text) return;
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
                    TextsService.Instance.RemoveText(text);
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

        private void OpenPickerButton_Click(object sender, RoutedEventArgs e)
        {
            ColorPickerPopup.IsOpen = true;
        }

        // Event handler for the Save button
        private void SaveButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (TextFilesListView.SelectedItem is not Text text) return;
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
                    // Here the logic for saving changes could be implemented
                    // TextsService.Instance.SaveChanges(text);
                    Console.WriteLine("Text is being saved");
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
    }
} 