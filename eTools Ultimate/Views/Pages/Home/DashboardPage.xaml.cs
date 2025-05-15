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
using eTools_Ultimate.Views.Windows;

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
            
            NavigationCards.Add(new NavigationCard("Items", "Navigate to the items page.", "/eTools Ultimate;component/Views/Pages/Home/Icons/Icon_6.png", typeof(ItemPage)));
            NavigationCards.Add(new NavigationCard("Movers", "Navigate to the movers page.", "/eTools Ultimate;component/Views/Pages/Home/Icons/Icon_2.png", typeof(MoverPage)));
            NavigationCards.Add(new NavigationCard("Skills", "Navigate to the skills page.", "/eTools Ultimate;component/Views/Pages/Home/Icons/Icon_12.png", typeof(SkillPage)));
            NavigationCards.Add(new NavigationCard("Quests", "Navigate to the quests page.", "/eTools Ultimate;component/Views/Pages/Home/Icons/Icon_10.png", typeof(QuestPage)));
            NavigationCards.Add(new NavigationCard("NPCs", "Navigate to the NPCs page.", "/eTools Ultimate;component/Views/Pages/Home/Icons/Icon_4.png", typeof(NpcPage)));
            NavigationCards.Add(new NavigationCard("Events", "Navigate to the events page.", "/eTools Ultimate;component/Views/Pages/Home/Icons/Icon_9.png", typeof(EventPage)));
            NavigationCards.Add(new NavigationCard("Giftboxes", "Navigate to the giftboxes page.", "/eTools Ultimate;component/Views/Pages/Home/Icons/Icon_5.png", typeof(GiftboxPage)));
            NavigationCards.Add(new NavigationCard("Collectors", "Navigate to the collectors page.", "/eTools Ultimate;component/Views/Pages/Home/Icons/Icon_1.png", typeof(CollectorPage)));
            NavigationCards.Add(new NavigationCard("Accessories", "Navigate to the accessories page.", "/eTools Ultimate;component/Views/Pages/Home/Icons/Icon_8.png", typeof(eTools_Ultimate.Views.Pages.Accessory.AccessoryPage)));
            NavigationCards.Add(new NavigationCard("Exchangers", "Navigate to the exchanger page.", "/eTools Ultimate;component/Views/Pages/Home/Icons/Icon_3.png", typeof(ExchangerPage)));
            NavigationCards.Add(new NavigationCard("Honor List", "Navigate to the honor list page.", "/eTools Ultimate;component/Views/Pages/Home/Icons/Icon_14.png", typeof(Honor.HonorPage)));
            NavigationCards.Add(new NavigationCard("Couple", "Navigate to the couple page.", "/eTools Ultimate;component/Views/Pages/Home/Icons/Icon_16.png", typeof(CouplePage)));
            NavigationCards.Add(new NavigationCard("Motions", "Navigate to the motions page.", "/eTools Ultimate;component/Views/Pages/Home/Icons/Icon_13.png", typeof(Motion.MotionPage)));
            NavigationCards.Add(new NavigationCard("Text Client", "Navigate to the text client.", "/eTools Ultimate;component/Views/Pages/Home/Icons/Icon_7.png", typeof(TextClientPage)));
            NavigationCards.Add(new NavigationCard("Settings", "Navigate to the settings page.", "/eTools Ultimate;component/Views/Pages/Home/Icons/Icon_11.png", typeof(SettingsPage)));
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
        /// Opens the changelog dialog
        /// </summary>
        private void OpenChangelogDialog(object sender, RoutedEventArgs e)
        {
            try
            {
                // Open the modern changelog
                ChangelogFrame.Content = new ChangelogDialog();
                ChangelogFrame.Visibility = Visibility.Visible;
                System.Diagnostics.Debug.WriteLine("Changelog dialog was opened. Frame name: " + ChangelogFrame.Name);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error opening the changelog dialog: " + ex.Message);
                System.Windows.MessageBox.Show("Error opening the changelog dialog: " + ex.Message, "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }
        
        /// <summary>
        /// Opens the Discord link in the default browser
        /// </summary>
        private void OpenDiscordLink(object sender, RoutedEventArgs e)
        {
            try
            {
                // Discord invite link
                string discordUrl = "https://discord.gg/aGZYxkjWxh";
                
                // Open URL in default browser
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = discordUrl,
                    UseShellExecute = true
                });
                
                System.Diagnostics.Debug.WriteLine("Discord link opened: " + discordUrl);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error opening Discord link: " + ex.Message);
                System.Windows.MessageBox.Show("Error opening Discord link: " + ex.Message, "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }
        
        /// <summary>
        /// Opens the GitHub link in the default browser
        /// </summary>
        private void OpenGithubLink(object sender, RoutedEventArgs e)
        {
            try
            {
                // GitHub repository link
                string githubUrl = "https://github.com/Maquinours/eTools";
                
                // Open URL in default browser
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = githubUrl,
                    UseShellExecute = true
                });
                
                System.Diagnostics.Debug.WriteLine("GitHub link opened: " + githubUrl);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error opening GitHub link: " + ex.Message);
                System.Windows.MessageBox.Show("Error opening GitHub link: " + ex.Message, "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }
    }
}
