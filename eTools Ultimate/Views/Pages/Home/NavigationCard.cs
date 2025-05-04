using System;
using System.Windows.Media.Imaging;

namespace eTools_Ultimate.Views.Pages
{
    public class NavigationCard
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Tag { get; set; }
        public Type TargetPageType { get; set; }

        public NavigationCard()
        {
            // Default constructor for XAML
        }

        public NavigationCard(string title, string description, string icon = "Fluent24", Type targetPageType = null, string tag = null)
        {
            Title = title;
            Description = description;
            Icon = icon;
            TargetPageType = targetPageType;
            Tag = tag;
        }
    }
} 