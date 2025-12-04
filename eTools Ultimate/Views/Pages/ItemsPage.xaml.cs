using eTools_Ultimate.Services;
using eTools_Ultimate.ViewModels.Pages;
using System.Collections.ObjectModel;
using Wpf.Ui.Abstractions.Controls;
using eTools_Ultimate.Models;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Controls;
using System.Windows;
using Wpf.Ui.Controls;
using System;

namespace eTools_Ultimate.Views.Pages
{
    public partial class ItemsPage : Page, INavigableView<ItemsViewModel>
    {
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
            catch(Exception ex)
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
            catch(Exception ex)
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
            catch(Exception ex)
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
