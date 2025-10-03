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
using System.Windows.Media.Animation;
using System.Reflection;
using Velopack;
using Velopack.Sources;
using Wpf.Ui.Controls;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.DependencyInjection;
using eTools_Ultimate.ViewModels.Windows;

namespace eTools_Ultimate.Views.Windows
{
    /// <summary>
    /// Information window that shows available update to the user
    /// </summary>
    public partial class AvailableUpdateWindow : FluentWindow
    {

        public AvailableUpdateWindow(UpdateInfo update)
        {
            InitializeComponent();
            DataContext = new AvailableUpdateWindowViewModel(update);
        }

        private void LaterButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
