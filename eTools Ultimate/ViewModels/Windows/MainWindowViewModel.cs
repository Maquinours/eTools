using System.Collections.ObjectModel;
using eTools_Ultimate.Views.Pages;
using Wpf.Ui.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System;
using eTools_Ultimate.Views.Pages.TerrainObject;

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
            
            // Setze die Renderoptionen für hohe Qualität
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
                    Icon = CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/eTools.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.DashboardPage),
                    MenuItemsSource = new object[]
                    {
                        new NavigationViewItem() 
                        {
                            Content = "Change Log",
                            Icon = CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/World.png", 25, 25),
                            TargetPageType = typeof(eTools.Views.Pages.ChangeLog.ChangeLogView)
                        }
                    }
                },
                new NavigationViewItemSeparator(),
                new NavigationViewItem()
                {
                    Content = "Items",
                    Icon = CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Items.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.ItemPage)
                },
                new NavigationViewItem()
                {
                    Content = "Movers",
                    Icon = CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Movers.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.MoverPage)
                },
                new NavigationViewItem()
                {
                    Content = "Skills",
                    Icon = CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Skills.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.SkillPage)
                },
                new NavigationViewItem()
                {
                    Content = "Motions",
                    Icon = CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Motions.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.Motion.MotionPage)
                },
                new NavigationViewItem()
                {
                    Content = "Quests",
                    Icon = CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Quests.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.QuestPage)
                },
                new NavigationViewItem()
                {
                    Content = "NPCs",
                    Icon = CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Characters.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.NpcPage)
                },
                new NavigationViewItem()
                {
                    Content = "Events",
                    Icon = CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Events.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.EventPage)
                },
                new NavigationViewItem()
                {
                    Content = "Giftboxes",
                    Icon = CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Giftboxes.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.GiftboxPage)
                },
                new NavigationViewItem()
                {
                    Content = "Collectors",
                    Icon = CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Collector.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.CollectorPage)
                },
                new NavigationViewItem()
                {
                    Content = "Accessories",
                    Icon = CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Accessories.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.Accessory.AccessoryPage)
                },
                new NavigationViewItem()
                {
                    Content = "Exchangers",
                    Icon = CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Exchangers.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.ExchangerPage)
                },
                new NavigationViewItem()
                {
                    Content = "Honor List",
                    Icon = CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Honors.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.Honor.HonorPage)
                },
                new NavigationViewItem()
                {
                    Content = "Text Client",
                    Icon = CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Texts.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.TextClientPage)
                },
                new NavigationViewItem()
                {
                    Content = "Couple",
                    Icon = CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Accessories.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.CouplePage)
                },
                new NavigationViewItem()
                {
                    Content = "Terrain/Object",
                    Icon = CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Terrain.png", 25, 25),
                    TargetPageType = typeof(Views.Pages.TerrainObject.TerrainObjectPage)
                }
            };

            // Footer-Menüs mit hochwertigen Icons erstellen
            _footerMenuItems = new ObservableCollection<object>
            {
                new NavigationViewItem
                {
                    Content = "Settings",
                    Icon = CreateHighQualityImageIcon("eTools Ultimate;component/Assets/Icons/Settings.png", 25, 25),
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
