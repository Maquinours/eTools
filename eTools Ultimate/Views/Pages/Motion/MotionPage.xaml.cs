using eTools_Ultimate.Services;
using eTools_Ultimate.ViewModels.Pages;
using System.Windows;
using System.Windows.Controls;
using Wpf.Ui.Abstractions.Controls;

namespace eTools_Ultimate.Views.Pages.Motion
{
    /// <summary>
    /// Interaction logic for MotionPage.xaml
    /// </summary>
    public partial class MotionPage : Page, INavigableView<MotionsViewModel>
    {
        public MotionsViewModel ViewModel { get; }
        
        public MotionPage(MotionsViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;
            
            InitializeComponent();
        }

        private void MotionsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Die Auswahl wird automatisch über das Binding aktualisiert
            // ViewModel.SelectedMotion wird durch die ListView aktualisiert
        }

        [RelayCommand]
        private void Undo()
        {
            ChangesTrackerService.Instance.Undo(ViewModel.MotionsView.CurrentItem);
        }

        [RelayCommand]
        private void Redo()
        {
            ChangesTrackerService.Instance.Redo(ViewModel.MotionsView.CurrentItem);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: implement this
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: implement this
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: implement this
        }

        //private void AddButton_Click(object sender, RoutedEventArgs e)
        //{
        //    // Eine neue Motion über das ViewModel erstellen
        //    ViewModel.AddMotionCommand.Execute(null);
        //}

        //private void SaveButton_Click(object sender, RoutedEventArgs e)
        //{
        //    // Die aktuelle Motion über das ViewModel speichern
        //    ViewModel.UpdateMotionCommand.Execute(null);
        //}

        //private void DeleteButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (MessageBox.Show("Do you really want to delete this motion?", "Delete Motion", 
        //        MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
        //    {
        //        // Die ausgewählte Motion über das ViewModel löschen
        //        ViewModel.DeleteMotionCommand.Execute(null);
        //    }
        //}
    }
} 