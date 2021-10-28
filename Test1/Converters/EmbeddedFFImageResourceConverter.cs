using FFImageLoading.Forms;
using System;
using System.Globalization;
using System.Reflection;
using Xamarin.Forms;

namespace Test1.Converters
{
    public class EmbeddedFFImageResourceConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? null : new EmbeddedResourceImageSource(value as string, typeof(EmbeddedFFImageResourceConverter).GetTypeInfo().Assembly);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
