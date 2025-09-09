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
    /// Interaction logic for AvailableUpdateWindow.xaml
    /// </summary>
    public partial class AvailableUpdateWindow : FluentWindow
    {
        private UpdateManager? _updateManager;
        private object? _availableUpdate;
        private readonly IStringLocalizer _stringLocalizer;

        public AvailableUpdateWindow()
        {
            InitializeComponent();
            _stringLocalizer = App.Services.GetRequiredService<IStringLocalizer>();
            InitializeUpdateManager();
            LoadCurrentVersion();
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
                CurrentVersionText.Text = $"Version {version?.ToString() ?? "1.0.0"}";
            }
            catch (Exception ex)
            {
                CurrentVersionText.Text = "Version unknown";
                ShowError($"Error loading current version: {ex.Message}");
            }
        }

        private async void CheckForUpdatesButton_Click(object sender, RoutedEventArgs e)
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

            // Set UI to loading state
            SetLoadingState(true);
            HideAllPanels();

            try
            {
                // Check for updates
                _availableUpdate = await _updateManager.CheckForUpdatesAsync();

                if (_availableUpdate == null)
                {
                    // No update available
                    ShowNoUpdateAvailable();
                }
                else
                {
                    // Update available
                    ShowUpdateAvailable(_availableUpdate);
                }
            }
            catch (Exception ex)
            {
                ShowError($"Error checking for updates: {ex.Message}");
            }
            finally
            {
                SetLoadingState(false);
            }
        }

        private async void InstallUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (_updateManager == null || _availableUpdate == null)
            {
                ShowError("No update available for installation.");
                return;
            }

            try
            {
                // Download update
                SetLoadingState(true);
                StatusText.Text = "Downloading update...";
                StatusText.Visibility = Visibility.Visible;

                await _updateManager.DownloadUpdatesAsync((dynamic)_availableUpdate);

                StatusText.Text = "Installing update...";

                // Install update and restart application
                _updateManager.ApplyUpdatesAndRestart((dynamic)_availableUpdate);
            }
            catch (Exception ex)
            {
                SetLoadingState(false);
                ShowError($"Error installing update: {ex.Message}");
            }
        }

        private void SetLoadingState(bool isLoading)
        {
            CheckForUpdatesButton.IsEnabled = !isLoading;
            
            if (isLoading)
            {
                LoadingPanel.Visibility = Visibility.Visible;
                // Start animation
                var storyboard = (Storyboard)FindResource("LoadingAnimation");
                storyboard?.Begin();
            }
            else
            {
                LoadingPanel.Visibility = Visibility.Collapsed;
                StatusText.Visibility = Visibility.Collapsed;
                // Stop animation
                var storyboard = (Storyboard)FindResource("LoadingAnimation");
                storyboard?.Stop();
            }
        }

        private void ShowUpdateAvailable(object update)
        {
            try
            {
                // Use reflection to access properties
                var versionProperty = update.GetType().GetProperty("Version");
                var releaseNotesProperty = update.GetType().GetProperty("ReleaseNotes");
                
                var version = versionProperty?.GetValue(update)?.ToString() ?? "Unknown";
                var releaseNotes = releaseNotesProperty?.GetValue(update)?.ToString();
                
                    NewVersionText.Text = string.Format(GetLocalizedString("Version {0} available"), version);
                    UpdateDescriptionText.Text = string.IsNullOrEmpty(releaseNotes) 
                        ? GetLocalizedString("This update contains new features and improvements.")
                        : releaseNotes;
                
                UpdateAvailablePanel.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                ShowError(string.Format(GetLocalizedString("Error displaying update information: {0}"), ex.Message));
            }
        }

        private void ShowNoUpdateAvailable()
        {
            NoUpdatePanel.Visibility = Visibility.Visible;
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

        private void HideAllPanels()
        {
            UpdateAvailablePanel.Visibility = Visibility.Collapsed;
            NoUpdatePanel.Visibility = Visibility.Collapsed;
            ErrorPanel.Visibility = Visibility.Collapsed;
            StatusText.Visibility = Visibility.Collapsed;
        }
    }
}
