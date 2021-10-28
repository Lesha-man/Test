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
    public partial class BindableLayoutPage : ContentPage
    {
        public readonly BindableLayoutViewModel _viewModel;
        public BindableLayoutPage()
        {
            BindingContext = _viewModel = new BindableLayoutViewModel();
            InitializeComponent();
        }
    }
}