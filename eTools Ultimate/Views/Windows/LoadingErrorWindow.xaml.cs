using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace eTools_Ultimate.Views.Windows
{
    /// <summary>
    /// Logique d'interaction pour LoadingErrorWindow.xaml
    /// </summary>
    public partial class LoadingErrorWindow : Wpf.Ui.Controls.FluentWindow
    {
        public LoadingErrorWindow(string errorMessage)
        {
            InitializeComponent();
            ErrorMessageTextBox.Text = errorMessage;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
