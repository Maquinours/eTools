using eTools_Ultimate.ViewModels.Pages;
using System.Windows.Controls;
using Wpf.Ui.Controls;
using Wpf.Ui;
using Wpf.Ui.Abstractions.Controls;
using eTools_Ultimate.Helpers;
using System.Windows.Interop;
using System.Windows.Media;
using eTools_Ultimate.Models;
using System.Runtime.InteropServices;
using eTools_Ultimate.Services;
using System.IO;
using eTools_Ultimate.Views.Dialogs;

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
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var hwnd = new WindowInteropHelper(Window.GetWindow(this)).Handle;

            D3DImageHost d3dHost = ViewModel.InitializeD3DHost(hwnd);
            DxImage.Source = d3dHost;
        }

        private void CompositionTarget_Rendering(object? sender, EventArgs e)
        {
            if (ViewModel.Auto3DRendering)
                ViewModel.D3dHost?.Render();
        }

        private void DxImage_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var currentPosition = e.GetPosition(null);
            _isMouseDragging = true;
            _lastMousePosition = currentPosition;
        }

        private void Page_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (!_isMouseDragging) return;
            if (ViewModel.D3dHost is null) return;
            
            Point mousePosition = e.GetPosition(null);
            Vector deltaPosition = _lastMousePosition - mousePosition;

            NativeMethods.RotateCamera(ViewModel.D3dHost._native, (int)(deltaPosition.X), (int)(deltaPosition.Y));

            _lastMousePosition = mousePosition;
            if(!ViewModel.Auto3DRendering)
                ViewModel.D3dHost.Render();
        }

        private void Page_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _isMouseDragging = false;
        }

        private void DxImage_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            if (ViewModel.D3dHost is null) return;
            NativeMethods.ZoomCamera(ViewModel.D3dHost._native, e.Delta);
            e.Handled = true;

            if (!ViewModel.Auto3DRendering)
                ViewModel.D3dHost.Render();
        }

        private void MotionsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MotionsListView.ScrollIntoView(MotionsListView.SelectedItem);
        }
    }
} 