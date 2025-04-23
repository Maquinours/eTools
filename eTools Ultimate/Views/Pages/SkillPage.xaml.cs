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
    public partial class SkillPage : System.Windows.Controls.Page, INavigableView<SkillsViewModel>
    {
        public SkillsViewModel ViewModel { get; }

        public SkillPage(SkillsViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }

        private void SkillsListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Die Logik zur Verarbeitung der Auswahländerung in der ListView
        }

        // Event-Handler für den Hinzufügen-Button
        private void AddButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                var result = System.Windows.MessageBox.Show(
                    "Would you like to add a new skill?",
                    "Add Skill",
                    System.Windows.MessageBoxButton.OKCancel,
                    System.Windows.MessageBoxImage.Information);
                
                if (result == System.Windows.MessageBoxResult.OK)
                {
                    // Hier könnte die Logik zum Hinzufügen eines neuen Skills implementiert werden
                    Console.WriteLine("Skill wird hinzugefügt");
                }
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show(
                    $"Error opening dialog: {ex.Message}",
                    "Error",
                    System.Windows.MessageBoxButton.OK,
                    System.Windows.MessageBoxImage.Error);
                
                Console.WriteLine($"Fehler: {ex.Message}\n{ex.StackTrace}");
            }
        }
        
        // Event-Handler für den Löschen-Button
        private void DeleteButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                var result = System.Windows.MessageBox.Show(
                    "Are you sure you want to permanently delete this skill?",
                    "Delete Skill",
                    System.Windows.MessageBoxButton.YesNo,
                    System.Windows.MessageBoxImage.Warning);
                
                if (result == System.Windows.MessageBoxResult.Yes)
                {
                    // Hier könnte die Logik zum Löschen des ausgewählten Skills implementiert werden
                    Console.WriteLine("Skill wird gelöscht");
                }
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show(
                    $"Error opening dialog: {ex.Message}",
                    "Error",
                    System.Windows.MessageBoxButton.OK,
                    System.Windows.MessageBoxImage.Error);
                
                Console.WriteLine($"Fehler: {ex.Message}\n{ex.StackTrace}");
            }
        }
    }
} 