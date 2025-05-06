using System;
using System.Globalization;
using System.Windows.Data;
using Wpf.Ui.Controls;

namespace eTools_Ultimate.Converters
{
    public class ChangeTypeToAppearanceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string changeType)
            {
                return changeType.ToLower() switch
                {
                    "add" => ControlAppearance.Success,
                    "modify" => ControlAppearance.Caution,
                    "delete" => ControlAppearance.Danger,
                    "info" => ControlAppearance.Info,
                    _ => ControlAppearance.Secondary
                };
            }
            
            return ControlAppearance.Secondary;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
} 