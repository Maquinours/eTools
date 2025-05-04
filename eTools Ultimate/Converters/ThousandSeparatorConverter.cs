using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace eTools_Ultimate.Converters
{
    public class ThousandSeparatorConverter : IValueConverter
    {
        // Englisches Kulturformat mit Komma als Tausendertrennzeichen
        private static readonly NumberFormatInfo EnglishNumberFormat = new CultureInfo("en-US").NumberFormat;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int intValue)
            {
                // Formatiert die Ganzzahl mit Tausendertrennzeichen
                return intValue.ToString("N0", EnglishNumberFormat);
            }
            
            return value?.ToString() ?? string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string stringValue)
            {
                // Removes all non-digits for conversion back
                string digitsOnly = new string(stringValue.Where(c => char.IsDigit(c)).ToArray());
                
                if (int.TryParse(digitsOnly, out int result))
                {
                    return result;
                }
            }
            
            return 0;
        }
    }
} 