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

        public Calendar Calendar { get; set; }

        public CalendarView()
        {
            Calendar = new Calendar();
            InitializeComponent();
            carousel.CurrentItem = Calendar.Months[1];
        }


        private bool locker = true;
        private async void carousel_PositionChanged(object sender, PositionChangedEventArgs e)
        {
            //if (e.CurrentPosition == 2 && e.PreviousPosition == 1)
            //{
            //    if (!locker)
            //    {
            //        locker = true;
            //        return;
            //    }
            //    await Task.Run(() => Calendar.ChangeMonthToNext());
            //}
            //else if (e.CurrentPosition == 0 && e.PreviousPosition == 1)
            //{
            //    if (!locker)
            //    {
            //        locker = true;
            //        return;
            //    }
            //    await Task.Run(() => Calendar.ChangeMonthToPrevious());
            //    locker = false;
            //}
        }

        private async void ButtonLeft_Clicked(object sender, EventArgs e)
        {
            if (carousel.Position == 1)
            {
                carousel.Position--;
                await Task.Run(() => Calendar.ChangeMonthToPrevious());
            }
        }

        private async void ButtonRight_Clicked(object sender, EventArgs e)
        {
            if (carousel.Position == 1)
            {
                carousel.Position++;
                await Task.Run(() => Calendar.ChangeMonthToNext());
            }
        }

        private void DaySelected(object sender, EventArgs e)
        {
            Calendar.SelectedDay = (sender as Grid).BindingContext as Day;
            //(sender as Grid).BackgroundColor = Color.LightBlue;
        }

    }

    public class Calendar : INotifyPropertyChanged
    {
        private Day selectedDay;
        public ObservableCollection<Month> Months { get; set; }
        public Month CourrentMonth { get; set; }
        public ObservableCollection<Reminder> Reminders { get; set; }
        public Day SelectedDay { 
            get => selectedDay;
            set
            {
                selectedDay = value;
                OnPropertyChanged("SelectedDay");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Calendar()
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
                new Month(DateTime.Now.AddMonths(-1), Reminders),
                new Month(Reminders),
                new Month(DateTime.Now.AddMonths(1), Reminders)
            };
        }

        public async void ChangeMonthToNext()
        {
            await Task.Delay(500);
            Months.Remove(Months.First());
            Months.Add(new Month(Months.Last().Date.AddMonths(1), Reminders));
        }
        public async void ChangeMonthToPrevious()
        {
            Months.Remove(Months.Last());
            await Task.Delay(500);
            Months.Insert(0, new Month(Months.First().Date.AddMonths(-1), Reminders));
        }
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }

    public class Month : INotifyPropertyChanged
    {
        public ObservableCollection<Week> Weeks { get; set; }

        public DateTime Date { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public Month(ObservableCollection<Reminder> reminders)
            : this(DateTime.Now, reminders)
        {
        }

        public Month(DateTime date, ObservableCollection<Reminder> reminders)
        {
            Weeks = new ObservableCollection<Week>();
            Date = new DateTime(date.Year, date.Month, 1);
            DateTime weekStart = Date.AddDays(-(int)Date.DayOfWeek + 1);
            for (int i = 0; i < 6; i++)
            {
                ObservableCollection<Day> tempWeek = new ObservableCollection<Day>();
                for (int j = 0; j < 7; j++)
                {
                    DateTime dateOfDay = weekStart.AddDays(i * 7 + j);
                    tempWeek.Add(new Day(dateOfDay, new ObservableCollection<Reminder>(reminders.Where((r) => r.Beginning.Date == dateOfDay).ToList())));
                }
                Weeks.Add(new Week(tempWeek));
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }


    public class Week : INotifyPropertyChanged
    {
        public ObservableCollection<Day> Days { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public Week(ObservableCollection<Day> days)
        {
            Days = days;
        }
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }

    public class Day : INotifyPropertyChanged
    {
        private DateTime _date;
        private ObservableCollection<Reminder> reminders;

        public ObservableCollection<Reminder> Reminders
        {
            get => reminders;
            set
            {
                reminders = value;
                OnPropertyChanged("");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged("Date");
            }
        }
        public int Number { get; set; }

        public Day(DateTime date, ObservableCollection<Reminder> reminders)
        {
            Date = date;
            Reminders = reminders;
        }
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }

    public class Reminder : INotifyPropertyChanged
    {
        private string name;

        public Reminder(string name, string discription, DateTime beginning, DateTime end)
        {
            Name = name;
            Discription = discription;
            Beginning = beginning;
            End = end;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { 
            get => name;
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Discription { get; set; }
        public DateTime Beginning { get; set; }
        public DateTime End { get; set; }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}