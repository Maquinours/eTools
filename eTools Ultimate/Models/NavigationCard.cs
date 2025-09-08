using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.Models
{
    public class NavigationCard(string title, string description, string icon = "Fluent24", Type? targetPageType = null, string? tag = null)
    {
        public string Title { get; set; } = title;
        public string Description { get; set; } = description;
        public string Icon { get; set; } = icon;
        public Type? TargetPageType { get; set; } = targetPageType;
        public string? Tag { get; set; } = tag;
    }
}