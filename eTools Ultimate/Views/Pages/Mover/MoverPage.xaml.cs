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

        private void Model3DFilePathTextBlock_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_d3dHost is null) return;
            if (ViewModel.MoversView.CurrentItem is not Mover mover) return;
            if (mover.Id == "MI_MALE" || mover.Id == "MI_FEMALE") return;
            NativeMethods.LoadModel(_d3dHost._native, mover.Model.Model3DFilePath);

            int textureEx = DefinesService.Instance.Defines[mover.Model.NTextureEx];
            float scale = mover.Model.FScale;
            if (textureEx != 0)
                NativeMethods.SetTextureEx(_d3dHost._native, textureEx);
            if (scale != 1)
                NativeMethods.SetScale(_d3dHost._native, scale);
        }

        [RelayCommand]
        private void PlayMotion(ModelMotion motion)
        {
            if (_d3dHost is null) return;
            if(MoversListView.SelectedItem is not Mover mover) return;

            string modelsFolderPath = Settings.Instance.ModelsFolderPath ?? Settings.Instance.DefaultModelsFolderPath;
            string root = Path.GetFileNameWithoutExtension(mover.Model.Model3DFilePath);
            string lowerMotionKey = motion.SzMotion;

            string fileMotion = $@"{modelsFolderPath}\{root}_{lowerMotionKey}.ani";

            NativeMethods.PlayMotion(_d3dHost._native, fileMotion);

            //int numMotions = NativeMethods.GetNumMotions(_d3dHost._native);
            //for(int i = 0; i < numMotions; i++)
            //{
            //    IntPtr motionNamePtr = NativeMethods.GetMotionName(_d3dHost._native, i);
            //    string? motionName = Marshal.PtrToStringAnsi(motionNamePtr);
            //    if(motionName?.ToLower() == lowerMotionKey)
            //    {
            //        NativeMethods.PlayMotion(_d3dHost._native, i);
            //        break;
            //    }
            //}
        }

        private void ModelTextureExTextBlock_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_d3dHost is null) return;
            if (ViewModel.MoversView.CurrentItem is not Mover mover) return;

            int textureEx = DefinesService.Instance.Defines[mover.Model.NTextureEx];
            NativeMethods.SetTextureEx(_d3dHost._native, textureEx);
        }

        private void ScaleNumberBox_ValueChanged(object sender, NumberBoxValueChangedEventArgs args)
        {
            if (_d3dHost is null) return;
            if (ViewModel.MoversView.CurrentItem is not Mover mover) return;

            float scale = mover.Model.FScale;
            NativeMethods.SetScale(_d3dHost._native, scale);
        }

        private void IdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(_d3dHost is null) return;
            if (sender is not System.Windows.Controls.TextBox idTextbox || idTextbox.Name != "IdTextBox") return;

            switch(idTextbox.Text)
            {
                case "MI_MALE":
                    {
                        string[] parts = [
                            "Part_maleHair06.o3d",
                            "Part_maleHead01.o3d",
                            "Part_maleHand.o3d",
                            "Part_maleLower.o3d",
                            "Part_maleUpper.o3d",
                            "Part_maleFoot.o3d",
                        ];

                        string modelsFolderPath = Settings.Instance.ModelsFolderPath ?? Settings.Instance.DefaultModelsFolderPath;
                        string[] partsPath = [.. parts.Select(part => $"{modelsFolderPath}{part}")];

                        foreach(string partPath in partsPath)
                        {
                            NativeMethods.SetParts(_d3dHost._native, partPath);
                        }
                        break;
                    }
                case "MI_FEMALE":
                    {
                        string[] parts = [
                            "Part_femaleHair06.o3d",
                            "Part_femaleHead01.o3d",
                            "Part_femaleHand.o3d",
                            "Part_femaleLower.o3d",
                            "Part_femaleUpper.o3d",
                            "Part_femaleFoot.o3d",
                        ];
                        string modelsFolderPath = Settings.Instance.ModelsFolderPath ?? Settings.Instance.DefaultModelsFolderPath;
                        string[] partsPath = [.. parts.Select(part => $"{modelsFolderPath}{part}")];
                        foreach (string partPath in partsPath)
                        {
                            NativeMethods.SetParts(_d3dHost._native, partPath);
                        }
                        break;
                    }
            }
        }
    }
} 