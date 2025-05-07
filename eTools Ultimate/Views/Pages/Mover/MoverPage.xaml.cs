using eTools_Ultimate.ViewModels.Pages;
using System.Windows.Controls;
using Wpf.Ui.Controls;
using Wpf.Ui;
using Wpf.Ui.Abstractions.Controls;

namespace eTools_Ultimate.Views.Pages
{
    public partial class MoverPage : Page, INavigableView<MoversViewModel>
    {
        public MoversViewModel ViewModel { get; }

        public MoverPage(MoversViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }

        private void MoversListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Diese Methode wird aufgerufen, wenn die Auswahl in der ListView geändert wird
            if (e.AddedItems.Count > 0)
            {
                var selectedItem = e.AddedItems[0];
                // Hier kann die Logik implementiert werden, um die Details des ausgewählten Items anzuzeigen
            }
        }

        private void AddButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Logik zum Hinzufügen eines neuen Mover-Elements
            // ViewModel.AddNewItem();
        }

        private void DeleteButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Logik zum Löschen des ausgewählten Mover-Elements
            if (MoversListView.SelectedItem != null)
            {
                // ViewModel.DeleteSelectedItem(MoversListView.SelectedItem);
            }
        }

        private void SaveButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                var result = System.Windows.MessageBox.Show(
                    "Do you want to save the changes?",
                    "Save",
                    System.Windows.MessageBoxButton.YesNo,
                    System.Windows.MessageBoxImage.Question);
                
                if (result == System.Windows.MessageBoxResult.Yes)
                {
                    // Here the logic for saving could be implemented
                    System.Console.WriteLine("Mover is being saved");
                }
            }
            catch(System.Exception ex)
            {
                System.Windows.MessageBox.Show(
                    $"Error saving: {ex.Message}",
                    "Error",
                    System.Windows.MessageBoxButton.OK,
                    System.Windows.MessageBoxImage.Error);
                
                System.Console.WriteLine($"Error: {ex.Message}\n{ex.StackTrace}");
            }
        }
    }
} 