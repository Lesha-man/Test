using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;
using Xamarin.Forms.Xaml;

namespace Test1.Views.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IconCheckBox : ContentView
    {
        public static readonly BindableProperty SourceOnCheckProperty = BindableProperty.Create(
        nameof(SourceOnCheck),
        typeof(ImageSource),
        typeof(IconCheckBox));

        public ImageSource SourceOnCheck
        {
            get => (ImageSource)GetValue(SourceOnCheckProperty);
            set => SetValue(SourceOnCheckProperty, value);
        }

        
        public static readonly BindableProperty SourceOnUncheckProperty = BindableProperty.Create(
        nameof(SourceOnUncheck),
        typeof(ImageSource),
        typeof(IconCheckBox));

        public ImageSource SourceOnUncheck
        {
            get => (ImageSource)GetValue(SourceOnUncheckProperty);
            set => SetValue(SourceOnUncheckProperty, value);
        }

        public static readonly BindableProperty IsCheckedProperty = BindableProperty.Create(
        nameof(IsChecked),
        typeof(bool),
        typeof(IconCheckBox),
        defaultBindingMode: BindingMode.TwoWay);


        public bool IsChecked
        {
            get => (bool)GetValue(IsCheckedProperty);
            set => SetValue(IsCheckedProperty, value);
        }

        public static readonly BindableProperty CheckedChangedProperty = BindableProperty.Create(
        nameof(CheckedChanged),
        typeof(ICommand),
        typeof(IconCheckBox));

        public ICommand CheckedChanged
        {
            get => (ICommand)GetValue(CheckedChangedProperty);
            set => SetValue(CheckedChangedProperty, value);
        }

        public IconCheckBox()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            IsChecked = !IsChecked;
        }
    }
}