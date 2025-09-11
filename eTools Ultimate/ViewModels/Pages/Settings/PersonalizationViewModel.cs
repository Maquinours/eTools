using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using eTools_Ultimate.Models;
using eTools_Ultimate.Properties;
using eTools_Ultimate.Services;
using Lepo.i18n;
using Microsoft.Extensions.Localization;
using System.Globalization;
using System.Windows.Media;
using Wpf.Ui;
using Wpf.Ui.Abstractions.Controls;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;
using Wpf.Ui.Extensions;

namespace eTools_Ultimate.ViewModels.Pages
{
    public partial class PersonalizationViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;

        private readonly IStringLocalizer _stringLocalizer;
        private readonly ILocalizationCultureManager _cultureManager;
        private readonly IContentDialogService _contentDialogService;
        private readonly AppConfig _appConfig;

        [ObservableProperty]
        private ApplicationTheme _currentApplicationTheme = ApplicationTheme.Unknown;

        public AppConfig AppConfig => _appConfig;

        public string DefaultCultureOptionLabel
        {
            get
            {
                CultureInfo ci = CultureInfo.CurrentUICulture.Name switch
                {
                    "fr-FR" or "de-DE" => CultureInfo.CurrentUICulture,
                    _ => new CultureInfo("en-US"),
                };

                var oldUiCulture = Thread.CurrentThread.CurrentUICulture;
                Thread.CurrentThread.CurrentUICulture = _cultureManager.GetCulture();
                string defaultCultureName = new CultureInfo(ci.TwoLetterISOLanguageName).DisplayName;
                Thread.CurrentThread.CurrentUICulture = oldUiCulture;

                return $"{_stringLocalizer["System language"]} ({defaultCultureName})";
            }
        }

        public PersonalizationViewModel(AppConfig appConfig, IStringLocalizer stringLocalizer, ILocalizationCultureManager cultureManager, IContentDialogService contentDialogService)
        {
            _appConfig = appConfig;
            _stringLocalizer = stringLocalizer;
            _cultureManager = cultureManager;
            _contentDialogService = contentDialogService;

            AppConfig.PropertyChanged += AppConfigService_PropertyChanged;
        }

        private async void AppConfigService_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(AppConfig.Language):
                    ContentDialogResult result = await _contentDialogService.ShowSimpleDialogAsync(
                        new SimpleContentDialogCreateOptions()
                        {
                            Title = "Application language changed",
                            Content = "The application needs to be restarted for the language change to take effect.",
                            PrimaryButtonText = "Restart",
                            CloseButtonText = "Restart later",
                        }
                );
                    if (result == ContentDialogResult.Primary)
                    {
                        System.Diagnostics.Process.Start(System.Diagnostics.Process.GetCurrentProcess().ProcessName);
                        App.Current.Shutdown();
                    }
                    break;
            }
        }

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