using eTools_Ultimate.ViewModels.Pages;
using System.Windows.Controls;
using Wpf.Ui.Abstractions.Controls;

namespace eTools_Ultimate.Views.Pages
{
    public partial class CouplePage : Page, INavigableView<CoupleViewModel>
    {
        public CoupleViewModel ViewModel { get; }

        public CouplePage(CoupleViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }

        private void LevelListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Optional: Weitere Aktionen beim Level-Wechsel
        }
    }
} 