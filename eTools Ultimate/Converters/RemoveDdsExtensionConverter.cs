using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace eTools_Ultimate.Converters
{
    public class RemoveDdsExtensionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string fileName)
            {
                // Remove .dds extension if present
                if (fileName.EndsWith(".dds", StringComparison.OrdinalIgnoreCase))
                {
                    return Path.GetFileNameWithoutExtension(fileName);
                }
                return fileName;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
