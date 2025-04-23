using System;
using System.Globalization;
using System.Windows.Data;

namespace eTools_Ultimate.Converters
{
    public class NumberFormatConverter : IValueConverter
    {
        private static readonly NumberFormatInfo GermanNumberFormat = new CultureInfo("de-DE").NumberFormat;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double doubleValue)
            {
                return doubleValue;
            }
            else if (value is int intValue)
            {
                return (double)intValue;
            }
            else if (value is string stringValue && double.TryParse(stringValue, out double result))
            {
                return result;
            }
            
            return 0.0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double doubleValue)
            {
                if (targetType == typeof(int))
                    return (int)doubleValue;
                return doubleValue;
            }
            else if (value is string stringValue && double.TryParse(stringValue, out double result))
            {
                if (targetType == typeof(int))
                    return (int)result;
                return result;
            }
            
            return targetType == typeof(int) ? 0 : 0.0;
        }
    }
} 