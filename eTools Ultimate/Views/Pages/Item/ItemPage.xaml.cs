using eTools_Ultimate.Services;
using eTools_Ultimate.ViewModels.Pages;
using System.Collections.ObjectModel;
using Wpf.Ui.Abstractions.Controls;
using eTools_Ultimate.Models;
using System.ComponentModel;
using System.Windows.Data;

namespace eTools_Ultimate.Views.Pages
{
    public partial class ItemPage : INavigableView<DataViewModel>
    {
        public DataViewModel ViewModel { get; }

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
