using eTools_Ultimate.Helpers;
using eTools_Ultimate.Models;
using eTools_Ultimate.Services;
using eTools_Ultimate.ViewModels.Pages;
using eTools_Ultimate.Views.Dialogs;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Threading;
using Wpf.Ui;
using Wpf.Ui.Abstractions.Controls;
using Wpf.Ui.Controls;

namespace eTools_Ultimate.Views.Pages
{
    public partial class MoversPage : Page, INavigableView<MoversViewModel>
    {
        public MoversViewModel ViewModel { get; }

        private Point _lastMousePosition;
        private bool _isMouseDragging = false;

        public MoversPage(MoversViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = viewModel;

            InitializeComponent();
        }

        private void MoversListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MoversListView.ScrollIntoView(MoversListView.SelectedItem);

            Dispatcher.Invoke(() =>
            {
                ContentScrollViewer?.ScrollToTop();
            }, DispatcherPriority.Loaded);
        }

        private void MotionsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MotionsListView.ScrollIntoView(MotionsListView.SelectedItem);
        }
    }
}