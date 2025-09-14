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

            int w = NativeMethods.GetSurfaceWidth(ViewModel.D3dHost._native);
            int h = NativeMethods.GetSurfaceHeight(ViewModel.D3dHost._native);

            //double transformX = w / DxImage.ActualWidth;
            //double transformY = h / DxImage.ActualHeight;

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

        // TODO: readd binding to play motion command
        //[RelayCommand]
        //private void PlayMotion(ModelMotion motion)
        //{
        //    if (_d3dHost is null) return;
        //    if(MoversListView.SelectedItem is not Mover mover) return;

        //    CompositionTarget.Rendering -= CompositionTarget_Rendering;

        //    string modelsFolderPath = Settings.Instance.ModelsFolderPath ?? Settings.Instance.DefaultModelsFolderPath;
        //    string root = Path.GetFileNameWithoutExtension(mover.Model.Model3DFilePath);
        //    string lowerMotionKey = motion.SzMotion;

        //    string fileMotion = $@"{modelsFolderPath}\{root}_{lowerMotionKey}.ani";

        //    NativeMethods.PlayMotion(_d3dHost._native, fileMotion);

        //    CompositionTarget.Rendering += CompositionTarget_Rendering;

        //    //int numMotions = NativeMethods.GetNumMotions(_d3dHost._native);
        //    //for(int i = 0; i < numMotions; i++)
        //    //{
        //    //    IntPtr motionNamePtr = NativeMethods.GetMotionName(_d3dHost._native, i);
        //    //    string? motionName = Marshal.PtrToStringAnsi(motionNamePtr);
        //    //    if(motionName?.ToLower() == lowerMotionKey)
        //    //    {
        //    //        NativeMethods.PlayMotion(_d3dHost._native, i);
        //    //        break;
        //    //    }
        //    //}
        //}

        // TODO: readd this in ViewModel
        //private void MoverIdentifierTextBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if(_d3dHost is null) return;
        //    if (ViewModel.MoversView.CurrentItem is not Mover mover) return;

        //    switch (mover.Identifier)
        //    {
        //        case "MI_MALE":
        //            {
        //                string[] parts = [
        //                    "Part_maleHair06.o3d",
        //                    "Part_maleHead01.o3d",
        //                    "Part_maleHand.o3d",
        //                    "Part_maleLower.o3d",
        //                    "Part_maleUpper.o3d",
        //                    "Part_maleFoot.o3d",
        //                ];

        //                string modelsFolderPath = Settings.Instance.ModelsFolderPath ?? Settings.Instance.DefaultModelsFolderPath;
        //                string[] partsPath = [.. parts.Select(part => $"{modelsFolderPath}{part}")];

        //                foreach(string partPath in partsPath)
        //                {
        //                    NativeMethods.SetParts(_d3dHost._native, partPath);
        //                }
        //                _d3dHost.Render();
        //                break;
        //            }
        //        case "MI_FEMALE":
        //            {
        //                string[] parts = [
        //                    "Part_femaleHair06.o3d",
        //                    "Part_femaleHead01.o3d",
        //                    "Part_femaleHand.o3d",
        //                    "Part_femaleLower.o3d",
        //                    "Part_femaleUpper.o3d",
        //                    "Part_femaleFoot.o3d",
        //                ];
        //                string modelsFolderPath = Settings.Instance.ModelsFolderPath ?? Settings.Instance.DefaultModelsFolderPath;
        //                string[] partsPath = [.. parts.Select(part => $"{modelsFolderPath}{part}")];
        //                foreach (string partPath in partsPath)
        //                {
        //                    NativeMethods.SetParts(_d3dHost._native, partPath);
        //                }
        //                _d3dHost.Render();
        //                break;
        //            }
        //    }
        //}
    }
} 