using System.Windows;
using Wpf.Ui.Controls;

namespace eTools.Views.Windows
{
    public partial class WarningDialog : ContentDialog
    {
        public WarningDialog()
        {
            InitializeComponent();
        }

        private void GoToResourcePath_Click(object sender, RoutedEventArgs e)
        {
            // The logic for the "Go to Resource Path" button will be implemented later
            this.Hide();
        }

        private void CloseApplication_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
} 