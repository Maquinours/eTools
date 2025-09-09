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
