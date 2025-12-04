using System.Collections.ObjectModel;
using eTools_Ultimate.Views.Pages;
using Wpf.Ui.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System;
using eTools_Ultimate.Helpers;
using eTools_Ultimate.Resources;
using System.Windows;
using System.Resources;
using Microsoft.Extensions.Localization;

namespace eTools_Ultimate.ViewModels.Windows
{
    public partial class MainWindowViewModel(IStringLocalizer localizer) : ObservableObject
    {
        private readonly string _applicationTitle = "eTools Ultimate";

        private readonly object[] _menuItems = [
            new NavigationViewItem()
                {
                    Content = localizer["Dashboard"],
                    Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/eTools.png", 25, 25),
                    TargetPageType = typeof(DashboardPage),
                    //MenuItemsSource = new object[] // TODO: Add back changelog but not like this (contentdialog)
                    //{
                    //    new NavigationViewItem()
                    //    {
                    //        Content = "ChangeLog",
                    //        Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/World.png", 25, 25),
                    //        TargetPageType = typeof(eTools_Ultimate.Views.Pages.ChangeLog.ChangeLogView)
                    //    }
                    //}
                },
                new NavigationViewItemSeparator(),
                new NavigationViewItem()
                {
                    Content = "Items",
                    Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Items.png", 25, 25),
                    TargetPageType = typeof(ItemsPage)
                },
                new NavigationViewItem()
                {
                    Content = localizer["Movers"],
                    Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Movers.png", 25, 25),
                    TargetPageType = typeof(MoversPage)
                },
                //new NavigationViewItem()
                //{
                //    Content = "Skills",
                //    Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Skills.png", 25, 25),
                //    TargetPageType = typeof(SkillPage)
                //},
                new NavigationViewItem()
                {
                    Content = localizer["Motions"],
                    Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Motions.png", 25, 25),
                    TargetPageType = typeof(MotionsPage)
                },
                //new NavigationViewItem()
                //{
                //    Content = "Quests",
                //    Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Quests.png", 25, 25),
                //    TargetPageType = typeof(QuestsPage)
                //},
                //new NavigationViewItem()
                //{
                //    Content = "NPCs",
                //    Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Characters.png", 25, 25),
                //    TargetPageType = typeof(CharactersPage)
                //},
                //new NavigationViewItem()
                //{
                //    Content = "Events",
                //    Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Events.png", 25, 25),
                //    TargetPageType = typeof(EventPage)
                //},
                new NavigationViewItem()
                {
                    Content = localizer["Giftboxes"],
                    Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Giftboxes.png", 25, 25),
                    TargetPageType = typeof(GiftboxesPage)
                },
                //new NavigationViewItem()
                //{
                //    Content = "Collectors",
                //    Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Collector.png", 25, 25),
                //    TargetPageType = typeof(CollectorPage)
                //},
                new NavigationViewItem()
                {
                    Content = localizer["Accessories"],
                    Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Accessories.png", 25, 25),
                    TargetPageType = typeof(AccessoriesPage)
                },
                //new NavigationViewItem()
                //{
                //    Content = "Exchangers",
                //    Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Exchangers.png", 25, 25),
                //    TargetPageType = typeof(ExchangerPage)
                //},
                //new NavigationViewItem()
                //{
                //    Content = "HonorList",
                //    Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Honors.png", 25, 25),
                //    TargetPageType = typeof(HonorsPage)
                //},
                new NavigationViewItem()
                {
                    Content = localizer["Texts"],
                    Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Texts.png", 25, 25),
                    TargetPageType = typeof(TextsPage)
                },
                new NavigationViewItem()
                {
                    Content = localizer["Misc"],
                    Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Settings.png", 25, 25),
                    TargetPageType = typeof(MiscPage)
                },
                //new NavigationViewItem()
                //{
                //    Content = "Couple",
                //    Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Accessories.png", 25, 25),
                //    TargetPageType = typeof(CouplePage),
                //},
                //new NavigationViewItem()
                //{
                //    Content = "Terrain",
                //    Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Terrain.png", 25, 25),
                //    TargetPageType = typeof(TerrainsPage)
                //},
                //new NavigationViewItem()
                //{
                //    Content = "World",
                //    Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/World.png", 25, 25),
                //    TargetPageType = typeof(WorldsPage)
                //},
                //new NavigationViewItem()
                //{
                //    Content = "Tickets",
                //    Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/ticket.png", 25, 25),
                //    TargetPageType = typeof(TicketsPage)
                //},
                //new NavigationViewItem()
                //{
                //    Content = "Object",
                //    Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Terrain.png", 25, 25),
                //    TargetPageType = typeof(ObjectsPage)
                //},
                //new NavigationViewItem()
                //{
                //    Content = "Job",
                //    Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/ticket.png", 25, 25),
                //    TargetPageType = typeof(JobsPage)
                //},
                //new NavigationViewItem()
                //{
                //    Content = "Packitem",
                //    Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/ticket.png", 25, 25),
                //    TargetPageType = typeof(PackitemsPage)
                //},
                //new NavigationViewItem()
                //{
                //    Content = "Lord",
                //    Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Lord.png", 25, 25),
                //    TargetPageType = typeof(LordsPage)
                //},
                //new NavigationViewItem()
                //{
                //    Content = "DropEvent",
                //    Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/ticket.png", 25, 25),
                //    TargetPageType = typeof(DropEventsPage)
                //}
            ];

        private readonly object[] _footerMenuItems = [
            new NavigationViewItem
                {
                    Content = localizer["Settings"],
                    Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Settings.png", 25, 25),
                    TargetPageType = typeof(SettingsPage),
                    MenuItemsSource = new object[]
                    {
                        new NavigationViewItem(localizer["Configuration"], typeof(ConfigurationPage)),
                        new NavigationViewItem(localizer["Personalization"], typeof(PersonalizationPage)),
                        new NavigationViewItem(localizer["About"], typeof(AboutPage))
                    }
                }
            ];

        public string ApplicationTitle => _applicationTitle;
        public object[] MenuItems => _menuItems;
        public object[] FooterMenuItems => _footerMenuItems;
    }
}
