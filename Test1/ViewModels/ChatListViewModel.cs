using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Test1.Models;
using Xamarin.Forms;

namespace Test1.ViewModels
{
    public class ChatListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        public List<Chat> ChatList { get; set; }
        public ICommand IsFavoriteChangedCommand { get; }

        public ChatListViewModel()
        {
            IsFavoriteChangedCommand = new Command(IsFavoriteChanged);

            ChatList = new List<Chat> { new Chat("Maria", "https://pbs.twimg.com/profile_images/663765224751808513/xfjW4C_6_400x400.png", DateTime.Now, "Hi", true),
            new Chat("Nike", "https://pbs.twimg.com/profile_images/663765224751808513/xfjW4C_6_400x400.png", DateTime.Now, "gsfdgsgfgggggggggggggggggggggggggggggggjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjj", false),
            new Chat("Maria", "https://pbs.twimg.com/profile_images/663765224751808513/xfjW4C_6_400x400.png", DateTime.Now, "oijfojgosdjdgosjgosij", false),
            new Chat("Un", "https://pbs.twimg.com/profile_images/663765224751808513/xfjW4C_6_400x400.png", DateTime.Now, "1234567897654321", false),
            new Chat("Un", "https://pbs.twimg.com/profile_images/663765224751808513/xfjW4C_6_400x400.png", DateTime.Now, "1234567897654321", false),
            new Chat("Un", "https://pbs.twimg.com/profile_images/663765224751808513/xfjW4C_6_400x400.png", DateTime.Now, "1234567897654321", false),
            new Chat("Un", "https://pbs.twimg.com/profile_images/663765224751808513/xfjW4C_6_400x400.png", DateTime.Now, "1234567897654321", false),
            new Chat("Un", "https://pbs.twimg.com/profile_images/663765224751808513/xfjW4C_6_400x400.png", DateTime.Now, "1234567897654321", false),
            new Chat("Un", "https://pbs.twimg.com/profile_images/663765224751808513/xfjW4C_6_400x400.png", DateTime.Now, "1234567897654321", false),
            new Chat("Un", "https://pbs.twimg.com/profile_images/663765224751808513/xfjW4C_6_400x400.png", DateTime.Now, "1234567897654321", false),
            new Chat("Un", "https://pbs.twimg.com/profile_images/663765224751808513/xfjW4C_6_400x400.png", DateTime.Now, "1234567897654321", false),
            new Chat("Un", "https://pbs.twimg.com/profile_images/663765224751808513/xfjW4C_6_400x400.png", DateTime.Now, "1234567897654321", false),
            new Chat("Un", "https://pbs.twimg.com/profile_images/663765224751808513/xfjW4C_6_400x400.png", DateTime.Now, "1234567897654321", false),
            new Chat("Un", "https://pbs.twimg.com/profile_images/663765224751808513/xfjW4C_6_400x400.png", DateTime.Now, "1234567897654321", false),
            new Chat("Un", "https://pbs.twimg.com/profile_images/663765224751808513/xfjW4C_6_400x400.png", DateTime.Now, "1234567897654321", false),
            new Chat("Man", "https://pbs.twimg.com/profile_images/663765224751808513/xfjW4C_6_400x400.png", DateTime.Now, "Bye", false),};
        }

        public void IsFavoriteChanged()
        {
            return;
        }
    }
}
