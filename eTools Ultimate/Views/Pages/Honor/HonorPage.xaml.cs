using eTools_Ultimate.ViewModels.Pages;
using System.Windows.Controls;
using Wpf.Ui.Abstractions.Controls;

namespace eTools_Ultimate.Views.Pages.Honor
{
    /// <summary>
    /// Interaktionslogik für HonorPage.xaml
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

        private void HonorsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle selection change if needed
            // The selection is automatically synchronized with the ViewModel through IsSynchronizedWithCurrentItem="True"
        }
    }
} 