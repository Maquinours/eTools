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

namespace eTools_Ultimate.Views.Windows
{
    /// <summary>
    /// Information window that shows available update to the user
    /// </summary>
    public partial class AvailableUpdateWindow : FluentWindow
    {
        private UpdateManager? _updateManager;
        private object? _availableUpdate;
        private readonly IStringLocalizer _stringLocalizer;

        public AvailableUpdateWindow(object? availableUpdate = null)
        {
            InitializeComponent();
            _stringLocalizer = App.Services.GetRequiredService<IStringLocalizer>();
            _availableUpdate = availableUpdate;
            InitializeUpdateManager();
            LoadCurrentVersion();
            ShowUpdateInformation();
        }

        private void InitializeUpdateManager()
        {
            try
            {
                _updateManager = new UpdateManager(new GithubSource(
                    repoUrl: "https://github.com/Maquinours/eTools", 
                    accessToken: null, 
                    prerelease: false));
            }
            catch (Exception ex)
            {
                ShowError($"Error initializing update manager: {ex.Message}");
            }
        }

        private void LoadCurrentVersion()
        {
            try
            {
                var version = Assembly.GetExecutingAssembly().GetName().Version;
                CurrentVersionText.Text = version?.ToString() ?? "1.0.0";
            }
            catch (Exception ex)
            {
                CurrentVersionText.Text = "Unknown";
                ShowError($"Error loading current version: {ex.Message}");
            }
        }

        private void ShowUpdateInformation()
        {
            if (_availableUpdate != null)
            {
                try
                {
                    // Use reflection to access properties
                    var versionProperty = _availableUpdate.GetType().GetProperty("Version");
                    var releaseNotesProperty = _availableUpdate.GetType().GetProperty("ReleaseNotes");
                    
                    var version = versionProperty?.GetValue(_availableUpdate)?.ToString() ?? "Unknown";
                    var releaseNotes = releaseNotesProperty?.GetValue(_availableUpdate)?.ToString();
                    
                    NewVersionText.Text = version;
                    UpdateDescriptionText.Text = string.IsNullOrEmpty(releaseNotes) 
                        ? GetLocalizedString("This update contains new features, improvements, and bug fixes.")
                        : releaseNotes;
                }
                catch (Exception ex)
                {
                    ShowError(string.Format(GetLocalizedString("Error displaying update information: {0}"), ex.Message));
                }
            }
            else
            {
                // Fallback if no update info is provided
                NewVersionText.Text = "1.1.0";
                UpdateDescriptionText.Text = GetLocalizedString("This update contains new features, improvements, and bug fixes.");
            }
        }

        private void LaterButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the window without updating
            this.Close();
        }

        private async void InstallUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (_updateManager == null)
            {
                ShowError("Update manager is not available.");
                return;
            }

            if (!_updateManager.IsInstalled)
            {
                ShowError("Application is not installed (probably started from source code).");
                return;
            }

            try
            {
                // Show loading state
                SetLoadingState(true);

                if (_availableUpdate != null)
                {
                    // Download and install update
                    await _updateManager.DownloadUpdatesAsync((dynamic)_availableUpdate);
                    _updateManager.ApplyUpdatesAndRestart((dynamic)_availableUpdate);
                }
                else
                {
                    // Check for updates first if not provided
                    var update = await _updateManager.CheckForUpdatesAsync();
                    if (update != null)
                    {
                        await _updateManager.DownloadUpdatesAsync((dynamic)update);
                        _updateManager.ApplyUpdatesAndRestart((dynamic)update);
                    }
                    else
                    {
                        ShowError("No update available for installation.");
                    }
                }
            }
            catch (Exception ex)
            {
                SetLoadingState(false);
                ShowError($"Error installing update: {ex.Message}");
            }
        }

        private void SetLoadingState(bool isLoading)
        {
            // Check if buttons exist before accessing them
            if (InstallUpdateButton != null)
                InstallUpdateButton.IsEnabled = !isLoading;
            if (LaterButton != null)
                LaterButton.IsEnabled = !isLoading;
            
            if (isLoading)
            {
                if (LoadingPanel != null)
                    LoadingPanel.Visibility = Visibility.Visible;
                // Start animation
                var storyboard = (Storyboard)FindResource("LoadingAnimation");
                storyboard?.Begin();
            }
            else
            {
                if (LoadingPanel != null)
                    LoadingPanel.Visibility = Visibility.Collapsed;
                // Stop animation
                var storyboard = (Storyboard)FindResource("LoadingAnimation");
                storyboard?.Stop();
            }
        }


        private void ShowError(string errorMessage)
        {
            ErrorText.Text = errorMessage;
            ErrorPanel.Visibility = Visibility.Visible;
        }

        private string GetLocalizedString(string key)
        {
            return _stringLocalizer[key];
        }

    }
}
