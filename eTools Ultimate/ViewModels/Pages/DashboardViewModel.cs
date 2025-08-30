using eTools_Ultimate.Models;
using eTools_Ultimate.Resources;
using eTools_Ultimate.Views.Dialogs;
using eTools_Ultimate.Views.Pages;
using eTools_Ultimate.Views.Pages.DropEvent;
using eTools_Ultimate.Views.Pages.Honor;
using eTools_Ultimate.Views.Pages.Job;
using eTools_Ultimate.Views.Pages.Lord;
using eTools_Ultimate.Views.Pages.Motion;
using eTools_Ultimate.Views.Pages.Object;
using eTools_Ultimate.Views.Pages.Packitem;
using eTools_Ultimate.Views.Pages.TerrainObject;
using eTools_Ultimate.Views.Pages.Ticket;
using eTools_Ultimate.Views.Pages.World;
using Microsoft.Extensions.Localization;
using System.Resources;
using System.Windows.Navigation;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace eTools_Ultimate.ViewModels.Pages
{
    public partial class DashboardViewModel(IContentDialogService contentDialogService, INavigationService navigationService, IStringLocalizer<Translations> localizer) : ObservableObject
    {
        public NavigationCard[] NavigationCards { get; } =
        [
            new(localizer["Items"], localizer["Navigate to the items page."], "/eTools Ultimate;component/Assets/Icons/Items.png", typeof(ItemPage)),
            new(localizer["Movers"], localizer["Navigate to the movers page."], "/eTools Ultimate;component/Assets/Icons/Movers.png", typeof(MoverPage)),
            new(localizer["Skills"], localizer["Navigate to the skills page."], "/eTools Ultimate;component/Assets/Icons/Skills.png", typeof(SkillPage)),
            new(localizer["Quests"], localizer["Navigate to the quests page."], "/eTools Ultimate;component/Assets/Icons/Quests.png", typeof(QuestPage)),
            new(localizer["NPCs"], localizer["Navigate to the NPCs page."], "/eTools Ultimate;component/Assets/Icons/Characters.png", typeof(NpcPage)),
            new(localizer["Events"], localizer["Navigate to the events page."], "/eTools Ultimate;component/Assets/Icons/Events.png", typeof(EventPage)),
            new(localizer["Giftboxes"], localizer["Navigate to the giftboxes page."], "/eTools Ultimate;component/Assets/Icons/Giftboxes.png", typeof(GiftboxPage)),
            new(localizer["Collectors"], localizer["Navigate to the collectors page."], "/eTools Ultimate;component/Assets/Icons/Collector.png", typeof(CollectorPage)),
            new(localizer["Accessories"], localizer["Navigate to the accessories page."], "/eTools Ultimate;component/Assets/Icons/Accessories.png", typeof(eTools_Ultimate.Views.Pages.Accessory.AccessoryPage)),
            new(localizer["Exchangers"], localizer["Navigate to the exchanger page."], "/eTools Ultimate;component/Assets/Icons/Exchangers.png", typeof(ExchangerPage)),
            new(localizer["Honor List"], localizer["Navigate to the honor list page."], "/eTools Ultimate;component/Assets/Icons/Honors.png", typeof(HonorPage)),
            new(localizer["Couple"], localizer["Navigate to the couple page."], "/eTools Ultimate;component/Assets/Icons/Accessories.png", typeof(CouplePage)),
            new(localizer["Motions"], localizer["Navigate to the motions page."], "/eTools Ultimate;component/Assets/Icons/Motions.png", typeof(MotionPage)),
            new(localizer["Text Client"], localizer["Navigate to the text client."], "/eTools Ultimate;component/Assets/Icons/Texts.png", typeof(TextClientPage)),
            new(localizer["World"], localizer["WorldDescription"], "/eTools Ultimate;component/Assets/Icons/World.png", typeof(WorldPage)),
            new(localizer["Tickets"], localizer["Navigate to the ticket editor."], "/eTools Ultimate;component/Assets/Icons/ticket.png", typeof(TicketPage)),
            new(localizer["Object"], localizer["Navigate to the object editor."], "/eTools Ultimate;component/Assets/Icons/Terrain.png", typeof(ObjectPage)),
            new(localizer["Terrain"], localizer["Navigate to the terrain editor."], "/eTools Ultimate;component/Assets/Icons/Terrain.png", typeof(TerrainObjectPage)),
            new(localizer["Job"], localizer["Navigate to the job editor."], "/eTools Ultimate;component/Assets/Icons/ticket.png", typeof(JobPage)),
            new(localizer["Packitem"], localizer["Navigate to the packitem editor."], "/eTools Ultimate;component/Assets/Icons/ticket.png", typeof(PackitemPage)),
            new(localizer["Lord"], localizer["Navigate to the lord editor."], "/eTools Ultimate;component/Assets/Icons/Lord.png", typeof(LordPage)),
            new(localizer["Drop Event"], localizer["Navigate to the drop event editor."], "/eTools Ultimate;component/Assets/Icons/ticket.png", typeof(DropEventPage)),
            new(localizer["Settings"], localizer["Navigate to the settings page."], "/eTools Ultimate;component/Assets/Icons/Settings.png", typeof(SettingsPage))
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
            try
            {
                var patchNotesDialog = new PatchNotesDialog(contentDialogService.GetDialogHost());
                await patchNotesDialog.ShowAsync();
            }
            catch (Exception ex)
            {
                // Fallback: Öffne den Dialog direkt ohne Dialog-Host
                var patchNotesDialog = new PatchNotesDialog(null);
                await patchNotesDialog.ShowAsync();
            }
        }
    }
}
