using Wpf.Ui.Abstractions.Controls;
using Wpf.Ui.Appearance;
using eTools_Ultimate.Models;
using System.IO;
using Microsoft.Win32;
using CommunityToolkit.Mvvm.Input;
using eTools_Ultimate.Views.Pages;
using Wpf.Ui.Controls;
using eTools_Ultimate.ViewModels.Windows;
using eTools_Ultimate.Views.Windows;
using Wpf.Ui;
using eTools_Ultimate.Services;

namespace eTools_Ultimate.ViewModels.Pages
{
    public partial class SettingsViewModel(SettingsService settingsService) : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;

        [ObservableProperty]
        private string _appVersion = String.Empty;

        [ObservableProperty]
        private ApplicationTheme _currentTheme = ApplicationTheme.Unknown;

        [ObservableProperty]
        private string _propFileName = string.Empty;

        [ObservableProperty]
        private string _textFileName = string.Empty;

        public Settings Settings => settingsService.Settings;

        public Task OnNavigatedToAsync()
        {
            if (!_isInitialized)
                InitializeViewModel();

            return Task.CompletedTask;
        }

        public Task OnNavigatedFromAsync() => Task.CompletedTask;

        private void InitializeViewModel()
        {
            CurrentTheme = ApplicationThemeManager.GetAppTheme();
            AppVersion = $"UiDesktopApp1 - {GetAssemblyVersion()}";
            PropFileName = "prop.inc";
            TextFileName = "text.txt";

            _isInitialized = true;
        }

        private string GetAssemblyVersion()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version?.ToString()
                ?? String.Empty;
        }

        [RelayCommand]
        private void OnChangeTheme(string parameter)
        {
            switch (parameter)
            {
                case "theme_light":
                    if (CurrentTheme == ApplicationTheme.Light)
                        break;

                    ApplicationThemeManager.Apply(ApplicationTheme.Light);
                    CurrentTheme = ApplicationTheme.Light;

                    break;

                default:
                    if (CurrentTheme == ApplicationTheme.Dark)
                        break;

                    ApplicationThemeManager.Apply(ApplicationTheme.Dark);
                    CurrentTheme = ApplicationTheme.Dark;

                    break;
            }
        }

        #region Folder and File Selection Commands
        [RelayCommand]
        private void SelectResourcesFolder()
        {
            string path = Settings.ResourcesFolderPath;
            SelectFolder("Ressourcen-Ordner auswählen", ref path);
            Settings.ResourcesFolderPath = path;
            OnPropertyChanged(nameof(Settings));
        }

        [RelayCommand]
        private void SelectIconsFolder()
        {
            string path = Settings.IconsFolderPath;
            SelectFolder("Icons-Ordner auswählen", ref path);
            Settings.IconsFolderPath = path;
            OnPropertyChanged(nameof(Settings));
        }

        [RelayCommand]
        private void SelectTexturesFolder()
        {
            string path = Settings.TexturesFolderPath;
            SelectFolder("Texturen-Ordner auswählen", ref path);
            Settings.TexturesFolderPath = path;
            OnPropertyChanged(nameof(Settings));
        }

        [RelayCommand]
        private void SelectSoundsFolder()
        {
            string path = Settings.SoundsFolderPath;
            SelectFolder("Sound-Ordner auswählen", ref path);
            Settings.SoundsFolderPath = path;
            OnPropertyChanged(nameof(Settings));
        }

        [RelayCommand]
        private void SelectPropFile()
        {
            SelectFile("Prop-Datei auswählen", "Inc-Dateien (*.inc)|*.inc|Alle Dateien (*.*)|*.*", ref _propFileName);
            OnPropertyChanged(nameof(PropFileName));
        }

        [RelayCommand]
        private void SelectTextFile()
        {
            SelectFile("Text-Datei auswählen", "Textdateien (*.txt)|*.txt|Alle Dateien (*.*)|*.*", ref _textFileName);
            OnPropertyChanged(nameof(TextFileName));
        }

        [RelayCommand]
        private void SelectSoundsConfig()
        {
            string path = Settings.SoundsConfigFilePath;
            SelectFile("Sound-Konfigurationsdatei auswählen", "Inc-Dateien (*.inc)|*.inc|Alle Dateien (*.*)|*.*", ref path);
            Settings.SoundsConfigFilePath = path;
            OnPropertyChanged(nameof(Settings));
        }

        [RelayCommand]
        private void SelectPropMoverFile()
        {
            string path = Settings.PropMoverFilePath;
            SelectFile("PropMover-Datei auswählen", "Prop-Dateien (*.txt)|*.txt|Alle Dateien (*.*)|*.*", ref path);
            Settings.PropMoverFilePath = path;
            OnPropertyChanged(nameof(Settings));
        }

        [RelayCommand]
        private void SelectPropMoverTextFile()
        {
            string path = Settings.PropMoverTxtFilePath;
            SelectFile("PropMover.txt-Datei auswählen", "Text-Dateien (*.txt)|*.txt|Alle Dateien (*.*)|*.*", ref path);
            Settings.PropMoverTxtFilePath = path;
            OnPropertyChanged(nameof(Settings));
        }

        [RelayCommand]
        private void SelectPropMoverExFile()
        {
            string path = Settings.PropMoverExFilePath;
            SelectFile("PropMoverEx-Datei auswählen", "Inc-Dateien (*.inc)|*.inc|Alle Dateien (*.*)|*.*", ref path);
            Settings.PropMoverExFilePath = path;
            OnPropertyChanged(nameof(Settings));
        }

        private void SelectFolder(string title, ref string path)
        {
            var dialog = new OpenFileDialog
            {
                Title = title,
                CheckFileExists = false,
                CheckPathExists = true,
                FileName = "Ordner auswählen",
                ValidateNames = false
            };

            if (!string.IsNullOrEmpty(path) && Directory.Exists(path))
            {
                dialog.InitialDirectory = path;
            }

            if (dialog.ShowDialog() == true)
            {
                string selectedPath = Path.GetDirectoryName(dialog.FileName);
                if (!string.IsNullOrEmpty(selectedPath))
                {
                    path = selectedPath;
                }
            }
        }

        private void SelectFile(string title, string filter, ref string filePath)
        {
            var dialog = new OpenFileDialog
            {
                Title = title,
                Filter = filter,
                CheckFileExists = true
            };

            if (!string.IsNullOrEmpty(filePath))
            {
                string directoryPath = Path.GetDirectoryName(filePath);
                if (Directory.Exists(directoryPath))
                {
                    dialog.InitialDirectory = directoryPath;
                }
                dialog.FileName = Path.GetFileName(filePath);
            }

            if (dialog.ShowDialog() == true)
            {
                filePath = dialog.FileName;
            }
        }
        #endregion

        [RelayCommand]
        private void NavigateToResourcePath()
        {
            var navigationService = App.Services.GetService(typeof(INavigationService)) as INavigationService;
            navigationService?.Navigate(typeof(ResourcePathPage));
        }

        [RelayCommand]
        private void NavigateToPersonalization()
        {
            var navigationService = App.Services.GetService(typeof(INavigationService)) as INavigationService;
            navigationService?.Navigate(typeof(PersonalizationPage));
        }

        [RelayCommand]
        private void NavigateToAbout()
        {
            var navigationService = App.Services.GetService(typeof(INavigationService)) as INavigationService;
            navigationService?.Navigate(typeof(AboutPage));
        }
    }
}
