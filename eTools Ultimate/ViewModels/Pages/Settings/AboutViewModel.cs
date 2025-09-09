using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using eTools_Ultimate.Views.Windows;

namespace eTools_Ultimate.ViewModels.Pages
{
    public partial class AboutViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _appVersion = "";

        [ObservableProperty]
        private string _appDescription = "eTools Ultimate is a powerful editor for editing Flyff resource files.";

        [ObservableProperty]
        private string _copyright = "© 2025 eTools Ultimate. All rights reserved.";

        public AboutViewModel()
        {
            // Version aus der Assembly-Information abrufen
            AppVersion = $"Version: {GetAssemblyVersion()}";
        }

        private string GetAssemblyVersion()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "1.0.0";
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
                // Create and show the AvailableUpdateWindow
                var updateWindow = new Views.Windows.AvailableUpdateWindow();
                updateWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                // Show error message if something goes wrong
                var messageBox = new Wpf.Ui.Controls.MessageBox
                {
                    Title = "Error",
                    Content = $"Error checking for updates: {ex.Message}"
                };
                
                await messageBox.ShowDialogAsync();
            }
        }
    }
} 