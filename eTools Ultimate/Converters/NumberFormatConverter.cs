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
            if (value == null) return null;

            try
            {
                // Formatierung für verschiedene Zahlentypen
                if (value is int intValue)
                {
                    return intValue.ToString("N0", GermanNumberFormat);
                }
                else if (value is long longValue)
                {
                    return longValue.ToString("N0", GermanNumberFormat);
                }
                else if (value is double doubleValue)
                {
                    // Überprüfen ob es sich um eine ganze Zahl handelt
                    if (doubleValue == Math.Truncate(doubleValue))
                    {
                        return doubleValue.ToString("N0", GermanNumberFormat);
                    }
                    return doubleValue.ToString("N2", GermanNumberFormat);
                }
                else if (value is decimal decimalValue)
                {
                    // Überprüfen ob es sich um eine ganze Zahl handelt
                    if (decimalValue == Math.Truncate(decimalValue))
                    {
                        return decimalValue.ToString("N0", GermanNumberFormat);
                    }
                    return decimalValue.ToString("N2", GermanNumberFormat);
                }
                else if (value is uint || value is ulong || value is ushort || value is byte)
                {
                    return System.Convert.ToUInt64(value).ToString("N0", GermanNumberFormat);
                }
                else if (value is float)
                {
                    float floatValue = (float)value;
                    if (floatValue == Math.Truncate(floatValue))
                    {
                        return floatValue.ToString("N0", GermanNumberFormat);
                    }
                    return floatValue.ToString("N2", GermanNumberFormat);
                }
                // Falls keiner der bekannten Typen zutrifft, versuchen wir eine generische Konvertierung
                else if (value.ToString() != null)
                {
                    if (Double.TryParse(value.ToString(), out double result))
                    {
                        if (result == Math.Truncate(result))
                        {
                            return result.ToString("N0", GermanNumberFormat);
                        }
                        return result.ToString("N2", GermanNumberFormat);
                    }
                }
            }
            catch (Exception)
            {
                // Bei Fehler den ursprünglichen Wert zurückgeben
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            if (!(value is string stringValue)) return value;

            try
            {
                // Alle nicht-numerischen Zeichen entfernen, bis auf Komma und Punkt
                string cleanedValue = stringValue.Trim();

                // Wenn der Zieltyp Integer oder Long ist, nur ganze Zahlen zulassen
                if (targetType == typeof(int))
                {
                    if (int.TryParse(cleanedValue, NumberStyles.Any, GermanNumberFormat, out int intResult))
                    {
                        return intResult;
                    }
                }
                else if (targetType == typeof(long))
                {
                    if (long.TryParse(cleanedValue, NumberStyles.Any, GermanNumberFormat, out long longResult))
                    {
                        return longResult;
                    }
                }
                else if (targetType == typeof(double))
                {
                    if (double.TryParse(cleanedValue, NumberStyles.Any, GermanNumberFormat, out double doubleResult))
                    {
                        return doubleResult;
                    }
                }
                else if (targetType == typeof(decimal))
                {
                    if (decimal.TryParse(cleanedValue, NumberStyles.Any, GermanNumberFormat, out decimal decimalResult))
                    {
                        return decimalResult;
                    }
                }
                else if (targetType == typeof(float))
                {
                    if (float.TryParse(cleanedValue, NumberStyles.Any, GermanNumberFormat, out float floatResult))
                    {
                        return floatResult;
                    }
                }
                else if (targetType == typeof(uint))
                {
                    if (uint.TryParse(cleanedValue, NumberStyles.Any, GermanNumberFormat, out uint uintResult))
                    {
                        return uintResult;
                    }
                }
                else if (targetType == typeof(ulong))
                {
                    if (ulong.TryParse(cleanedValue, NumberStyles.Any, GermanNumberFormat, out ulong ulongResult))
                    {
                        return ulongResult;
                    }
                }
                // Standardmäßig versuchen wir zu double zu konvertieren
                else if (double.TryParse(cleanedValue, NumberStyles.Any, GermanNumberFormat, out double result))
                {
                    return result;
                }
            }
            catch (Exception)
            {
                // Bei Fehler den ursprünglichen Wert zurückgeben
            }

            return value;
        }
    }
} 