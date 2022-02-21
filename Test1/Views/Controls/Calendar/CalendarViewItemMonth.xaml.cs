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
    public partial class CalendarViewItemMonth : ContentView
    {

        public event EventHandler SelectedDateChanged;


        public static readonly BindableProperty SelectedDateProperty = BindableProperty.Create(
          nameof(SelectedDate),
          typeof(DateTime),
          typeof(CalendarViewItemMonth),
          defaultBindingMode: BindingMode.TwoWay,
          propertyChanged: OnEventSelectedDateChanged);

        public DateTime SelectedDate
        {
            get => (DateTime)GetValue(SelectedDateProperty);
            set => SetValue(SelectedDateProperty, value);
        }

        private static void OnEventSelectedDateChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as CalendarViewItemMonth).SelectedDateChanged?.Invoke(((DateTime)newValue).Date, null);
        }


        public static readonly BindableProperty MonthProperty = BindableProperty.Create(
          nameof(Month),
          typeof(DateTime),
          typeof(CalendarViewItemMonth),
          propertyChanged: OnEventMonthChanged);

        public DateTime Month
        {
            get => (DateTime)GetValue(MonthProperty);
            set => SetValue(MonthProperty, value);
        }

        public CalendarViewItemMonth()
        {

            InitializeComponent();
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    var item = new CalendarViewItemDay()
                    {
                        BackgroundColor = Color.Transparent,
                    };
                    item.SetBinding(HeightRequestProperty, new Binding("Width", source:item));
                    var tapGestureRecogniser = new TapGestureRecognizer();
                    tapGestureRecogniser.Tapped += TapGestureRecognizer_Tapped;
                    item.GestureRecognizers.Add(tapGestureRecogniser);
                    grid.Children.Add(item, j, i);
                }
            }
        }

        static void OnEventMonthChanged(BindableObject bindableObject, object oldValue, object newValue)
        {
            if (bindableObject is CalendarViewItemMonth view)
            {
                DateTime date = (DateTime)newValue;
                if (date == DateTime.MinValue)
                    return;
                var monthStart = new DateTime(date.Year, date.Month, 1);
                DateTime weekStart = monthStart.AddDays(-(int)monthStart.AddDays(-1).DayOfWeek);
                //var dt = ((CalendarViewItemDay)view.grid.Children[15]).Date;
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        if (view.grid.Children[i * 7 + j] is CalendarViewItemDay day)
                        {
                            day.Date = weekStart.AddDays(i * 7 + j);
                            if (day.Date.Month != date.Month)
                            {
                                day.TextColor = Color.LightGray;
                            }
                            else
                            {
                                day.TextColor = Color.Black;
                            }

                            day.Triggers.Clear();
                            Setter setter = new Setter();
                            setter.Property = CalendarViewItemDay.BorderColorProperty;
                            setter.Value = Color.Black;
                            DataTrigger trigger = new DataTrigger(typeof(CalendarViewItemDay)) { Value = day.Date, Binding = new Binding("SelectedDate", source: view) };
                            trigger.Setters.Add(setter);
                            day.Triggers.Add(trigger);
                            setter = new Setter();
                            setter.Property = CalendarViewItemDay.BackgroundColorProperty;
                            setter.Value = Color.LightGray;
                            trigger = new DataTrigger(typeof(CalendarViewItemDay)) { Value = day.Date, Binding = new Binding("Date", source: DateTime.Now) };
                            trigger.Setters.Add(setter);
                            day.Triggers.Add(trigger);
                        }
                    }
                }
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            SelectedDate = ((CalendarViewItemDay)sender).Date;
        }
    }
}