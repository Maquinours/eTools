using eTools.Views.Windows;
using eTools_Ultimate.Services;
using eTools_Ultimate.Views.Pages;
using eTools_Ultimate.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shell;
using Wpf.Ui;
using Wpf.Ui.Extensions;

namespace eTools_Ultimate.ViewModels.Windows
{
    public class CloseSplashScreenMessage { }

    public partial class SplashScreenViewModel(IServiceProvider serviceProvider) : ObservableObject
    {
        [ObservableProperty]
        private string _loadingText = string.Empty;

        [ObservableProperty]
        private double _loadingProgress = 0;

        [ObservableProperty]
        private string _version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "1.0.0";

        public event EventHandler? Loaded;

        [RelayCommand]
        public async Task Load()
        {
            (string text, Action loader)[] loadingSteps = [
                ("Loading settings...", SettingsService.Load),
                ("Loading defines...", DefinesService.Instance.Load),
                ("Loading strings...", StringsService.Instance.Load),
                ("Loading models...", ModelsService.Instance.Load),
                ("Loading items...", ItemsService.Instance.Load),
                ("Loading movers...", MoversService.Instance.Load),
                ("Loading skills...", SkillsService.Instance.Load),
                ("Loading characters...", CharactersService.Instance.Load),
                ("Loading sounds config...", SoundsService.Instance.Load),
                ("Loading musics config...", MusicsService.Instance.Load),
                ("Loading texts...", TextsService.Instance.Load),
                ("Loading giftboxes...", GiftBoxesService.Instance.Load),
                ("Loading exchanges...", ExchangesService.Instance.Load),
                ("Loading honors...", HonorsService.Instance.Load),
                ("Loading motions...", MotionsService.Instance.Load),
                ("Loading accessories...", AccessoriesService.Instance.Load),
                ("Loading couple configuration...", CoupleService.Instance.Load),
                ("Loading tickets...", TicketsService.Instance.Load),
                ("Loading pack items...", PackItemsService.Instance.Load),
                ("Loading terrains...", TerrainsService.Instance.Load)
                ];

            if (serviceProvider.GetService(typeof(INavigationWindow)) is not MainWindow mainWindow) throw new InvalidOperationException("SplashScreenViewModel::Load exception : Unable to find MainWindow");

            try
            {
                await Task.Run(() =>
                {
                    for (int i = 0; i < loadingSteps.Length; i++)
                    {
                        (string text, Action loader) = loadingSteps[i];

                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            LoadingText = text;
                        });
                        loader();
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            LoadingProgress = (i + 1) / (double)loadingSteps.Length;
                        });
                    }

                    //ChangesTrackerService.Instance.Init();
                }).ConfigureAwait(true);

            Loaded?.Invoke(this, EventArgs.Empty);

            mainWindow.ShowWindow();
            mainWindow.Navigate(typeof(DashboardPage));
            } catch(Exception ex)
            {
                LoadingErrorWindow errorWindow = new(ex.Message);
                if(errorWindow.ShowDialog() == true)
                {
                    Loaded?.Invoke(this, EventArgs.Empty);
                    mainWindow.ShowWindow();
                    mainWindow.Navigate(typeof(ResourcePathPage));

                }
                else 
                    Application.Current.Shutdown();
                //        MessageBox.Show($"Une erreur est survenue : {ex.Message}\n\nVoulez-vous ouvrir les paramètres ?",
                //"Erreur",
                //MessageBoxButton.YesNo,
                //MessageBoxImage.Error);
                //await contentDialogService.ShowSimpleDialogAsync(new() { Title = "Loading error", Content = ex.Message, PrimaryButtonText = "Access settings", CloseButtonText = "Close application" });
            }
            //if (loadingError)
            //    _navigationWindow!.Navigate(typeof(ResourcePathPage));
            //else
            //    _navigationWindow!.Navigate(typeof(DashboardPage));
        }
    }
}
