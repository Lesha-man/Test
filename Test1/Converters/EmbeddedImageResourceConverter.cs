using System;
using System.Globalization;
using Xamarin.Forms;

namespace Test1.Converters
{
    public class EmbeddedImageResourceConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? null : ImageSource.FromResource(value as string);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
