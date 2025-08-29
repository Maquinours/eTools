using eTools_Ultimate.ViewModels.Pages;
using System.Windows;
using System.Windows.Controls;
using Wpf.Ui.Abstractions.Controls;

namespace eTools_Ultimate.Views.Pages
{
    public partial class GiftboxPage : Page, INavigableView<GiftBoxesViewModel>
    {
        public GiftBoxesViewModel ViewModel { get; }

        public GiftboxPage(GiftBoxesViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }

        private void GiftboxListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            var listView = sender as ListView;
            if (listView != null && listView.SelectedItem != null)
            {

            }
        }

        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            var addDialog = new AddGiftboxItemDialog();
            addDialog.Owner = Window.GetWindow(this);
            
            if (addDialog.ShowDialog() == true)
            {
            }
        }

        private void EditItemButton_Click(object sender, RoutedEventArgs e)
        {
            var editDialog = new EditGiftboxItemDialog();
            editDialog.Owner = Window.GetWindow(this);
            
            if (editDialog.ShowDialog() == true)
            {

            }
        }
    }
} 