using System;
using System.Globalization;
using System.Windows.Data;

namespace RGBcolorEx
{
    class RgbToHtmlColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var rgbCode = value as RgbCode;

            if (rgbCode != null)
            {
                return $"#{rgbCode.R:x2}{rgbCode.G:x2}{rgbCode.B:x2}";
            }

            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
