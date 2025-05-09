using eTools_Ultimate.Services;
using System.Windows;

namespace eTools_Ultimate.Views.Windows
{
    public partial class SplashScreen : Window
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        public async Task Load()
        {
            await Task.Run(() =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    LoadingText.Text = "Loading settings...";
                });
                SettingsService.Load();
                Application.Current.Dispatcher.Invoke(() =>
                {
                    LoadingText.Text = "Loading defines...";
                });
                DefinesService.Instance.Load();
                Application.Current.Dispatcher.Invoke(() =>
                {
                    LoadingText.Text = "Loading strings...";
                });
                StringsService.Instance.Load();
                Application.Current.Dispatcher.Invoke(() =>
                {
                    LoadingText.Text = "Loading sounds config...";
                });
                SoundsService.Instance.Load();
                Application.Current.Dispatcher.Invoke(() =>
                {
                    LoadingText.Text = "Loading texts...";
                });
                TextsService.Instance.Load();
                Application.Current.Dispatcher.Invoke(() =>
                {
                    LoadingText.Text = "Loading movers...";
                });
                MoversService.Instance.Load();
                Application.Current.Dispatcher.Invoke(() =>
                {
                    LoadingText.Text = "Loading items...";
                });
                ItemsService.Instance.Load();
                Application.Current.Dispatcher.Invoke(() =>
                {
                    LoadingText.Text = "Loading giftboxes...";
                });
                GiftBoxesService.Instance.Load();
                Application.Current.Dispatcher.Invoke(() =>
                {
                    LoadingText.Text = "Loading exchanges...";
                });
                ExchangesService.Instance.Load();
                Application.Current.Dispatcher.Invoke(() =>
                {
                    LoadingText.Text = "Loading skills...";
                });
                CharactersService.Instance.Load();
                Application.Current.Dispatcher.Invoke(() =>
                {
                    LoadingText.Text = "Loading characters...";
                });
                SkillsService.Instance.Load();
                Application.Current.Dispatcher.Invoke(() =>
                {
                    LoadingText.Text = "Loading models...";
                });
                ModelsService.Instance.Load();
                Application.Current.Dispatcher.Invoke(() =>
                {
                    LoadingText.Text = "Loading honors...";
                });
                HonorsService.Instance.Load();
                Application.Current.Dispatcher.Invoke(() =>
                {
                    LoadingText.Text = "Loading motions...";
                });
                MotionsService.Instance.Load();
                Application.Current.Dispatcher.Invoke(() =>
                {
                    LoadingText.Text = "Loading accessories...";
                });
                AccessoriesService.Instance.Load();
                Application.Current.Dispatcher.Invoke(() =>
                {
                    LoadingText.Text = "Loading couple configuration...";
                });
                CoupleService.Instance.Load();
                ChangesTrackerService.Instance.Init();
            }).ConfigureAwait(true);
        }
    }
} 