using eTools_Ultimate.ViewModels.Pages;
using System.Windows.Controls;
using Wpf.Ui.Controls;
using Wpf.Ui.Abstractions.Controls;

namespace eTools_Ultimate.Views.Pages
{
    public partial class MiscPage : Page, INavigableView<MiscViewModel>
    {
        public MiscViewModel ViewModel { get; }

        public MiscPage(MiscViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = viewModel;

            InitializeComponent();
        }
    }
}
