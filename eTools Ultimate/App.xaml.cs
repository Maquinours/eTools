using eTools_Ultimate.Models;
using eTools_Ultimate.Resources;
using eTools_Ultimate.Services;
using eTools_Ultimate.ViewModels.Controls.Dialogs;
using eTools_Ultimate.ViewModels.Pages;
using eTools_Ultimate.ViewModels.Windows;
using eTools_Ultimate.Views.Dialogs;
using eTools_Ultimate.Views.Pages;
using eTools_Ultimate.Views.Windows;
using Lepo.i18n.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Reflection;
using System.Windows.Threading;
using Velopack;
using Velopack.Sources;
using Wpf.Ui;
using Wpf.Ui.DependencyInjection;

namespace eTools_Ultimate
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
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

                services.AddSingleton<AppConfig>();

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

                services.AddSingleton<SettingsService>();
                services.AddSingleton<DefinesService>();
                services.AddSingleton<StringsService>();
                services.AddSingleton<ModelsService>();
                services.AddSingleton<ItemsService>();
                services.AddSingleton<MoversService>();
                //services.AddSingleton<SkillsService>();
                //services.AddSingleton<CharactersService>();
                services.AddSingleton<SoundsService>();
                //services.AddSingleton<MusicsService>();
                services.AddSingleton<TextsService>();
                services.AddSingleton<GiftBoxesService>();
                //services.AddSingleton<ExchangesService>();
                //services.AddSingleton<HonorsService>();
                services.AddSingleton<MotionsService>();
                services.AddSingleton<AccessoriesService>();
                //services.AddSingleton<CoupleService>();
                //services.AddSingleton<TicketsService>();
                //services.AddSingleton<PackItemsService>();
                //services.AddSingleton<TerrainsService>();

                // Splash screen
                services.AddSingleton<eTools_Ultimate.Views.Windows.SplashScreen>();
                services.AddSingleton<SplashScreenViewModel>();

                // Main window with navigation
                services.AddSingleton<INavigationWindow, MainWindow>();
                services.AddSingleton<MainWindowViewModel>();

                // Top level pages
                services.AddSingleton<DashboardPage>();
                services.AddSingleton<DashboardViewModel>();
                //services.AddSingleton<ItemsPage>();
                //services.AddSingleton<ItemsViewModel>();
                //services.AddSingleton<SkillPage>();
                //services.AddSingleton<SkillsViewModel>();
                //services.AddSingleton<QuestsPage>();
                //services.AddSingleton<CharactersPage>();
                //services.AddSingleton<CharactersViewModel>();
                services.AddSingleton<GiftboxesPage>();
                services.AddSingleton<GiftBoxesViewModel>();
                //services.AddSingleton<CollectorPage>();
                //services.AddSingleton<EventPage>();
                services.AddSingleton<AccessoriesPage>();
                services.AddSingleton<AccessoriesViewModel>();
                //services.AddSingleton<ExchangerPage>();
                //services.AddSingleton<ExchangesViewModel>();
                services.AddSingleton<TextsPage>();
                services.AddSingleton<TextsViewModel>();
                services.AddSingleton<MoversPage>();
                services.AddSingleton<MoversViewModel>();
                //services.AddSingleton<CouplePage>();
                //services.AddSingleton<CoupleViewModel>();
                //services.AddSingleton<HonorsPage>();
                //services.AddSingleton<HonorsViewModel>();
                services.AddSingleton<MotionsPage>();
                services.AddSingleton<MotionsViewModel>();
                //services.AddSingleton<WorldsPage>();
                //services.AddSingleton<TicketsPage>();
                //services.AddSingleton<ObjectsPage>();
                //services.AddSingleton<ObjectsViewModel>();
                //services.AddSingleton<TerrainsPage>();
                //services.AddSingleton<TerrainsViewModel>();
                //services.AddSingleton<JobsPage>();
                //services.AddSingleton<PackitemsPage>();
                //services.AddSingleton<LordsPage>();
                //services.AddSingleton<DropEventsPage>();

                // Settings pages
                services.AddSingleton<SettingsPage>();
                services.AddSingleton<SettingsViewModel>();

                services.AddSingleton<ConfigurationPage>();
                services.AddSingleton<ConfigurationViewModel>();
                services.AddSingleton<PersonalizationPage>();
                services.AddSingleton<PersonalizationViewModel>();
                services.AddSingleton<AboutPage>();
                services.AddSingleton<AboutViewModel>();

                // ChangeLog Page
                services.AddSingleton<eTools_Ultimate.Views.Pages.ChangeLog.ChangeLogView>();
                services.AddSingleton<eTools_Ultimate.ViewModels.Pages.ChangeLog.ChangeLogViewModel>();

                // Localizers
                services.AddStringLocalizer(b =>
                {
                    b.FromResource<Translations>(new("fr-FR"));
                    b.FromResource<Translations>(new("de-DE"));
                    if (eTools_Ultimate.Properties.Settings.Default.Language != "Default")
                        b.SetCulture(new(eTools_Ultimate.Properties.Settings.Default.Language));
                });
            }).Build();

        /// <summary>
        /// Gets services.
        /// </summary>
        public static IServiceProvider Services
        {
            get { return _host.Services; }
        }

        public App()
        {
            DispatcherUnhandledException += App_DispatcherUnhandledException;

            SentrySdk.Init(options =>
            {
                // Tells which project in Sentry to send events to:
                options.Dsn = "https://277eaccab2ab24d44b8e761e7cfabeaf@o4510028470812672.ingest.de.sentry.io/4510028473499728";
                // When configuring for the first time, to see what the SDK is doing:
                options.Debug = false;
                options.Release = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "unknown";

                // Enable Global Mode since this is a client app
                options.IsGlobalModeEnabled = true;
            });
        }

        void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            SentrySdk.CaptureException(e.Exception);

            // If you want to avoid the application from crashing:
            e.Handled = true;
        }

        /// <summary>
        /// Entry point
        /// </summary>
        /// <param name="args">Args to run the app</param>
        [STAThread]
        private static void Main(string[] args)
        {
            VelopackApp.Build().Run();
            App app = new();
            app.InitializeComponent();
            app.Run();
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
