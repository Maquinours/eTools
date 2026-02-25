using eTools_Ultimate.Helpers;
using eTools_Ultimate.Models.Motions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace eTools_Ultimate.Views.Controls
{
    /// <summary>
    /// Logique d'interaction pour Model3DRenderer.xaml
    /// </summary>
    public partial class Model3DRenderer : UserControl
    {
        public static readonly DependencyProperty D3DHostProperty = DependencyProperty.Register(
            nameof(D3DHost),
            typeof(D3DImageHost),
            typeof(Model3DRenderer)
        );

        private System.Windows.Point _lastMousePosition;

        public D3DImageHost D3DHost
        {
            get => (D3DImageHost)GetValue(D3DHostProperty);
            set => SetValue(D3DHostProperty, value);
        }

        public Model3DRenderer()
        {
            InitializeComponent();

            Loaded += Model3DRenderer_Loaded;
            Unloaded += Model3DRenderer_Unloaded;
        }

        private void Model3DRenderer_Loaded(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            if (window == null)
                return;

            //if (!D3DHost.IsInitialized)
            //{
                nint hwnd = new WindowInteropHelper(window).Handle;

                D3DHost.Initialize(hwnd);
                D3DHost.BindBackBuffer();
                DxImage.Source = D3DHost;
            //}

            CompositionTarget.Rendering += CompositionTarget_Rendering;
        }

        private void Model3DRenderer_Unloaded(object sender, RoutedEventArgs e)
        {
            CompositionTarget.Rendering -= CompositionTarget_Rendering;
        }

        private void CompositionTarget_Rendering(object? sender, EventArgs e)
        {
            D3DHost.Render();
        }

        private void DxImage_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var window = Window.GetWindow((DependencyObject)sender);
            var posInWindow = e.GetPosition(window);

            _lastMousePosition = window.PointToScreen(posInWindow);

            Mouse.Capture(this);

            MouseMove += OnMouseMove;
            MouseRightButtonUp += OnMouseRightButtonUp;
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            var window = Window.GetWindow((DependencyObject)sender);
            var posInWindow = e.GetPosition(window);
            var mousePosition = window.PointToScreen(posInWindow);

            Vector deltaPosition = _lastMousePosition - mousePosition;

            _lastMousePosition = mousePosition;

            D3DHost.RotateCamera((int)deltaPosition.X, (int)deltaPosition.Y);
        }

        private void OnMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            MouseMove -= OnMouseMove;
            MouseRightButtonUp -= OnMouseRightButtonUp;

            Mouse.Capture(null);
        }

        private void DxImage_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            D3DHost.Zoom(e.Delta);
            e.Handled = true;
        }
    }
}
