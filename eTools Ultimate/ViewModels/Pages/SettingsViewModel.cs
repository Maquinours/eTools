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
    public partial class SettingsViewModel(SettingsService settingsService, INavigationService navigationService) : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;

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
            _isInitialized = true;
        }

        [RelayCommand]
        private void NavigateToResourcePath()
        {
            navigationService.Navigate(typeof(ConfigurationPage));
        }

        [RelayCommand]
        private void NavigateToPersonalization()
        {
            navigationService.Navigate(typeof(PersonalizationPage));
        }

        [RelayCommand]
        private void NavigateToAbout()
        {
            navigationService.Navigate(typeof(AboutPage));
        }
    }
}
