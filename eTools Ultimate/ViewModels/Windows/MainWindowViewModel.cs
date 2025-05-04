using System.Collections.ObjectModel;
using eTools_Ultimate.Views.Pages;
using Wpf.Ui.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System;

namespace eTools_Ultimate.ViewModels.Windows
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _applicationTitle = "eTools Ultimate";

        // Helper-Methode zum Erstellen von ImageIcon mit hoher Qualität
        private static ImageIcon CreateHighQualityImageIcon(string relativePath, int width, int height)
        {
            var packUri = "pack://application:,,,/" + relativePath;
            var bmp = new BitmapImage();
            bmp.BeginInit();
            bmp.UriSource = new Uri(packUri, UriKind.Absolute);
            bmp.CacheOption = BitmapCacheOption.OnLoad;
            bmp.EndInit();
            
            var image = new ImageIcon
            {
                Source = bmp,
                Width = width,
                Height = height
            };
            
            // Set rendering options for high quality
            RenderOptions.SetBitmapScalingMode(image, BitmapScalingMode.HighQuality);
            
            return image;
        }

        public MainWindowViewModel()
        {
            // Initialisiere die Menüs mit hochwertigen Icons
            InitializeMenus();
        }

        private void InitializeMenus()
        {
            // Menüeinträge mit hochwertigen Icons erstellen
            _menuItems = new ObservableCollection<object>
            {
                new NavigationViewItem()
                {
                    Content = "Dashboard",
                    Icon = CreateHighQualityImageIcon("eTools Ultimate;component/Views/Windows/eToolsLogoIcon.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.DashboardPage)
                },
                new NavigationViewItemSeparator(),
                new NavigationViewItem()
                {
                    Content = "Items",
                    Icon = CreateHighQualityImageIcon("eTools Ultimate;component/Views/Pages/Home/Icons/Icon_6.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.ItemPage)
                },
                new NavigationViewItem()
                {
                    Content = "Movers",
                    Icon = CreateHighQualityImageIcon("eTools Ultimate;component/Views/Pages/Home/Icons/Icon_2.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.MoverPage)
                },
                new NavigationViewItem()
                {
                    Content = "Skills",
                    Icon = CreateHighQualityImageIcon("eTools Ultimate;component/Views/Pages/Home/Icons/Icon_12.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.SkillPage)
                },
                new NavigationViewItem()
                {
                    Content = "Motions",
                    Icon = CreateHighQualityImageIcon("eTools Ultimate;component/Views/Pages/Home/Icons/Icon_13.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.Motion.MotionPage)
                },
                new NavigationViewItem()
                {
                    Content = "Quests",
                    Icon = CreateHighQualityImageIcon("eTools Ultimate;component/Views/Pages/Home/Icons/Icon_10.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.QuestPage)
                },
                new NavigationViewItem()
                {
                    Content = "NPCs",
                    Icon = CreateHighQualityImageIcon("eTools Ultimate;component/Views/Pages/Home/Icons/Icon_4.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.NpcPage)
                },
                new NavigationViewItem()
                {
                    Content = "Events",
                    Icon = CreateHighQualityImageIcon("eTools Ultimate;component/Views/Pages/Home/Icons/Icon_9.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.EventPage)
                },
                new NavigationViewItem()
                {
                    Content = "Giftboxes",
                    Icon = CreateHighQualityImageIcon("eTools Ultimate;component/Views/Pages/Home/Icons/Icon_5.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.GiftboxPage)
                },
                new NavigationViewItem()
                {
                    Content = "Collectors",
                    Icon = CreateHighQualityImageIcon("eTools Ultimate;component/Views/Pages/Home/Icons/Icon_1.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.CollectorPage)
                },
                new NavigationViewItem()
                {
                    Content = "Accessories",
                    Icon = CreateHighQualityImageIcon("eTools Ultimate;component/Views/Pages/Home/Icons/Icon_8.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.Accessory.AccessoryPage)
                },
                new NavigationViewItem()
                {
                    Content = "Exchangers",
                    Icon = CreateHighQualityImageIcon("eTools Ultimate;component/Views/Pages/Home/Icons/Icon_3.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.ExchangerPage)
                },
                new NavigationViewItem()
                {
                    Content = "Honor List",
                    Icon = CreateHighQualityImageIcon("eTools Ultimate;component/Views/Pages/Home/Icons/Icon_14.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.Honor.HonorPage)
                },
                new NavigationViewItem()
                {
                    Content = "Text Client",
                    Icon = CreateHighQualityImageIcon("eTools Ultimate;component/Views/Pages/Home/Icons/Icon_7.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.TextClientPage)
                },
                new NavigationViewItem()
                {
                    Content = "Couple",
                    Icon = CreateHighQualityImageIcon("eTools Ultimate;component/Views/Pages/Home/Icons/Icon_8.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.CouplePage)
                }
            };

            // Footer-Menüs mit hochwertigen Icons erstellen
            _footerMenuItems = new ObservableCollection<object>
            {
                new NavigationViewItem
                {
                    Content = "Settings",
                    Icon = CreateHighQualityImageIcon("eTools Ultimate;component/Views/Pages/Home/Icons/Icon_11.png", 25, 25),
                    TargetPageType = typeof(SettingsPage),
                    MenuItemsSource = new object[]
                    {
                        new NavigationViewItem("Resource Path", typeof(ResourcePathPage)),
                        new NavigationViewItem("Personalization", typeof(PersonalizationPage)),
                        new NavigationViewItem("About", typeof(AboutPage))
                    }
                }
            };
        }

        [ObservableProperty]
        private ObservableCollection<object> _menuItems = new();

        [ObservableProperty]
        private ObservableCollection<object> _footerMenuItems = new();

        [ObservableProperty]
        private ObservableCollection<MenuItem> _trayMenuItems = new()
        {
            new MenuItem { Header = "Home", Tag = "tray_home" }
        };
    }
}
