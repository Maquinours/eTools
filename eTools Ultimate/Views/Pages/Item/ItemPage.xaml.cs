using eTools_Ultimate.Services;
using eTools_Ultimate.ViewModels.Pages;
using System.Collections.ObjectModel;
using Wpf.Ui.Abstractions.Controls;
using eTools_Ultimate.Models;

namespace eTools_Ultimate.Views.Pages
{
    public partial class ItemPage : INavigableView<DataViewModel>
    {
        public DataViewModel ViewModel { get; }

        public ObservableCollection<Item> Items => ItemsService.Instance.Items;

        public ItemPage(DataViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void VirtualizingGridView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
