using eTools_Ultimate.ViewModels.Pages;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Wpf.Ui.Abstractions.Controls;
using System.Windows;
using System;
using Wpf.Ui.Controls;
using System.Linq;
using Wpf.Ui;
using System.Windows.Controls;
using System.Windows.Media;

namespace eTools_Ultimate.Views.Pages
{
    public partial class DashboardPage : INavigableView<DashboardViewModel>
    {
        private readonly INavigationService _navigationService;
        public DashboardViewModel ViewModel { get; }
        
        public ObservableCollection<NavigationCard> NavigationCards { get; } = new ObservableCollection<NavigationCard>();

        public DashboardPage(DashboardViewModel viewModel, INavigationService navigationService)
        {
            ViewModel = viewModel;
            _navigationService = navigationService;
            DataContext = this;

            InitializeComponent();
            
            // Initialize navigation cards
            InitializeNavigationCards();
        }
        
        private void InitializeNavigationCards()
        {
            // Add cards with the correct page types and icons
            
            NavigationCards.Add(new NavigationCard("Items", "Navigate to the items page.", "Box24", typeof(ItemPage)));
            NavigationCards.Add(new NavigationCard("Movers", "Navigate to the movers page.", "Vehicle24", typeof(MoverPage)));
            NavigationCards.Add(new NavigationCard("Skills", "Navigate to the skills page.", "Star24", typeof(SkillPage)));
            NavigationCards.Add(new NavigationCard("Quests", "Navigate to the quests page.", "Map24", typeof(QuestPage)));
            NavigationCards.Add(new NavigationCard("NPCs", "Navigate to the NPCs page.", "Person24", typeof(NpcPage)));
            NavigationCards.Add(new NavigationCard("Events", "Navigate to the events page.", "Calendar24", typeof(EventPage)));
            NavigationCards.Add(new NavigationCard("Giftboxes", "Navigate to the giftboxes page.", "Gift24", typeof(GiftboxPage)));
            NavigationCards.Add(new NavigationCard("Collectors", "Navigate to the collectors page.", "CollectionFill24", typeof(CollectorPage)));
            NavigationCards.Add(new NavigationCard("Accessories", "Navigate to the accessories page.", "Trophy24", typeof(AccessoryPage)));
            NavigationCards.Add(new NavigationCard("Exchangers", "Navigate to the exchangers page.", "ArrowSwap24", typeof(ExchangerPage)));
            NavigationCards.Add(new NavigationCard("TextClient", "Navigate to the text client.", "TextT24", typeof(TextClientPage)));
            NavigationCards.Add(new NavigationCard("Settings", "Navigate to the settings page.", "Settings24", typeof(SettingsPage)));
        }
        
        private void Card_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Navigate to the selected page
            if (sender is Card card && card.Tag is NavigationCard navigationCard)
            {
                try
                {
                    // Navigate using the type, as per WPF UI approach
                    if (navigationCard.TargetPageType != null)
                    {
                        _navigationService.Navigate(navigationCard.TargetPageType);
                    }
                }
                catch (Exception ex)
                {
                    // Fallback for error case - show dialog with error information
                    System.Windows.MessageBox.Show(
                        $"Navigation error: {ex.Message}", 
                        "Navigation Error", 
                        System.Windows.MessageBoxButton.OK, 
                        System.Windows.MessageBoxImage.Error);
                }
            }
        }
        
        /// <summary>
        /// Event handler for the Patchlogs button
        /// </summary>
        private void PatchlogsButton_Click(object sender, RoutedEventArgs e)
        {
            // Patchlogs content
            string patchlogsContent = 
                "Version 1.2.0 (Current)\n" +
                "• New dashboard design with improved navigation cards\n" +
                "• Added hover effects and arrows for better UX\n" +
                "• Adjusted banner and made it responsive\n" +
                "• Enabled scrolling in dashboard\n" +
                "• Added patchlogs feature\n\n" +
                "Version 1.1.0\n" +
                "• Implemented theme switching\n" +
                "• Performance improvements\n" +
                "• Fixed navigation bugs\n" +
                "• Added new icons\n\n" +
                "Version 1.0.0\n" +
                "• Initial application release\n" +
                "• Implemented core functionality\n" +
                "• Created user interface";
            
            // Show message box with patchlogs
            System.Windows.MessageBox.Show(
                patchlogsContent,
                "Patchlogs - Latest Changes",
                System.Windows.MessageBoxButton.OK,
                System.Windows.MessageBoxImage.Information);
        }
    }
}
