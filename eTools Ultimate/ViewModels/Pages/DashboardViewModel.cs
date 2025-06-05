using eTools_Ultimate.Models;
using eTools_Ultimate.Views.Dialogs;
using eTools_Ultimate.Views.Pages;
using eTools_Ultimate.Views.Pages.DropEvent;
using eTools_Ultimate.Views.Pages.Honor;
using eTools_Ultimate.Views.Pages.Job;
using eTools_Ultimate.Views.Pages.Lord;
using eTools_Ultimate.Views.Pages.Motion;
using eTools_Ultimate.Views.Pages.Packitem;
using eTools_Ultimate.Views.Pages.TerrainObject;
using eTools_Ultimate.Views.Pages.Ticket;
using eTools_Ultimate.Views.Pages.World;
using System.Windows.Navigation;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace eTools_Ultimate.ViewModels.Pages
{
    public partial class DashboardViewModel(IContentDialogService contentDialogService, INavigationService navigationService) : ObservableObject
    {
        public NavigationCard[] NavigationCards { get; } =
        [
            new("Items", "Navigate to the items page.", "/eTools Ultimate;component/Views/Pages/Home/Icons/Icon_6.png", typeof(ItemPage)),
            new("Movers", "Navigate to the movers page.", "/eTools Ultimate;component/Views/Pages/Home/Icons/Icon_2.png", typeof(MoverPage)),
            new("Skills", "Navigate to the skills page.", "/eTools Ultimate;component/Views/Pages/Home/Icons/Icon_12.png", typeof(SkillPage)),
            new("Quests", "Navigate to the quests page.", "/eTools Ultimate;component/Views/Pages/Home/Icons/Icon_10.png", typeof(QuestPage)),
            new("NPCs", "Navigate to the NPCs page.", "/eTools Ultimate;component/Views/Pages/Home/Icons/Icon_4.png", typeof(NpcPage)),
            new("Events", "Navigate to the events page.", "/eTools Ultimate;component/Views/Pages/Home/Icons/Icon_9.png", typeof(EventPage)),
            new("Giftboxes", "Navigate to the giftboxes page.", "/eTools Ultimate;component/Views/Pages/Home/Icons/Icon_5.png", typeof(GiftboxPage)),
            new("Collectors", "Navigate to the collectors page.", "/eTools Ultimate;component/Views/Pages/Home/Icons/Icon_1.png", typeof(CollectorPage)),
            new("Accessories", "Navigate to the accessories page.", "/eTools Ultimate;component/Views/Pages/Home/Icons/Icon_8.png", typeof(eTools_Ultimate.Views.Pages.Accessory.AccessoryPage)),
            new("Exchangers", "Navigate to the exchanger page.", "/eTools Ultimate;component/Views/Pages/Home/Icons/Icon_3.png", typeof(ExchangerPage)),
            new("Honor List", "Navigate to the honor list page.", "/eTools Ultimate;component/Views/Pages/Home/Icons/Icon_14.png", typeof(HonorPage)),
            new("Couple", "Navigate to the couple page.", "/eTools Ultimate;component/Views/Pages/Home/Icons/Icon_8.png", typeof(CouplePage)),
            new("Motions", "Navigate to the motions page.", "/eTools Ultimate;component/Views/Pages/Home/Icons/Icon_13.png", typeof(MotionPage)),
            new("Text Client", "Navigate to the text client.", "/eTools Ultimate;component/Views/Pages/Home/Icons/Icon_7.png", typeof(TextClientPage)),
            new("World", "Navigate to the world editor.", "/eTools Ultimate;component/Views/Pages/Home/Icons/Icon_15.png", typeof(WorldPage)),
            new("Ticket", "Navigate to the ticket editor.", "/eTools Ultimate;component/Views/Pages/Home/Icons/Icon_16.png", typeof(TicketPage)),
            new("Terrain/Object", "Navigate to the terrain/object editor.", "/eTools Ultimate;component/Views/Pages/Home/Icons/Icon_17.png", typeof(TerrainObjectPage)),
            new("Job", "Navigate to the job editor.", "/eTools Ultimate;component/Views/Pages/Home/Icons/Icon_18.png", typeof(JobPage)),
            new("Packitem", "Navigate to the packitem editor.", "/eTools Ultimate;component/Views/Pages/Home/Icons/Icon_19.png", typeof(PackitemPage)),
            new("Lord", "Navigate to the lord editor.", "/eTools Ultimate;component/Views/Pages/Home/Icons/Icon_20.png", typeof(LordPage)),
            new("Drop Event", "Navigate to the drop event editor.", "/eTools Ultimate;component/Views/Pages/Home/Icons/Icon_21.png", typeof(DropEventPage)),
            new("Settings", "Navigate to the settings page.", "/eTools Ultimate;component/Views/Pages/Home/Icons/Icon_11.png", typeof(SettingsPage))
        ];

        [RelayCommand]
        private void OpenCardPage(NavigationCard navigationCard)
        {
            if (navigationCard.TargetPageType != null)
            {
                navigationService.Navigate(navigationCard.TargetPageType);
            }
        }

        [RelayCommand]
        private async Task OpenPatchNotesDialog()
        {
            var patchNotesDialog = new PatchNotesDialog(contentDialogService.GetDialogHost());

            await patchNotesDialog.ShowAsync();
        }

        [RelayCommand]
        private void OpenDiscordLink()
        {
            // Discord invite link
            string discordUrl = "https://discord.gg/aGZYxkjWxh";

            // Open URL in default browser
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = discordUrl,
                UseShellExecute = true
            });
        }

        [RelayCommand]
        private void OpenGithubLink()
        {
            // GitHub repository link
            string githubUrl = "https://github.com/Maquinours/eTools";

            // Open URL in default browser
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = githubUrl,
                UseShellExecute = true
            });
        }
    }
}
