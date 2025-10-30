using eTools_Ultimate.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using Wpf.Ui.Controls;

namespace eTools_Ultimate.Converters
{
    public class PatchModificationTypeToForegroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not PatchModificationType changeType) throw new Exception($"PatchNoteChangeTypeToIconConverter::Convert exception : value is not PatchChangeType. value: {value}");
            
            return changeType switch
            {
                PatchModificationType.Added => Brushes.LimeGreen,
                PatchModificationType.Removed => Brushes.Red,
                PatchModificationType.Changed => Brushes.Orange,
                PatchModificationType.Fixed => Brushes.Purple,
                PatchModificationType.Improved => Brushes.DodgerBlue,
                PatchModificationType.Updated => Brushes.Gold,
                _ => Brushes.LimeGreen
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
