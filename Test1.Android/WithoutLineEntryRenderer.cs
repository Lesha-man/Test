using Android.Content;
using Test1.Views.Controls;
using Test1.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(WithoutLineEntry), typeof(WithoutLineEntryRenderer))]
namespace Test1.Droid
{
    class WithoutLineEntryRenderer : EntryRenderer
    {
        public WithoutLineEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetBackground(null);
                Control.SetPadding(5, 0, 0, 0);
            }
        }
    }

}