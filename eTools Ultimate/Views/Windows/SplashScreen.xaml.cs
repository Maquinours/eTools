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
                ("Loading texts...", TextsService.Instance.Load),
                ("Loading giftboxes...", GiftBoxesService.Instance.Load),
                ("Loading exchanges...", ExchangesService.Instance.Load),
                ("Loading honors...", HonorsService.Instance.Load),
                ("Loading motions...", MotionsService.Instance.Load),
                ("Loading accessories...", AccessoriesService.Instance.Load),
                ("Loading couple configuration...", CoupleService.Instance.Load),
                ("Loading tickets...", TicketsService.Instance.Load),
                ("Loading pack items...", PackItemsService.Instance.Load)
                ];

            await Task.Run(() =>
            {
                for(int i = 0; i < loadingSteps.Length; i++)
                {
                    (string text, Action loader) = loadingSteps[i];

                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        LoadingText.Text = text;
                    });
                    loader();
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        taskbarItemInfo.ProgressValue = (i + 1) / (double)loadingSteps.Length;
                    });
                }

                ChangesTrackerService.Instance.Init();
            }).ConfigureAwait(true);
        }
    }
} 