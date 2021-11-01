using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.ComponentModel;
using System.Globalization;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;

namespace Test1.Views.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarView : ContentView
    {
        public ObservableCollection<Reminder> Reminders { get; set; }
        public ObservableCollection<Month> Months { get; set; }
        public CalendarView()
        {
            Reminders = new ObservableCollection<Reminder>()
            {
                new Reminder("T1", "fgsgsfdgsdgf", DateTime.Now, DateTime.Now.AddMinutes(10)),
                new Reminder("gfhddfghdf", "fgsgsfdgsdgf", DateTime.Now, DateTime.Now.AddMinutes(10)),
                new Reminder("T2", "fgsgsfdgsdgf", DateTime.Now, DateTime.Now.AddMinutes(10)),
                new Reminder("T3", "fgsgsfdgsdgf", DateTime.Now.AddDays(3), DateTime.Now.AddDays(3).AddMinutes(10)),
            };
            Months = new ObservableCollection<Month>()
            {
                new Month(DateTime.Now.AddMonths(-1)),
                new Month(),
                new Month(DateTime.Now.AddMonths(1))
            };
            InitializeComponent();
        }

        private async void ButtonLeft_Clicked(object sender, EventArgs e)
        {

        }

        private async void ButtonRight_Clicked(object sender, EventArgs e)
        {

        }


        private int previous;
        private async void daysCollection_Scrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            if (e.FirstVisibleItemIndex - previous > 0)
            {
                await Task.Run(() => ChangeMonthToNext());
            }
            else if (e.FirstVisibleItemIndex - previous < 0)
            {
                //await Task.Run(() => ChangeMonthToPrevious());
            }
            previous = e.FirstVisibleItemIndex;
        }


        public async void ChangeMonthToNext()
        {
            Months.Remove(Months[0]);
            Months.Add(new Month(Months.Last().Days[20].AddMonths(1)));
        }
        public async void ChangeMonthToPrevious()
        {
            Months.Remove(Months[2]);
            //await Task.Delay(500);
            Months.Add(new Month(Months[0].Days[20].AddMonths(1)));
        }
    }

    public class Month
    {
        public ObservableCollection<DateTime> Days { get; set; }

        public Month()
            : this(DateTime.Now)
        {
        }

        public Month(DateTime date)
        {
            var monthStart = new DateTime(date.Year, date.Month, 1);
            DateTime weekStart = monthStart.AddDays(-(int)monthStart.DayOfWeek + 1);
            Days = new ObservableCollection<DateTime>();
            for (int i = 0; i < 42; i++)
            {
                Days.Add(weekStart.AddDays(i));
            }
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