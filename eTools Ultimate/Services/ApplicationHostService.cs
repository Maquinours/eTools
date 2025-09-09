using eTools_Ultimate.Views.Windows;
using Microsoft.Extensions.Hosting;
using Velopack;
using Velopack.Sources;
using Wpf.Ui;

namespace eTools_Ultimate.Services
{
    /// <summary>
    /// Managed host of the application.
    /// </summary>
    public class ApplicationHostService(IServiceProvider serviceProvider) : IHostedService
    {
        private INavigationWindow? _navigationWindow;

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
        /// Check 
        /// </summary>
        /// <returns></returns>
        private async Task CheckForUpdatesAsync()
        {
            var mgr = new UpdateManager(new GithubSource(repoUrl: "https://github.com/Maquinours/eTools", accessToken: null, prerelease: false));

            if (!mgr.IsInstalled)
                return; // app is not installed (probably launched via source code)

            // check for new version
            var newVersion = await mgr.CheckForUpdatesAsync();

            if (newVersion == null)
                return; // no update available

            if (new AvailableUpdateWindow().ShowDialog() == true)
            {
                // the user agrees to download the latest version

                // download new version
                await mgr.DownloadUpdatesAsync(newVersion);

                // install new version and restart app
                mgr.ApplyUpdatesAndRestart(newVersion);
            }
        }

        /// <summary>
        /// Creates main window during activation.
        /// </summary>
        private async Task HandleActivationAsync()
        {
            await CheckForUpdatesAsync();
            if (!Application.Current.Windows.OfType<MainWindow>().Any())
            {
                _navigationWindow = (serviceProvider.GetService(typeof(INavigationWindow)) as INavigationWindow)!;

                Views.Windows.SplashScreen splashScreen = serviceProvider.GetService(typeof(Views.Windows.SplashScreen)) as Views.Windows.SplashScreen ?? throw new InvalidOperationException("SplashScreen service not found");
                splashScreen.Show();
            }

            await Task.CompletedTask;
        }
    }
}
