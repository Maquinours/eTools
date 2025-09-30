using eTools_Ultimate.ViewModels.Pages;
using System.Windows;
using System.Windows.Controls;
using Wpf.Ui.Abstractions.Controls;

namespace eTools_Ultimate.Views.Pages
{
    public partial class GiftboxesPage : Page, INavigableView<GiftBoxesViewModel>
    {
        public GiftBoxesViewModel ViewModel { get; }

        public GiftboxesPage(GiftBoxesViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = viewModel;

            InitializeComponent();
        }

        private void GiftboxListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            var listView = sender as ListView;
            if (listView != null && listView.SelectedItem != null)
            {

            }
        }
    }
} 