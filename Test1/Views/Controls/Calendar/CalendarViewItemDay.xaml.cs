using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test1.Views.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarViewItemDay : ContentView
    {
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(
         nameof(CornerRadius),
         typeof(int),
         typeof(CalendarViewItemDay));

        public int CornerRadius
        {
            get => (int)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(
        nameof(BorderColor),
        typeof(Color),
        typeof(CalendarViewItemDay));

        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }

        public static readonly BindableProperty DateProperty = BindableProperty.Create(
         nameof(Date),
         typeof(DateTime),
         typeof(CalendarViewItemDay));

        public DateTime Date
        {
            get => (DateTime)GetValue(DateProperty);
            set => SetValue(DateProperty, value);
        }
        public CalendarViewItemDay()
        {
            InitializeComponent();
        }
    }
}