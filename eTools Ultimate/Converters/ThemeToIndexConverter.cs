using System;
using System.Globalization;
using System.Windows.Data;
using Wpf.Ui.Appearance;

namespace eTools_Ultimate.Converters
{
	public class ThemeToIndexConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is ApplicationTheme theme)
			{
				return theme switch
				{
					ApplicationTheme.Light => 0,
					ApplicationTheme.Dark => 1,
					_ => 0
				};
			}

			return 0;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is int index)
			{
				return index switch
				{
					0 => ApplicationTheme.Light,
					1 => ApplicationTheme.Dark,
					_ => ApplicationTheme.Light
				};
			}

			return ApplicationTheme.Light;
		}
	}
}