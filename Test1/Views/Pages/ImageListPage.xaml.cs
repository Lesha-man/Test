using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test1.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test1.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageListPage : ContentPage
    {
        public readonly ImageListViewModel _viewModel;

        public ImageListPage()
        {
            BindingContext = _viewModel = new ImageListViewModel();
            InitializeComponent();
        }

    }
}