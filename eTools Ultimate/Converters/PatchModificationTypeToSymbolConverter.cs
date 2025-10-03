using eTools_Ultimate.Models;
using eTools_Ultimate.Services;
using eTools_Ultimate.Views.Windows;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using Wpf.Ui.Controls;

namespace eTools_Ultimate.Converters
{
    public class PatchModificationTypeToSymbolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not PatchModificationType changeType) throw new Exception($"PatchNoteChangeTypeToIconConverter::Convert exception : value is not PatchChangeType. value: {value}");
            
            return changeType switch
            {
                PatchModificationType.Added => SymbolRegular.Add24,
                PatchModificationType.Removed => SymbolRegular.Delete24,
                PatchModificationType.Changed => SymbolRegular.Wrench24,
                PatchModificationType.Fixed => SymbolRegular.Bug24,
                PatchModificationType.Improved => SymbolRegular.ArrowCircleUp24,
                PatchModificationType.Updated => SymbolRegular.ArrowSync24,
                _ => SymbolRegular.CheckmarkCircle24
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
