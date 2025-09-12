using eTools_Ultimate.Models;
using eTools_Ultimate.Services;
using eTools_Ultimate.ViewModels.Windows;
using eTools_Ultimate.Views.Pages;
using Microsoft.Extensions.DependencyInjection;
using Wpf.Ui;
using Wpf.Ui.Abstractions;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;

namespace eTools_Ultimate.Views.Windows
{
    public partial class MainWindow : INavigationWindow
    {
        public MainWindowViewModel ViewModel { get; set; } = null!;

        public MainWindow()
        {
            // Design-time constructor
            InitializeComponent();
        }

        public MainWindow(
            MainWindowViewModel viewModel,
            INavigationViewPageProvider navigationViewPageProvider,
            INavigationService navigationService,
            ISnackbarService snackbarService,
            IContentDialogService contentDialogService,
            AppConfig appConfig
        ) : this()
        {
            ViewModel = viewModel;
            DataContext = this;

            SetTheme();
            appConfig.PropertyChanged += AppConfig_PropertyChanged;

            this.Visibility = Visibility.Hidden;
            InitializeComponent();
            SetPageService(navigationViewPageProvider);

            snackbarService.SetSnackbarPresenter(SnackbarPresenter);
            navigationService.SetNavigationControl(RootNavigation);
            contentDialogService.SetDialogHost(RootContentDialog);
        }

        #region INavigationWindow methods

        public INavigationView GetNavigation() => RootNavigation;

        public bool Navigate(Type pageType) => RootNavigation.Navigate(pageType);

        public void SetPageService(INavigationViewPageProvider navigationViewPageProvider) => RootNavigation.SetPageProviderService(navigationViewPageProvider);

        public void ShowWindow() => Show();

        public void CloseWindow() => Close();

        #endregion INavigationWindow methods

        /// <summary>
        /// Raises the closed event.
        /// </summary>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // Make sure that closing this window will begin the process of closing the application.
            Application.Current.Shutdown();
        }

        INavigationView INavigationWindow.GetNavigation()
        {
            throw new NotImplementedException();
        }

        public void SetServiceProvider(IServiceProvider serviceProvider)
        {
            throw new NotImplementedException();
        }
        private void RootNavigation_Navigated(NavigationView sender, NavigatedEventArgs args)
        {
            if (args.Page is ResourcePathPage or PersonalizationPage) // show ony on this pages the title
                BreadcrumbBar.Visibility = Visibility.Visible;
            else
                BreadcrumbBar.Visibility = Visibility.Collapsed;
        }

        private void SetTheme()
        {
            AppConfig appConfig = App.Services.GetRequiredService<AppConfig>();

            if(IsLoaded)
                SystemThemeWatcher.UnWatch(this);

            if (appConfig.Theme.HasValue)
                ApplicationThemeManager.Apply(appConfig.Theme.Value);
            else
            {
                ApplicationThemeManager.ApplySystemTheme();
                SystemThemeWatcher.Watch(this);
            }
        }

        private void AppConfig_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(AppConfig.Theme))
                SetTheme();
        }
    }
}
