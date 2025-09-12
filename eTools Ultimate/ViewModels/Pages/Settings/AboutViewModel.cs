using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using eTools_Ultimate.Views.Windows;
using Microsoft.Extensions.Localization;
using Velopack;
using Velopack.Sources;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace eTools_Ultimate.ViewModels.Pages
{
    public partial class AboutViewModel(ISnackbarService snackbarService, IStringLocalizer localizer) : ObservableObject
    {
        [ObservableProperty]
        private string _appVersion = $"Version: {System.Reflection.Assembly.GetExecutingAssembly().GetName().Version?.ToString()}";

        [ObservableProperty]
        private string _appDescription = "eTools Ultimate is a powerful editor for editing Flyff resource files.";

        [ObservableProperty]
        private string _copyright = "© 2025 eTools Ultimate. All rights reserved.";

        [RelayCommand]
        private void OpenWebsite()
        {
            // Öffnet die Website in einem Browser
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://example.com",
                UseShellExecute = true
            });
        }

        [RelayCommand]
        private async Task CheckForUpdates()
        {
            try
            {
                var mgr = new UpdateManager(new GithubSource(repoUrl: "https://github.com/Maquinours/eTools", accessToken: null, prerelease: false));

                // check for new version
                var update = await mgr.CheckForUpdatesAsync();

                if (update is null)
                {
                    snackbarService.Show(
                    title: localizer["No update available"],
                    message: localizer["You already have the latest version."],
                    appearance: ControlAppearance.Info,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(3)
                    );
                }
                else
                {
                    // create and show the AvailableUpdateWindow
                    var updateWindow = new AvailableUpdateWindow(update);
                    updateWindow.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                snackbarService.Show(
                    title: localizer["Update check failed"],
                    message: ex.Message,
                    appearance: ControlAppearance.Danger,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(3)
                    );
            }
        }
    }
} 