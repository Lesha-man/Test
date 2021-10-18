using Android.Content;
using Test1.Views.Controls;
using Test1.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportRenderer(typeof(WithoutLineEntry), typeof(WithoutLineEntryRenderer))]
namespace Test1.Droid
{
    class UpdatableCollectionViewRenderer : CollectionViewRenderer
    {
        public UpdatableCollectionViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<ItemsView> elementChangedEvent)
        {
            base.OnElementChanged(elementChangedEvent);
        }
    }

}