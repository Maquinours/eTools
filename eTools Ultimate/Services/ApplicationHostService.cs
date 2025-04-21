using eTools_Ultimate.Views.Pages;
using eTools_Ultimate.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using Wpf.Ui;

namespace eTools_Ultimate.Services
{
    /// <summary>
    /// Managed host of the application.
    /// </summary>
    public class ApplicationHostService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        private INavigationWindow _navigationWindow;

        public ApplicationHostService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Triggered when the application host is ready to start the service.
        /// </summary>
        /// <param name="cancellationToken">Indicates that the start process has been aborted.</param>
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await HandleActivationAsync();
        }

        /// <summary>
        /// Triggered when the application host is performing a graceful shutdown.
        /// </summary>
        /// <param name="cancellationToken">Indicates that the shutdown process should no longer be graceful.</param>
        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// Creates main window during activation.
        /// </summary>
        private async Task HandleActivationAsync()
        {
            if (!Application.Current.Windows.OfType<MainWindow>().Any())
            {
                _navigationWindow = (
                    _serviceProvider.GetService(typeof(INavigationWindow)) as INavigationWindow
                )!;

                bool loadingError = false;
                eTools_Ultimate.Views.Windows.SplashScreen splashScreen = new eTools_Ultimate.Views.Windows.SplashScreen();
                splashScreen.Show();
                try
                {
                    await Task.Run(() =>
                    {
                        SettingsService.Load();
                        StringsService.Instance.Load();
                        ItemsService.Instance.Load();
                    });
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message, "Error", System.Windows.MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    splashScreen.Close();
                    _navigationWindow!.ShowWindow();
                    if (loadingError)
                        _navigationWindow!.Navigate(typeof(ResourcePathPage));
                    else
                        _navigationWindow!.Navigate(typeof(DashboardPage));
                }
            }

            await Task.CompletedTask;
        }
    }
}
