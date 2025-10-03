using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Media;
using eTools_Ultimate.Models;

namespace eTools_Ultimate.Converters
{
    public class MaxTextWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is NavigationCard[] cards)
            {
                // Calculate the maximum width needed for all cards based on current language
                double maxWidth = 150; // Minimum width
                
                foreach (var card in cards)
                {
                    // Calculate width needed for title (18px, SemiBold)
                    double titleWidth = MeasureTextWidth(card.Title, 18, "Segoe UI SemiBold");
                    
                    // Calculate width needed for description (14px, Regular)
                    double descriptionWidth = MeasureTextWidth(card.Description, 14, "Segoe UI");
                    
                    // Take the maximum of title and description, add padding
                    double cardWidth = Math.Max(titleWidth, descriptionWidth) + 40; // 40px padding (20px margin on each side)
                    
                    // Update maximum width
                    maxWidth = Math.Max(maxWidth, cardWidth);
                }
                
                // Ensure minimum width and add some buffer for safety
                return Math.Max(maxWidth, 150);
            }
            
            return 150; // Default minimum width
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private double MeasureTextWidth(string text, double fontSize, string fontFamily)
        {
            if (string.IsNullOrEmpty(text))
                return 0;

            try
            {
                var formattedText = new FormattedText(
                    text,
                    CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    new Typeface(fontFamily),
                    fontSize,
                    Brushes.Black,
                    96.0); // Use standard DPI

                return formattedText.Width;
            }
            catch
            {
                // Fallback: estimate width based on character count
                return text.Length * fontSize * 0.6;
            }
        }
    }
}
