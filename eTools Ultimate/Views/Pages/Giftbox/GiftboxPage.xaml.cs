using eTools_Ultimate.ViewModels.Pages;
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
    }
} 