using eTools_Ultimate.Models;
using eTools_Ultimate.Views.Dialogs;
using System.Resources;
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
        private static readonly ResourceManager ResourceManager = new ResourceManager("eTools_Ultimate.Resources.Translations", typeof(DashboardViewModel).Assembly);

        public NavigationCard[] NavigationCards { get; } =
        [
            new(GetLocalizedString("Items"), GetLocalizedString("ItemsDescription"), "/eTools Ultimate;component/Assets/Icons/Items.png", typeof(ItemPage)),
            new(GetLocalizedString("Movers"), GetLocalizedString("MoversDescription"), "/eTools Ultimate;component/Assets/Icons/Movers.png", typeof(MoverPage)),
            new(GetLocalizedString("Skills"), GetLocalizedString("SkillsDescription"), "/eTools Ultimate;component/Assets/Icons/Skills.png", typeof(SkillPage)),
            new(GetLocalizedString("Quests"), GetLocalizedString("QuestsDescription"), "/eTools Ultimate;component/Assets/Icons/Quests.png", typeof(QuestPage)),
            new(GetLocalizedString("NPCs"), GetLocalizedString("NPCsDescription"), "/eTools Ultimate;component/Assets/Icons/Characters.png", typeof(NpcPage)),
            new(GetLocalizedString("Events"), GetLocalizedString("EventsDescription"), "/eTools Ultimate;component/Assets/Icons/Events.png", typeof(EventPage)),
            new(GetLocalizedString("Giftboxes"), GetLocalizedString("GiftboxesDescription"), "/eTools Ultimate;component/Assets/Icons/Giftboxes.png", typeof(GiftboxPage)),
            new(GetLocalizedString("Collectors"), GetLocalizedString("CollectorsDescription"), "/eTools Ultimate;component/Assets/Icons/Collector.png", typeof(CollectorPage)),
            new(GetLocalizedString("Accessories"), GetLocalizedString("AccessoriesDescription"), "/eTools Ultimate;component/Assets/Icons/Accessories.png", typeof(eTools_Ultimate.Views.Pages.Accessory.AccessoryPage)),
            new(GetLocalizedString("Exchangers"), GetLocalizedString("ExchangersDescription"), "/eTools Ultimate;component/Assets/Icons/Exchangers.png", typeof(ExchangerPage)),
            new(GetLocalizedString("HonorList"), GetLocalizedString("HonorListDescription"), "/eTools Ultimate;component/Assets/Icons/Honors.png", typeof(HonorPage)),
            new(GetLocalizedString("Couple"), GetLocalizedString("CoupleDescription"), "/eTools Ultimate;component/Assets/Icons/Accessories.png", typeof(CouplePage)),
            new(GetLocalizedString("Motions"), GetLocalizedString("MotionsDescription"), "/eTools Ultimate;component/Assets/Icons/Motions.png", typeof(MotionPage)),
            new(GetLocalizedString("TextClient"), GetLocalizedString("TextClientDescription"), "/eTools Ultimate;component/Assets/Icons/Texts.png", typeof(TextClientPage)),
            new(GetLocalizedString("World"), GetLocalizedString("WorldDescription"), "/eTools Ultimate;component/Assets/Icons/World.png", typeof(WorldPage)),
            new(GetLocalizedString("Tickets"), GetLocalizedString("TicketsDescription"), "/eTools Ultimate;component/Assets/Icons/ticket.png", typeof(TicketPage)),
            new(GetLocalizedString("Object"), GetLocalizedString("ObjectDescription"), "/eTools Ultimate;component/Assets/Icons/Terrain.png", typeof(ObjectPage)),
            new(GetLocalizedString("Terrain"), GetLocalizedString("TerrainDescription"), "/eTools Ultimate;component/Assets/Icons/Terrain.png", typeof(TerrainObjectPage)),
            new(GetLocalizedString("Job"), GetLocalizedString("JobDescription"), "/eTools Ultimate;component/Assets/Icons/ticket.png", typeof(JobPage)),
            new(GetLocalizedString("Packitem"), GetLocalizedString("PackitemDescription"), "/eTools Ultimate;component/Assets/Icons/ticket.png", typeof(PackitemPage)),
            new(GetLocalizedString("Lord"), GetLocalizedString("LordDescription"), "/eTools Ultimate;component/Assets/Icons/Lord.png", typeof(LordPage)),
            new(GetLocalizedString("DropEvent"), GetLocalizedString("DropEventDescription"), "/eTools Ultimate;component/Assets/Icons/ticket.png", typeof(DropEventPage)),
            new(GetLocalizedString("Settings"), GetLocalizedString("SettingsDescription"), "/eTools Ultimate;component/Assets/Icons/Settings.png", typeof(SettingsPage))
        ];

        private static string GetLocalizedString(string key)
        {
            try
            {
                return ResourceManager.GetString(key) ?? key;
            }
            catch
            {
                return key;
            }
        }

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
