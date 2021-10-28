using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Test1.Models
{
    public class Year
    {
        public ObservableCollection<Month> Months { get; set;}
    }

    public class Month
    {
        public ObservableCollection<Day> Days { get; set; }
    }

    public class Day
    {
        public DateTime Date;
        public ObservableCollection<Event> Events { get; set; }
        public string Name { get; set; }
    }

    public class Event
    {
        public string Name { get; set; }
        public string Discription { get; set; }
        public DateTime Beginning { get; set; }
        public DateTime End { get; set; }
    }
}
