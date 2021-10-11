using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Test1.Model;
using Xamarin.Forms;

namespace Test1.ViewModel
{
    public class ChatListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public List<Chat> ChatList { get; set; }

        public ChatListViewModel()
        {
            ChatList = new List<Chat> { new Chat("Maria", "https://images.pexels.com/photos/1987301/pexels-photo-1987301.jpeg", DateTime.Now, "Hi", true),
            new Chat("Nike", "https://pbs.twimg.com/profile_images/663765224751808513/xfjW4C_6_400x400.png", DateTime.Now, "gsfdgsgfgggggggggggggggggggggggggggggggjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjj", false),
            new Chat("Maria", "https://images.pexels.com/photos/1987301/pexels-photo-1987301.jpeg", DateTime.Now, "oijfojgosdjdgosjgosij", false),
            new Chat("Un", "https://images.pexels.com/photos/1987301/pexels-photo-1987301.jpeg", DateTime.Now, "1234567897654321", false),
            new Chat("Man", "https://images.pexels.com/photos/1987301/pexels-photo-1987301.jpeg", DateTime.Now, "Bye", false),};
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
