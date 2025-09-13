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
    public partial class AboutViewModel : ObservableObject
    {
        private readonly ISnackbarService _snackbarService;
        private readonly IStringLocalizer _localizer;

        [ObservableProperty]
        private string _appVersion = $"Version: {System.Reflection.Assembly.GetExecutingAssembly().GetName().Version?.ToString()}";

        [ObservableProperty]
        private string _appDescription;

        [ObservableProperty]
        private string _copyright = "© 2025 eTools Ultimate. All rights reserved.";

        public AboutViewModel(ISnackbarService snackbarService, IStringLocalizer localizer)
        {
            _snackbarService = snackbarService;
            _localizer = localizer;
            _appDescription = localizer["eTools Ultimate is a powerful editor for editing Flyff resource files."] ?? "eTools Ultimate is a powerful editor for editing Flyff resource files.";
        }

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
                    _snackbarService.Show(
                    title: _localizer["No update available"],
                    message: _localizer["You already have the latest version."],
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
                _snackbarService.Show(
                    title: _localizer["Update check failed"],
                    message: ex.Message,
                    appearance: ControlAppearance.Danger,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(3)
                    );
            }
        }
    }
} 