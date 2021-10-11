using System;
using Test1.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;
using Xamarin.Forms.Xaml;

namespace Test1.Views.Pages
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
    }
}