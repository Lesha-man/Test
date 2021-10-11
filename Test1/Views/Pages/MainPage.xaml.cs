using Test1.ViewModels;
using Xamarin.Forms;

namespace Test1.Views.Pages
{
    public partial class MainPage : ContentPage
    {
        private readonly UserViewModel _viewModel;
    
        public MainPage()
        {
            BindingContext = _viewModel = new UserViewModel(Navigation);
            
            InitializeComponent();
        }
    }
}
