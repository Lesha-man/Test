using System.ComponentModel;
using System.Windows.Input;
using Test1.Models;
using Test1.Views.Pages;
using Xamarin.Forms;

namespace Test1.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private User user;
        INavigation Navigation { get; set; }
        public ICommand SignUpCommand { get; }
        public ICommand SignInCommand { get; }
        public ICommand SignInWithGoogleCommand { get; }
        public ICommand SignInWithFacebookCommand { get; }
        public UserViewModel(INavigation navigation)
        {
            Navigation = navigation;
            user = new User();
            SignInCommand = new Command(SignIn);
            SignUpCommand = new Command(SignUp);
            SignInWithFacebookCommand = new Command(SignInWithFacebook);
            SignInWithGoogleCommand = new Command(SignInWithGoogle);
        }
        public string Name
        {
            get { return user.Name; }
            set
            {
                if (user.Name != value)
                {
                    user.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public string Email
        {
            get { return user.Email; }
            set
            {
                if (user.Email != value)
                {
                    user.Email = value;
                    OnPropertyChanged("Email");
                }
            }
        }
        public string Pass
        {
            get { return user.Pass; }
            set
            {
                if (user.Pass != value)
                {
                    user.Pass = value;
                    OnPropertyChanged("Pass");
                }
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        public async void SignUp()
        {
            if (user == null)
                return;
            await Navigation.PushAsync(new ChatListPage());

        }
        public void SignIn()
        {
            if (user != null)
                return;  //Something....
        }
        public void SignInWithFacebook()
        {
            if (user != null)
                return;  //Something....
        }
        public void SignInWithGoogle()
        {
            if (user != null)
                return;  //Something....
        }
    }
}
