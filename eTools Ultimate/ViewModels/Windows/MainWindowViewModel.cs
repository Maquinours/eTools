using System.Collections.ObjectModel;
using eTools_Ultimate.Views.Pages;
using Wpf.Ui.Controls;

namespace eTools_Ultimate.ViewModels.Windows
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _applicationTitle = "eTools Ultimate";

        [ObservableProperty]
        private ObservableCollection<object> _menuItems = new()
        {
            new NavigationViewItem()
            {
                Content = "Dashboard",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Home24 },
                TargetPageType = typeof(Views.Pages.DashboardPage)
            },
            new NavigationViewItemSeparator(),
            new NavigationViewItem()
            {
                Content = "Items",
                Icon = new SymbolIcon { Symbol = SymbolRegular.ShoppingBag24 },
                TargetPageType = typeof(Views.Pages.ItemPage)
            },
            new NavigationViewItem()
            {
                Content = "Movers",
                Icon = new SymbolIcon { Symbol = SymbolRegular.PersonArrowRight24 },
                TargetPageType = typeof(Views.Pages.MoverPage)
            },
            new NavigationViewItem()
            {
                Content = "Skills",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Sparkle24 },
                TargetPageType = typeof(Views.Pages.SkillPage)
            },
            new NavigationViewItem()
            {
                Content = "Quests",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Board24 },
                TargetPageType = typeof(Views.Pages.QuestPage)
            },
            new NavigationViewItem()
            {
                Content = "NPCs",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Person24 },
                TargetPageType = typeof(Views.Pages.NpcPage)
            },
            new NavigationViewItem()
            {
                Content = "Events",
                Icon = new SymbolIcon { Symbol = SymbolRegular.CalendarStar24 },
                TargetPageType = typeof(Views.Pages.EventPage)
            },
            new NavigationViewItem()
            {
                Content = "Giftboxes",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Gift24 },
                TargetPageType = typeof(Views.Pages.GiftboxPage)
            },
            new NavigationViewItem()
            {
                Content = "Collectors",
                Icon = new SymbolIcon { Symbol = SymbolRegular.PersonBoard24 },
                TargetPageType = typeof(Views.Pages.CollectorPage)
            },
            new NavigationViewItem()
            {
                Content = "Accessories",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Diamond24 },
                TargetPageType = typeof(Views.Pages.AccessoryPage)
            },
            new NavigationViewItem()
            {
                Content = "Exchangers",
                Icon = new SymbolIcon { Symbol = SymbolRegular.ArrowSync24 },
                TargetPageType = typeof(Views.Pages.ExchangerPage)
            },
            new NavigationViewItem()
            {
                Content = "TextClient",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Chat24 },
                TargetPageType = typeof(Views.Pages.TextClientPage)
            }
        };

        [ObservableProperty]
        private ObservableCollection<object> _footerMenuItems = new()
        {
            new NavigationViewItem
            {
                Content = "Settings",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Settings20 },
                TargetPageType = typeof(SettingsPage),
                MenuItemsSource = new object[]
                {
                    new NavigationViewItem("Resource Path", typeof(ResourcePathPage)),
                    new NavigationViewItem("Personalization", typeof(PersonalizationPage)),
                    new NavigationViewItem("About", typeof(AboutPage))
                }
            }
        };

        [ObservableProperty]
        private ObservableCollection<MenuItem> _trayMenuItems = new()
        {
            new MenuItem { Header = "Home", Tag = "tray_home" }
        };
    }
}
