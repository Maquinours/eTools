using eTools_Ultimate.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace eTools_Ultimate.Converters
{
    public class PatchModificationTypeToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not PatchModificationType changeType) throw new Exception($"PatchNoteChangeTypeToIconConverter::Convert exception : value is not PatchChangeType. value: {value}");

            return changeType switch
            {
                PatchModificationType.Added => "Added",
                PatchModificationType.Removed => "Removed",
                PatchModificationType.Changed => "Changed",
                PatchModificationType.Fixed => "Fixed",
                PatchModificationType.Improved => "Improved",
                PatchModificationType.Updated => "Updated",
                _ => ""
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
