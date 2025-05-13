using eTools_Ultimate.ViewModels.Pages;
using System.Windows.Controls;
using Wpf.Ui.Controls;
using Wpf.Ui;
using Wpf.Ui.Abstractions.Controls;
using eTools_Ultimate.Helpers;
using System.Windows.Interop;
using System.Windows.Media;
using eTools_Ultimate.Models;

namespace eTools_Ultimate.Views.Pages
{
    public partial class MoverPage : Page, INavigableView<MoversViewModel>
    {
        public MoversViewModel ViewModel { get; }

        private D3DImageHost? _d3dHost = null;
        private Point lastMousePosition;
        private bool isDragging = false;

        public MoverPage(MoversViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }

        private void MoversListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Diese Methode wird aufgerufen, wenn die Auswahl in der ListView geändert wird
            if (e.AddedItems.Count > 0)
            {
                var selectedItem = e.AddedItems[0];
                // Hier kann die Logik implementiert werden, um die Details des ausgewählten Items anzuzeigen
            }
        }

        private void AddButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Logik zum Hinzufügen eines neuen Mover-Elements
            // ViewModel.AddNewItem();
        }

        private void DeleteButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Logik zum Löschen des ausgewählten Mover-Elements
            if (MoversListView.SelectedItem != null)
            {
                // ViewModel.DeleteSelectedItem(MoversListView.SelectedItem);
            }
        }

        private void SaveButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                var result = System.Windows.MessageBox.Show(
                    "Do you want to save the changes?",
                    "Save",
                    System.Windows.MessageBoxButton.YesNo,
                    System.Windows.MessageBoxImage.Question);
                
                if (result == System.Windows.MessageBoxResult.Yes)
                {
                    // Here the logic for saving could be implemented
                    System.Console.WriteLine("Mover is being saved");
                }
            }
            catch(System.Exception ex)
            {
                System.Windows.MessageBox.Show(
                    $"Error saving: {ex.Message}",
                    "Error",
                    System.Windows.MessageBoxButton.OK,
                    System.Windows.MessageBoxImage.Error);
                
                System.Console.WriteLine($"Error: {ex.Message}\n{ex.StackTrace}");
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var hwnd = new WindowInteropHelper(Window.GetWindow(this)).Handle;
            _d3dHost = new D3DImageHost(hwnd);
            _d3dHost.Initialize(hwnd);
            _d3dHost.BindBackBuffer();
            DxImage.Source = _d3dHost;

            CompositionTarget.Rendering += (s, e) => _d3dHost.Render();
        }

        private void FileTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_d3dHost is null) return;
            if (ViewModel.MoversView.CurrentItem is not Mover mover) return;
            NativeMethods.LoadModel(_d3dHost._native, @$"{Settings.Instance.ResourcesFolderPath}Model\mvr_{mover.Model.SzName}.o3d");
        }

        private void DxImage_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var currentPosition = e.GetPosition(null);
            isDragging = true;
            lastMousePosition = currentPosition;
        }

        private void Page_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (_d3dHost is null) return;
            if (!isDragging) return;
            
            Point mousePosition = e.GetPosition(null);
            Vector deltaPosition = lastMousePosition - mousePosition;

            int w = NativeMethods.GetSurfaceWidth(_d3dHost._native);
            int h = NativeMethods.GetSurfaceHeight(_d3dHost._native);

            //double transformX = w / DxImage.ActualWidth;
            //double transformY = h / DxImage.ActualHeight;

            NativeMethods.RotateCamera(_d3dHost._native, (int)(deltaPosition.X), (int)(deltaPosition.Y));

            lastMousePosition = mousePosition;
        }

        private void Page_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            isDragging = false;
        }

        private void DxImage_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            if (_d3dHost is null) return;
            NativeMethods.ZoomCamera(_d3dHost._native, e.Delta);
            e.Handled = true;
        }
    }
} 