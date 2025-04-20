using eTools_Ultimate.ViewModels.Pages;
using Wpf.Ui.Abstractions.Controls;

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
