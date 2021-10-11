using Test1.ViewModel;
using Xamarin.Forms;

namespace Test1
{
    public partial class MainPage : ContentPage
    {
        private readonly UserViewModel _viewModel;
    
        public MainPage()
        {
            BindingContext = _viewModel = new UserViewModel(Navigation);
            
            InitializeComponent();
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {

        }
    }
}
