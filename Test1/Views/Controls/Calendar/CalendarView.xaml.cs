using System;
using System.Collections.ObjectModel;
using System.Linq;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;
using System.Diagnostics;
using Test1.Views.Controls;

namespace Test1.Views.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarView : ContentView
    {

        public event EventHandler SelectedDateChanged;


        public static readonly BindableProperty SelectedDateProperty = BindableProperty.Create(
          nameof(SelectedDate),
          typeof(DateTime),
          typeof(CalendarView),
          defaultBindingMode: BindingMode.TwoWay,
          propertyChanged: OnEventSelectedDatehChanged);

        public DateTime SelectedDate
        {
            get => (DateTime)GetValue(SelectedDateProperty);
            set => SetValue(SelectedDateProperty, value);
        }

        private static void OnEventSelectedDatehChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is CalendarView view)
            {
                view.SelectedDateChanged?.Invoke(((DateTime)newValue).Date, null);
                view.SelectedReminders.Clear();
                view.Reminders.Where((r) => r.Beginning.Date == view.SelectedDate.Date).ToList().ForEach(view.SelectedReminders.Add); ;

            }
        }

        public ObservableCollection<Reminder> Reminders { get; set; }

        public ObservableCollection<Reminder> SelectedReminders { get; set; }

        public ObservableCollection<Month> Months { get; set; }

        public CalendarView()
        {
            SelectedReminders = new ObservableCollection<Reminder>();
            Reminders = new ObservableCollection<Reminder>()
            {
                new Reminder("T1", "fgsgsfdgsdgf", DateTime.Now, DateTime.Now.AddMinutes(10)),
                new Reminder("gfhddfghdf", "fgsgsfdgsdgf", DateTime.Now, DateTime.Now.AddMinutes(10)),
                new Reminder("T2", "fgsgsfdgsdgf", DateTime.Now, DateTime.Now.AddMinutes(10)),
                new Reminder("T3", "fgsgsfdgsdgf", DateTime.Now.AddDays(3), DateTime.Now.AddDays(3).AddMinutes(10)),
                new Reminder("T3", "fgsgsfdgsdgf", DateTime.Now.AddDays(3), DateTime.Now.AddDays(3).AddMinutes(10)),
                new Reminder("T3", "fgsgsfdgsdgf", DateTime.Now.AddDays(3), DateTime.Now.AddDays(3).AddMinutes(10)),
                new Reminder("T3", "fgsgsfdgsdgf", DateTime.Now.AddDays(3), DateTime.Now.AddDays(3).AddMinutes(10)),
                new Reminder("T3", "fgsgsfdgsdgf", DateTime.Now.AddDays(3), DateTime.Now.AddDays(3).AddMinutes(10)),
            };
            Months = new ObservableCollection<Month>()
            {
                new Month(DateTime.Now.AddMonths(-1)),
                new Month(DateTime.Now),
                new Month(DateTime.Now.AddMonths(1)),
            };
            InitializeComponent();
            carousel.CurrentItem = Months[1];
        }

        private async void ButtonRight_Clicked(object sender, EventArgs e)
        {
            await Task.Run(() => carousel.Position == 2 ? carousel.Position = 0 : ++carousel.Position);
        }

        private async void ButtonLeft_Clicked(object sender, EventArgs e)
        {
            await Task.Run(() => carousel.Position == 0 ? carousel.Position = 2 : --carousel.Position);
        }

        public void ChangeMonthToNext(int currentIndex)
        {
            Months[currentIndex == 2 ? 0 : currentIndex + 1].Date = Months[currentIndex].Date.AddMonths(1);
            SelectedReminders.Clear();
        }

        public void ChangeMonthToPrevious(int currentIndex)
        {
            Months[currentIndex == 0 ? 2 : currentIndex - 1].Date = Months[currentIndex].Date.AddMonths(-1);
            SelectedReminders.Clear();
        }

        private async void carousel_PositionChanged(object sender, PositionChangedEventArgs e)
        {
            if (e.CurrentPosition - e.PreviousPosition == 1 || e.CurrentPosition - e.PreviousPosition == -2)
            {
                await Task.Run(() => ChangeMonthToNext(e.CurrentPosition));
            }
            else if (e.CurrentPosition - e.PreviousPosition == -1 || e.CurrentPosition - e.PreviousPosition == 2)
            {
                await Task.Run(() => ChangeMonthToPrevious(e.CurrentPosition));
            }
        }
    }

    public class Month
    {
        public DateTime Date { get; set; }

        public Month(DateTime date)
        {
            Date = date;
        }
    }

    public class Reminder
    {
        public Reminder(string name, string discription, DateTime beginning, DateTime end)
        {
            Name = name;
            Discription = discription;
            Beginning = beginning;
            End = end;
        }
        public string Name { get; set; }
        public string Discription { get; set; }
        public DateTime Beginning { get; set; }
        public DateTime End { get; set; }
    }
}