using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;

namespace eTools_Ultimate.ViewModels.Pages
{
    public partial class PersonalizationViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isLightTheme;

        [ObservableProperty]
        private bool _isDarkTheme;

        [ObservableProperty]
        private bool _isCompactMode;

        public PersonalizationViewModel()
        {
            // Initialize theme based on current system theme
            ApplicationTheme currentTheme = ApplicationThemeManager.GetAppTheme();
            IsDarkTheme = currentTheme == ApplicationTheme.Dark;
            
            // Standard-Werte für andere Einstellungen
            IsCompactMode = false;
        }

        [RelayCommand]
        private void OnChangeTheme(string parameter)
        {
            switch (parameter)
            {
                case "theme_light":
                    if (!IsLightTheme)
                    {
                        IsLightTheme = true;
                        IsDarkTheme = false;
                        ApplicationThemeManager.Apply(ApplicationTheme.Light);
                    }
                    break;
                case "theme_dark":
                    if (!IsDarkTheme)
                    {
                        IsDarkTheme = true;
                        IsLightTheme = false;
                        ApplicationThemeManager.Apply(ApplicationTheme.Dark);
                    }
                    break;
            }
        }
    }
} 