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
            }
            catch (Exception ex)
            {
                ShowError($"Error loading current version: {ex.Message}");
            }
        }

        private void ShowUpdateInformation()
        {
            if (_availableUpdate != null)
            {
                try
                {
                    var versionProperty = _availableUpdate.GetType().GetProperty("Version");
                    var releaseNotesProperty = _availableUpdate.GetType().GetProperty("ReleaseNotes");
                    
                    var version = versionProperty?.GetValue(_availableUpdate)?.ToString() ?? "Unknown";
                    var releaseNotes = releaseNotesProperty?.GetValue(_availableUpdate)?.ToString();
                }
                catch (Exception ex)
                {
                    ShowError(string.Format(GetLocalizedString("Error displaying update information: {0}"), ex.Message));
                }
            }
        }

        private void LaterButton_Click(object sender, RoutedEventArgs e)
        {
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
                SetLoadingState(true);

                if (_availableUpdate != null)
                {
                    await _updateManager.DownloadUpdatesAsync((dynamic)_availableUpdate);
                    _updateManager.ApplyUpdatesAndRestart((dynamic)_availableUpdate);
                }
                else
                {
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
            if (InstallUpdateButton != null)
                InstallUpdateButton.IsEnabled = !isLoading;
            if (LaterButton != null)
                LaterButton.IsEnabled = !isLoading;
            
            if (isLoading)
            {
                if (LoadingPanel != null)
                    LoadingPanel.Visibility = Visibility.Visible;
                var storyboard = (Storyboard)FindResource("LoadingSpinnerAnimation");
                storyboard?.Begin();
            }
            else
            {
                if (LoadingPanel != null)
                    LoadingPanel.Visibility = Visibility.Collapsed;
                var storyboard = (Storyboard)FindResource("LoadingSpinnerAnimation");
                storyboard?.Stop();
            }
        }


        private void ShowError(string errorMessage)
        {
            if (ErrorText != null)
                ErrorText.Text = errorMessage;
            if (ErrorPanel != null)
                ErrorPanel.Visibility = Visibility.Visible;
        }

        private string GetLocalizedString(string key)
        {
            return _stringLocalizer[key];
        }

    }
}
