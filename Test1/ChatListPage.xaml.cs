using Test1.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatListPage : ContentPage
    {
        public readonly ChatListViewModel _viewModel;
        public ChatListPage()
        {
            BindingContext = _viewModel = new ChatListViewModel();

            InitializeComponent();
        }

        private void CheckBox_CheckedChanged()
        {

        }
    }
}