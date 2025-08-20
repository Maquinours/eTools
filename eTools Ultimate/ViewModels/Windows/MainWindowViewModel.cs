using System.Collections.ObjectModel;
using eTools_Ultimate.Views.Pages;
using Wpf.Ui.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System;
using eTools_Ultimate.Helpers;
using eTools_Ultimate.Views.Pages.TerrainObject;

namespace eTools_Ultimate.ViewModels.Windows
{
    public partial class MainWindowViewModel : ObservableObject
    {
        private readonly string _applicationTitle = "eTools Ultimate";

        private readonly object[] _menuItems = [
            new NavigationViewItem()
                {
                    Content = "Dashboard",
                    Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/eTools.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.DashboardPage),
                    MenuItemsSource = new object[]
                    {
                        new NavigationViewItem()
                        {
                            Content = "Change Log",
                            Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/World.png", 25, 25),
                            TargetPageType = typeof(eTools.Views.Pages.ChangeLog.ChangeLogView)
                        }
                    }
                },
                new NavigationViewItemSeparator(),
                new NavigationViewItem()
                {
                    Content = "Items",
                    Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Items.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.ItemPage)
                },
                new NavigationViewItem()
                {
                    Content = "Movers",
                    Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Movers.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.MoverPage)
                },
                new NavigationViewItem()
                {
                    Content = "Skills",
                    Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Skills.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.SkillPage)
                },
                new NavigationViewItem()
                {
                    Content = "Motions",
                    Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Motions.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.Motion.MotionPage)
                },
                new NavigationViewItem()
                {
                    Content = "Quests",
                    Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Quests.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.QuestPage)
                },
                new NavigationViewItem()
                {
                    Content = "NPCs",
                    Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Characters.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.NpcPage)
                },
                new NavigationViewItem()
                {
                    Content = "Events",
                    Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Events.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.EventPage)
                },
                new NavigationViewItem()
                {
                    Content = "Giftboxes",
                    Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Giftboxes.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.GiftboxPage)
                },
                new NavigationViewItem()
                {
                    Content = "Collectors",
                    Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Collector.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.CollectorPage)
                },
                new NavigationViewItem()
                {
                    Content = "Accessories",
                    Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Accessories.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.Accessory.AccessoryPage)
                },
                new NavigationViewItem()
                {
                    Content = "Exchangers",
                    Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Exchangers.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.ExchangerPage)
                },
                new NavigationViewItem()
                {
                    Content = "Honor List",
                    Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Honors.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.Honor.HonorPage)
                },
                new NavigationViewItem()
                {
                    Content = "Text Client",
                    Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Texts.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.TextClientPage)
                },
                new NavigationViewItem()
                {
                    Content = "Couple",
                    Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Accessories.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.CouplePage),
                },
                new NavigationViewItem()
                {
                    Content = "Terrain/Object",
                    Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Terrain.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.TerrainObject.TerrainObjectPage)
                },
                new NavigationViewItem()
                {
                    Content = "World",
                    Icon = CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/World.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.World.WorldPage)
                },
                new NavigationViewItem()
                {
                    Content = "Tickets",
                    Icon = CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/ticket.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.Ticket.TicketPage)
                },
                new NavigationViewItem()
                {
                    Content = "Object",
                    Icon = CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Terrain.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.Object.ObjectPage)
                },
                new NavigationViewItem()
                {
                    Content = "Job",
                    Icon = CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/ticket.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.Job.JobPage)
                },
                new NavigationViewItem()
                {
                    Content = "Packitem",
                    Icon = CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/ticket.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.Packitem.PackitemPage)
                },
                new NavigationViewItem()
                {
                    Content = "Lord",
                    Icon = CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Lord.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.Lord.LordPage)
                },
                new NavigationViewItem()
                {
                    Content = "Drop Event",
                    Icon = CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/ticket.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.DropEvent.DropEventPage)
                }
            ];

        private readonly object[] _footerMenuItems = [
            new NavigationViewItem
                {
                    Content = "Settings",
                    Icon = ImagesHelper.CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Settings.png", 25, 25),
                    TargetPageType = typeof(SettingsPage),
                    MenuItemsSource = new object[]
                    {
                        new NavigationViewItem("Resource Path", typeof(ResourcePathPage)),
                        new NavigationViewItem("Personalization", typeof(PersonalizationPage)),
                        new NavigationViewItem("About", typeof(AboutPage))
                    }
                }
            ];

        public string ApplicationTitle => _applicationTitle;
        public object[] MenuItems => _menuItems;
        public object[] FooterMenuItems => _footerMenuItems;
    }
}
