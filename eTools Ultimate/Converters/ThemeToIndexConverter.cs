using System;
using System.Globalization;
using System.Windows.Data;
using Wpf.Ui.Appearance;

namespace eTools_Ultimate.Converters
{
    public class ThemeToIndexConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value switch
            {
                ApplicationTheme.Light => 0,
                ApplicationTheme.Dark => 1,
                ApplicationTheme.HighContrast => 2,
                _ => 0
            };
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value switch
            {
                0 => ApplicationTheme.Light,
                1 => ApplicationTheme.Dark,
                2 => ApplicationTheme.HighContrast,
                _ => ApplicationTheme.Light
            };
        }
    }
}