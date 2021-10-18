using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


namespace Test1.ViewModels
{
    public class ImageListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        public ObservableCollection<string> ImageList { get; set; }
        public ObservableCollection<string> List { get; set; }

        static Random random = new Random();
        private bool LoadingUp;
        public ICommand LoadUpNextCommand { get; }

        public ImageListViewModel()
        {
            LoadUpNextCommand = new Command(LoadUpNext);

            ImageList = new ObservableCollection<string>();
            List = new ObservableCollection<string> {
                "https://images.all-free-download.com/images/graphicthumb/colombia_91424.jpg",
                "https://icon-library.com/images/64-x-64-icon/64-x-64-icon-11.jpg",
                "https://icon-library.com/images/64-x-64-icon/64-x-64-icon-3.jpg",
                "https://icon-library.com/images/64-x-64-icon/64-x-64-icn-3.jpg"};
            for (int i = 0; i < 40; i++)
            {
                ImageList.Add(new string(List[random.Next(4)]));
            }
        }

        private async void LoadUpNext()
        {
            if (LoadingUp)
                return;
            LoadingUp = true;
            await LoadUp();
            LoadingUp = false;
        }

        private async Task LoadUp()
        {
            Debug.WriteLine("Loading up...");
            for (int i = 0; i < 40; i++)
            {
                await Task.Delay(100);
                ImageList.Add(new string(List[random.Next(4)]));
            }
            Debug.WriteLine("Done");
        }
    }
}
