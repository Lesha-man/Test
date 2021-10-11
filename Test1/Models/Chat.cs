using System;
using Xamarin.Forms;

namespace Test1.Models
{
    public class Chat
    {

        public string Name { get; set; }
        public ImageSource Image { get; set; }
        public DateTime Time { get; set; }
        public string LastMessage { get; set; }
        public bool IsFavorite { get; set; }
        public Chat(string name, string image, DateTime time, string lastMessage, bool isFavorite)
        {
            Name = name;
            Image = image;
            Time = time;
            LastMessage = lastMessage;
            IsFavorite = isFavorite;
        }
    }
}
