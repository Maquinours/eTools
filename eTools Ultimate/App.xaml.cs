using eTools_Ultimate.Services;
using eTools_Ultimate.ViewModels.Pages;
using eTools_Ultimate.ViewModels.Windows;
using eTools_Ultimate.Views.Pages;
using eTools_Ultimate.Views.Pages.Motion;
using eTools_Ultimate.Views.Windows;
using eTools_Ultimate.Views.Pages.World;
using eTools_Ultimate.Views.Pages.Ticket;
using eTools_Ultimate.Views.Pages.TerrainObject;
using eTools_Ultimate.Views.Pages.Job;
using eTools_Ultimate.Views.Pages.Packitem;
using eTools_Ultimate.Views.Pages.Lord;
using eTools_Ultimate.Views.Pages.DropEvent;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Reflection;
using System.Windows.Threading;
using Wpf.Ui;
using Wpf.Ui.DependencyInjection;
using eTools_Ultimate.Views.Dialogs;
using eTools_Ultimate.ViewModels.Controls.Dialogs;

namespace eTools_Ultimate
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        // The.NET Generic Host provides dependency injection, configuration, logging, and other services.
        // https://docs.microsoft.com/dotnet/core/extensions/generic-host
        // https://docs.microsoft.com/dotnet/core/extensions/dependency-injection
        // https://docs.microsoft.com/dotnet/core/extensions/configuration
        // https://docs.microsoft.com/dotnet/core/extensions/logging
        private static readonly IHost _host = Host
            .CreateDefaultBuilder()
            .ConfigureAppConfiguration(c => { c.SetBasePath(Path.GetDirectoryName(AppContext.BaseDirectory) ?? throw new Exception("ConfigureAppConfiguration exception : Get app directory returned null")); })
            .ConfigureServices((context, services) =>
            {
                services.AddNavigationViewPageProvider();

                services.AddHostedService<ApplicationHostService>();

                // Theme manipulation
                services.AddSingleton<IThemeService, ThemeService>();

                // TaskBar manipulation
                services.AddSingleton<ITaskBarService, TaskBarService>();

                // Service containing navigation, same as INavigationWindow... but without window
                services.AddSingleton<INavigationService, NavigationService>();

                // Service for handling content dialogs
                services.AddSingleton<IContentDialogService, ContentDialogService>();

                // Service for handling snackbar notifications
                services.AddSingleton<ISnackbarService, SnackbarService>();

                // Splash screen
                services.AddSingleton<eTools_Ultimate.Views.Windows.SplashScreen>();
                services.AddSingleton<SplashScreenViewModel>();

                // Main window with navigation
                services.AddSingleton<INavigationWindow, MainWindow>();
                services.AddSingleton<MainWindowViewModel>();

                services.AddSingleton<DashboardPage>();
                services.AddSingleton<DashboardViewModel>();
                services.AddSingleton<ItemPage>();
                services.AddSingleton<SkillPage>();
                services.AddSingleton<QuestPage>();
                services.AddSingleton<NpcPage>();
                services.AddSingleton<GiftboxPage>();
                services.AddSingleton<CollectorPage>();
                services.AddSingleton<EventPage>();
                services.AddSingleton<eTools_Ultimate.Views.Pages.Accessory.AccessoryPage>();
                services.AddSingleton<ExchangerPage>();
                services.AddSingleton<TextClientPage>();
                services.AddSingleton<MoverPage>();
                services.AddSingleton<CouplePage>();
                services.AddSingleton<eTools_Ultimate.Views.Pages.Honor.HonorPage>();
                services.AddSingleton<eTools_Ultimate.Views.Pages.Motion.MotionPage>();
                services.AddSingleton<DataViewModel>();
                services.AddSingleton<SkillsViewModel>();
                services.AddSingleton<MoversViewModel>();
                services.AddSingleton<TextClientViewModel>();
                services.AddSingleton<GiftBoxesViewModel>();
                services.AddSingleton<ExchangesViewModel>();
                services.AddSingleton<CharactersViewModel>();
                services.AddSingleton<CoupleViewModel>();
                services.AddSingleton<HonorViewModel>();
                services.AddSingleton<MotionsViewModel>();
                services.AddSingleton<HonorsViewModel>();
                services.AddSingleton<AccessoriesViewModel>();
                services.AddSingleton<TerrainsViewModel>();

                // Neue Seiten
                services.AddSingleton<WorldPage>();
                services.AddSingleton<TicketPage>();
                services.AddSingleton<TerrainObjectPage>();
                services.AddSingleton<JobPage>();
                services.AddSingleton<PackitemPage>();
                services.AddSingleton<LordPage>();
                services.AddSingleton<DropEventPage>();

                // Settings pages
                services.AddSingleton<SettingsPage>();
                services.AddSingleton<SettingsViewModel>();

                services.AddSingleton<ResourcePathPage>();
                services.AddSingleton<ResourcePathViewModel>();
                services.AddSingleton<PersonalizationPage>();
                services.AddSingleton<PersonalizationViewModel>();
                services.AddSingleton<AboutPage>();
                services.AddSingleton<AboutViewModel>();

                // ChangeLog Page
                services.AddSingleton<eTools.Views.Pages.ChangeLog.ChangeLogView>();
                services.AddSingleton<eTools_Ultimate.ViewModels.Pages.ChangeLog.ChangeLogViewModel>();
            }).Build();

        /// <summary>
        /// Gets services.
        /// </summary>
        public static IServiceProvider Services
        {
            get { return _host.Services; }
        }

        /// <summary>
        /// Occurs when the application is loading.
        /// </summary>
        private async void OnStartup(object sender, StartupEventArgs e)
        {
            await _host.StartAsync();
        }

        /// <summary>
        /// Occurs when the application is closing.
        /// </summary>
        private async void OnExit(object sender, ExitEventArgs e)
        {
            await _host.StopAsync();

            _host.Dispose();
        }

        /// <summary>
        /// Occurs when an exception is thrown by an application but not handled.
        /// </summary>
        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            // For more info see https://docs.microsoft.com/en-us/dotnet/api/system.windows.application.dispatcherunhandledexception?view=windowsdesktop-6.0
        }
    }
}
