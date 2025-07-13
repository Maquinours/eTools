using eTools_Ultimate.Models;
using eTools_Ultimate.Views.Dialogs;
using eTools_Ultimate.Views.Pages;
using eTools_Ultimate.Views.Pages.DropEvent;
using eTools_Ultimate.Views.Pages.Honor;
using eTools_Ultimate.Views.Pages.Job;
using eTools_Ultimate.Views.Pages.Lord;
using eTools_Ultimate.Views.Pages.Motion;
using eTools_Ultimate.Views.Pages.Packitem;
using eTools_Ultimate.Views.Pages.Object;
using eTools_Ultimate.Views.Pages.Ticket;
using eTools_Ultimate.Views.Pages.World;
using eTools_Ultimate.Views.Pages.TerrainObject;
using System.Windows.Navigation;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace eTools_Ultimate.ViewModels.Pages
{
    public partial class DashboardViewModel(IContentDialogService contentDialogService, INavigationService navigationService) : ObservableObject
    {
        public NavigationCard[] NavigationCards { get; } =
        [
            new("Items", "Navigate to the items page.", "/eTools Ultimate;component/Assets/Icons/Items.png", typeof(ItemPage)),
            new("Movers", "Navigate to the movers page.", "/eTools Ultimate;component/Assets/Icons/Movers.png", typeof(MoverPage)),
            new("Skills", "Navigate to the skills page.", "/eTools Ultimate;component/Assets/Icons/Skills.png", typeof(SkillPage)),
            new("Quests", "Navigate to the quests page.", "/eTools Ultimate;component/Assets/Icons/Quests.png", typeof(QuestPage)),
            new("NPCs", "Navigate to the NPCs page.", "/eTools Ultimate;component/Assets/Icons/Characters.png", typeof(NpcPage)),
            new("Events", "Navigate to the events page.", "/eTools Ultimate;component/Assets/Icons/Events.png", typeof(EventPage)),
            new("Giftboxes", "Navigate to the giftboxes page.", "/eTools Ultimate;component/Assets/Icons/Giftboxes.png", typeof(GiftboxPage)),
            new("Collectors", "Navigate to the collectors page.", "/eTools Ultimate;component/Assets/Icons/Collector.png", typeof(CollectorPage)),
            new("Accessories", "Navigate to the accessories page.", "/eTools Ultimate;component/Assets/Icons/Accessories.png", typeof(eTools_Ultimate.Views.Pages.Accessory.AccessoryPage)),
            new("Exchangers", "Navigate to the exchanger page.", "/eTools Ultimate;component/Assets/Icons/Exchangers.png", typeof(ExchangerPage)),
            new("Honor List", "Navigate to the honor list page.", "/eTools Ultimate;component/Assets/Icons/Honors.png", typeof(HonorPage)),
            new("Couple", "Navigate to the couple page.", "/eTools Ultimate;component/Assets/Icons/Accessories.png", typeof(CouplePage)),
            new("Motions", "Navigate to the motions page.", "/eTools Ultimate;component/Assets/Icons/Motions.png", typeof(MotionPage)),
            new("Text Client", "Navigate to the text client.", "/eTools Ultimate;component/Assets/Icons/Texts.png", typeof(TextClientPage)),
            new("World", "Navigate to the world editor.", "/eTools Ultimate;component/Assets/Icons/World.png", typeof(WorldPage)),
            new("Tickets", "Navigate to the ticket editor.", "/eTools Ultimate;component/Assets/Icons/Tickets.png", typeof(TicketPage)),
            new("Object", "Navigate to the object editor.", "/eTools Ultimate;component/Assets/Icons/Terrain.png", typeof(ObjectPage)),
            new("Terrain", "Navigate to the terrain editor.", "/eTools Ultimate;component/Assets/Icons/Terrain.png", typeof(TerrainObjectPage)),
            new("Job", "Navigate to the job editor.", "/eTools Ultimate;component/Assets/Icons/Job.png", typeof(JobPage)),
            new("Packitem", "Navigate to the packitem editor.", "/eTools Ultimate;component/Assets/Icons/PackItem.png", typeof(PackitemPage)),
            new("Lord", "Navigate to the lord editor.", "/eTools Ultimate;component/Assets/Icons/Lord.png", typeof(LordPage)),
            new("Drop Event", "Navigate to the drop event editor.", "/eTools Ultimate;component/Assets/Icons/DropEvent.png", typeof(DropEventPage)),
            new("Settings", "Navigate to the settings page.", "/eTools Ultimate;component/Assets/Icons/Settings.png", typeof(SettingsPage))
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
    }
}
