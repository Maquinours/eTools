using eTools_Ultimate.Helpers;
using eTools_Ultimate.Services;
using eTools_Ultimate.ViewModels.Pages;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using Wpf.Ui.Abstractions.Controls;

namespace eTools_Ultimate.Views.Pages
{
    /// <summary>
    /// Interaction logic for MotionPage.xaml
    /// </summary>
    public partial class MotionsPage : Page, INavigableView<MotionsViewModel>
    {
        public MotionsViewModel ViewModel { get; }

        public MotionsPage(MotionsViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = viewModel;
            
            InitializeComponent();
        }

        private void MotionsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MotionsListView.ScrollIntoView(MotionsListView.SelectedItem);
        }
    }
} 