using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Media;
using Wpf.Ui.Abstractions.Controls;
using Wpf.Ui.Appearance;

namespace eTools_Ultimate.ViewModels.Pages
{
    public partial class PersonalizationViewModel: ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;

        [ObservableProperty]
        private ApplicationTheme _currentApplicationTheme = ApplicationTheme.Unknown;

        public Task OnNavigatedToAsync()
        {
            if (!_isInitialized)
                InitializeViewModel();

            return Task.CompletedTask;
        }

        public Task OnNavigatedFromAsync() => Task.CompletedTask;

        partial void OnCurrentApplicationThemeChanged(ApplicationTheme oldValue, ApplicationTheme newValue)
        {
            ApplicationThemeManager.Apply(newValue);
        }

        private void InitializeViewModel()
        {
            CurrentApplicationTheme = ApplicationThemeManager.GetAppTheme();

            ApplicationThemeManager.Changed += OnThemeChanged;

            _isInitialized = true;
        }

        private void OnThemeChanged(ApplicationTheme currentApplicationTheme, Color systemAccent)
        {
            // Update the theme if it has been changed elsewhere than in the settings.
            if (CurrentApplicationTheme != currentApplicationTheme)
            {
                CurrentApplicationTheme = currentApplicationTheme;
            }
        }
    }
} 