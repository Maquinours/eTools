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
            // Hier wird später die Logik für den "Go to Resource Path" Button implementiert
            this.Hide();
        }

        private void CloseApplication_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
} 