using eTools_Ultimate.ViewModels.Pages;
using System.Windows.Controls;
using Wpf.Ui.Abstractions.Controls;

namespace eTools_Ultimate.Views.Pages.Honor
{
    /// <summary>
    /// Interaction logic for HonorPage.xaml
    /// </summary>
    public partial class HonorPage : System.Windows.Controls.Page, INavigableView<HonorsViewModel>
    {
        public HonorsViewModel ViewModel { get; }

        public HonorPage(HonorsViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }
    }
} 