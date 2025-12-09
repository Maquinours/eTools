using eTools.Views.Windows;
using eTools_Ultimate.Resources;
using eTools_Ultimate.Services;
using eTools_Ultimate.Views.Pages;
using eTools_Ultimate.Views.Windows;
using Microsoft.Extensions.Localization;
using Serilog;
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

    public partial class SplashScreenViewModel(
        INavigationWindow mainWindow,
        SettingsService settingsService,
        DefinesService definesService,
        StringsService stringsService,
        ModelsService modelsService,
        ItemsService itemsService,
        MoversService moversService,
        //SkillsService skillsService,
        //CharactersService charactersService,
        SoundsService soundsService,
        //MusicsService musicsService,
        TextsService textsService,
        GiftBoxesService giftBoxesService,
        //ExchangesService exchangesService,
        //HonorsService honorsService,
        MotionsService motionsService,
        AccessoriesService accessoriesService,
        //CoupleService coupleService,
        //TicketsService ticketsService,
        //PackItemsService packItemsService,
        //TerrainsService terrainsService,
        IStringLocalizer<Translations> localizer
        ) : ObservableObject
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
                ("Loading settings...", settingsService.Load),
                ("Loading definitions...", definesService.Load),
                ("Loading strings...", stringsService.Load),
                ("Loading models...", modelsService.Load),
                ("Loading items...", itemsService.Load),
                ("Loading movers...", moversService.Load),
                //("Loading skills...", skillsService.Load),
                //("Loading characters...", charactersService.Load),
                ("Loading sounds...", soundsService.Load),
                //("Loading musics config...", musicsService.Load),
                ("Loading texts...", textsService.Load),
                ("Loading giftboxes...", giftBoxesService.Load),
                //("Loading exchanges...", exchangesService.Load),
                //("Loading honors...", honorsService.Load),
                ("Loading motions...", motionsService.Load),
                ("Loading accessories...", accessoriesService.Load),
                //("Loading couple configuration...", coupleService.Load),
                //("Loading tickets...", ticketsService.Load),
                //("Loading pack items...", packItemsService.Load),
                //("Loading terrains...", terrainsService.Load)
                ];

            try
            {
                await Task.Run(() =>
                {
                    for (int i = 0; i < loadingSteps.Length; i++)
                    {
                        (string text, Action loader) = loadingSteps[i];

                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            LoadingText = localizer[text];
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
            }
            catch (Exception ex)
            {
                Loaded?.Invoke(this, EventArgs.Empty);

                Log.Error(ex, "An error occured while loading resources");

                LoadingErrorWindow errorWindow = new(ex);
                if (errorWindow.ShowDialog() == true)
                {
                    mainWindow.ShowWindow();
                    mainWindow.Navigate(typeof(ConfigurationPage));

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
