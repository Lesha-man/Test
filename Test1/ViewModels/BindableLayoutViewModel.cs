using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Test1.ViewModels
{
    public class BindableLayoutViewModel
    {
        public ObservableCollection<Color> Colors { get; set; }

        public BindableLayoutViewModel()
        {
            Colors = new ObservableCollection<Color>()
            {
                Color.Red,
                Color.Green,
                Color.Yellow,
                Color.Blue,
                Color.Black
            };
        }
    }
}
