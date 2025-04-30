using eTools_Ultimate.ViewModels.Pages;
using System.Windows.Controls;
using Wpf.Ui.Abstractions.Controls;

namespace eTools_Ultimate.Views.Pages
{
    public partial class ExchangerPage : Page, INavigableView<ExchangesViewModel>
    {
        public ExchangesViewModel ViewModel { get; }

        public ExchangerPage(ExchangesViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }
    }
} 