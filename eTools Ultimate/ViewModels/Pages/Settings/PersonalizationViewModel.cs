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
    public partial class PersonalizationViewModel(IStringLocalizer stringLocalizer, ILocalizationCultureManager cultureManager, IContentDialogService contentDialogService, AppConfig appConfig) : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;

        public AppConfig AppConfig => appConfig;

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
                Thread.CurrentThread.CurrentUICulture = cultureManager.GetCulture();
                string defaultCultureName = new CultureInfo(ci.TwoLetterISOLanguageName).DisplayName;
                Thread.CurrentThread.CurrentUICulture = oldUiCulture;

                return $"{stringLocalizer["System default"]} ({defaultCultureName})";
            }
        }

        public Task OnNavigatedToAsync()
        {
            if (!_isInitialized)
                InitializeViewModel();

            return Task.CompletedTask;
        }

        public Task OnNavigatedFromAsync() => Task.CompletedTask;

        private void InitializeViewModel()
        {
            AppConfig.PropertyChanged += AppConfigService_PropertyChanged;

            _isInitialized = true;
        }

        private async void AppConfigService_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(AppConfig.Language):
                    ContentDialogResult result = await contentDialogService.ShowSimpleDialogAsync(
                        new SimpleContentDialogCreateOptions()
                        {
                            Title = stringLocalizer["Application language changed"] ?? "Application language changed",
                            Content = stringLocalizer["The application needs to be restarted for the language change to take effect."] ?? "The application needs to be restarted for the language change to take effect.",
                            PrimaryButtonText = stringLocalizer["Restart"] ?? "Restart",
                            CloseButtonText = stringLocalizer["Restart later"] ?? "Restart later",
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
    }
}