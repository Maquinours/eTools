using eTools_Ultimate.Models;
using eTools_Ultimate.ViewModels.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Velopack;
using Velopack.Sources;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;

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

            SetTheme();
            App.Services.GetRequiredService<AppConfig>().PropertyChanged += AppConfig_PropertyChanged;
        }

        private void LaterButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SetTheme()
        {
            AppConfig appConfig = App.Services.GetRequiredService<AppConfig>();

            if (IsLoaded)
                SystemThemeWatcher.UnWatch(this);

            if (appConfig.Theme.HasValue)
                ApplicationThemeManager.Apply(appConfig.Theme.Value);
            else
            {
                ApplicationThemeManager.ApplySystemTheme();
                SystemThemeWatcher.Watch(this);
            }
        }

        private void AppConfig_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AppConfig.Theme))
                SetTheme();
        }
    }
}
