using eTools_Ultimate.Services;
using System.Windows;

namespace eTools_Ultimate.Views.Windows
{
    public partial class SplashScreen : Window
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        public async Task Load()
        {
            await Task.Run(() =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    LoadingText.Text = "Loading settings...";
                });
                SettingsService.Load();
                Application.Current.Dispatcher.Invoke(() =>
                {
                    LoadingText.Text = "Loading defines...";
                });
                DefinesService.Instance.Load();
                Application.Current.Dispatcher.Invoke(() =>
                {
                    LoadingText.Text = "Loading strings...";
                });
                StringsService.Instance.Load();
                Application.Current.Dispatcher.Invoke(() =>
                {
                    LoadingText.Text = "Loading movers...";
                });
                MoversService.Instance.Load();
                Application.Current.Dispatcher.Invoke(() =>
                {
                    LoadingText.Text = "Loading items...";
                });
                ItemsService.Instance.Load();
            }).ConfigureAwait(true);
        }
    }
} 