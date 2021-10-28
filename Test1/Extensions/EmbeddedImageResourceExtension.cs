using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test1.Extentions
{
    [ContentProperty(nameof(Source))]

    public class EmbeddedImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return Source == null ? null : ImageSource.FromResource("Test1.Resources.Images." + Source);
        }
    }
}