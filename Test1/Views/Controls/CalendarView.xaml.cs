using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test1.Views.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarView : ContentView
    {
        public ObservableCollection<Month> Months { get; set; }
        public Month NextMonth { get; set; }
        public Month PreviousMonth { get; set; }

        public CalendarView()
        {
            Months = new ObservableCollection<Month>()
            {
                new Month(DateTime.Now.AddMonths(-1)),
                new Month(),
                new Month(DateTime.Now.AddMonths(1)),
            };
            InitializeComponent();
            carousel.CurrentItem = Months[1];
        }

        private void CarouselView_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
            if(e.CurrentItem is Month month)
            {
                MonthNameAndYear.Text = month.Date.ToString("MMMM yyyy");
                Months.Add(new Month(month.Date.AddMonths(1)));
            }
        }

        private void CarouselView_RemainingItemsThresholdReached(object sender, EventArgs e)
        {
            //if (((CarouselView)sender).CurrentItem  is Month month)
            //{
            //    Months.Add(new Month(month.Date.AddMonths(1)));                    
            //}
        }
    }


    public class Month : INotifyPropertyChanged
    {
        public ObservableCollection<Week> Weeks { get; set; }

        public DateTime Date { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public Month()
            :this(DateTime.Now)
        {
        }

        public Month(DateTime date)
        {
            Weeks = new ObservableCollection<Week>();
            Date = new DateTime(date.Year, date.Month, 1);
            DateTime weekStart = Date.AddDays(-(int)DateTime.Today.DayOfWeek);
            for (int i = 0; i < 6; i++)
            {
                ObservableCollection<Day> tempWeek = new ObservableCollection<Day>();
                for (int j = 0; j < 7; j++)
                {
                    tempWeek.Add(new Day(weekStart.AddDays(i * 7 + j)));
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
        public ObservableCollection<Event> Events { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public DateTime Date { get; set; }
        public int Number { get; set; }

        public Day(DateTime date)
        {
            Events = new ObservableCollection<Event>();
            Date = date;
        }
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }

    public class Event : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; set; }
        public string Discription { get; set; }
        public DateTime Beginning { get; set; }
        public DateTime End { get; set; }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}