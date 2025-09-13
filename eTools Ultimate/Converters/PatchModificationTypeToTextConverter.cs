using eTools_Ultimate.Models;
using Microsoft.Extensions.Localization;
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
        private static IStringLocalizer? _localizer;

        public static void SetLocalizer(IStringLocalizer localizer)
        {
            _localizer = localizer;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not PatchModificationType changeType) throw new Exception($"PatchNoteChangeTypeToIconConverter::Convert exception : value is not PatchChangeType. value: {value}");

            return changeType switch
            {
                PatchModificationType.Added => _localizer?["Added"] ?? "Added",
                PatchModificationType.Removed => _localizer?["Removed"] ?? "Removed",
                PatchModificationType.Changed => _localizer?["Changed"] ?? "Changed",
                PatchModificationType.Fixed => _localizer?["Fixed"] ?? "Fixed",
                PatchModificationType.Improved => _localizer?["Improved"] ?? "Improved",
                PatchModificationType.Updated => _localizer?["Updated"] ?? "Updated",
                _ => ""
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
