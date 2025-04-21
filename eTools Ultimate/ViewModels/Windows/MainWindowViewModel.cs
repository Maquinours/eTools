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
                Content = "Home",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Home24 },
                TargetPageType = typeof(Views.Pages.DashboardPage)
            },
            new NavigationViewItemSeparator(),
            new NavigationViewItem()
            {
                Content = "Item",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Cube20 },
                TargetPageType = typeof(Views.Pages.ItemPage)
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
