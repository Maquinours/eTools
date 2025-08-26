using eTools_Ultimate.Helpers;
using eTools_Ultimate.Services;
using eTools_Ultimate.ViewModels.Pages;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using Wpf.Ui.Abstractions.Controls;

namespace eTools_Ultimate.Views.Pages.Motion
{
    /// <summary>
    /// Interaction logic for MotionPage.xaml
    /// </summary>
    public partial class MotionPage : Page, INavigableView<MotionsViewModel>
    {
        public MotionsViewModel ViewModel { get; }

        private Point _lastMousePosition;
        private bool _isMouseDragging = false;

        public MotionPage(MotionsViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = viewModel;
            
            InitializeComponent();
        }

        private void MotionsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Die Auswahl wird automatisch über das Binding aktualisiert
            // ViewModel.SelectedMotion wird durch die ListView aktualisiert
        }

        [RelayCommand]
        private void Undo()
        {
            ChangesTrackerService.Instance.Undo(ViewModel.MotionsView.CurrentItem);
        }

        [RelayCommand]
        private void Redo()
        {
            ChangesTrackerService.Instance.Redo(ViewModel.MotionsView.CurrentItem);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: implement this
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: implement this
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: implement this
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var hwnd = new WindowInteropHelper(Window.GetWindow(this)).Handle;

            D3DImageHost d3dHost = ViewModel.InitializeD3DHost(hwnd);
            DxImage.Source = d3dHost;
        }

        private void DxImage_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var currentPosition = e.GetPosition(null);
            _isMouseDragging = true;
            _lastMousePosition = currentPosition;
        }

        private void Page_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if(e.RightButton == System.Windows.Input.MouseButtonState.Released)
                _isMouseDragging = false;

            if (!_isMouseDragging) return;
            if (ViewModel.D3dHost is null) return;

            Point mousePosition = e.GetPosition(null);
            Vector deltaPosition = _lastMousePosition - mousePosition;

            int w = NativeMethods.GetSurfaceWidth(ViewModel.D3dHost._native);
            int h = NativeMethods.GetSurfaceHeight(ViewModel.D3dHost._native);

            //double transformX = w / DxImage.ActualWidth;
            //double transformY = h / DxImage.ActualHeight;

            NativeMethods.RotateCamera(ViewModel.D3dHost._native, (int)(deltaPosition.X), (int)(deltaPosition.Y));

            _lastMousePosition = mousePosition;
        }

        private void DxImage_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            if (ViewModel.D3dHost is null) return;
            NativeMethods.ZoomCamera(ViewModel.D3dHost._native, e.Delta);
            e.Handled = true;
        }

        //private void AddButton_Click(object sender, RoutedEventArgs e)
        //{
        //    // Eine neue Motion über das ViewModel erstellen
        //    ViewModel.AddMotionCommand.Execute(null);
        //}

        //private void SaveButton_Click(object sender, RoutedEventArgs e)
        //{
        //    // Die aktuelle Motion über das ViewModel speichern
        //    ViewModel.UpdateMotionCommand.Execute(null);
        //}

        //private void DeleteButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (MessageBox.Show("Do you really want to delete this motion?", "Delete Motion", 
        //        MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
        //    {
        //        // Die ausgewählte Motion über das ViewModel löschen
        //        ViewModel.DeleteMotionCommand.Execute(null);
        //    }
        //}
    }
} 