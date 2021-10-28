using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Test1.Views.Controls;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test1.Views.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RatingView : ContentView
    {

        public ObservableCollection<RatingItem> Items { get; set; }


        public static readonly BindableProperty SourceOnCheckProperty = BindableProperty.Create(
        nameof(SourceOnCheck),
        typeof(ImageSource),
        typeof(RatingView));

        public ImageSource SourceOnCheck
        {
            get => (ImageSource)GetValue(SourceOnCheckProperty);
            set => SetValue(SourceOnCheckProperty, value);
        }

        public static readonly BindableProperty SourceOnUncheckProperty = BindableProperty.Create(
            nameof(SourceOnUncheck),
            typeof(ImageSource),
            typeof(RatingView));

        public ImageSource SourceOnUncheck
        {
            get => (ImageSource)GetValue(SourceOnUncheckProperty);
            set => SetValue(SourceOnUncheckProperty, value);
        }

        public static readonly BindableProperty MaxValueProperty = BindableProperty.Create(
        nameof(MaxValue),
        typeof(uint),
        typeof(RatingView),
        propertyChanged: OnEventMaxValueChanged);

        public uint MaxValue
        {
            get => (uint)GetValue(MaxValueProperty);
            set
            {
                SetValue(MaxValueProperty, value);
                StarsInit();
            }
        }

        public static readonly BindableProperty ValueProperty = BindableProperty.Create(
        nameof(Value),
        typeof(uint),
        typeof(RatingView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanged: OnEventValueChanged);

        public uint Value
        {
            get => (uint)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }


        private void StarsInit()
        {
            for (int i = 0; i < MaxValue; i++)
            {
                Items.Add(new RatingItem());
            }
        }

        private void Tap_Tapped(object sender, EventArgs e)
        {
            Value = (uint)container.Children.IndexOf((Grid)sender) + 1;
        }

        public RatingView()
        {
            Items = new ObservableCollection<RatingItem>();
            InitializeComponent();
        }

        static void OnEventMaxValueChanged(BindableObject bindableObject, object oldValue, object newValue)
        {
            if (bindableObject is RatingView view)
            {
                view.StarsInit();
            }
        }

        static void OnEventValueChanged(BindableObject bindableObject, object oldValue, object newValue)
        {
            if (bindableObject is RatingView view)
            {
                if (view.MaxValue < view.Value)
                    view.Value = view.MaxValue;

                else if (view.Value < 0)
                {
                    view.Value = 0;
                    return;
                }

                for (int i = 0; i < view.MaxValue; i++)
                {
                    view.Items[i].Value = i < (uint)newValue;
                }
            }
        }
    }

    public class RatingItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        private bool _value = false;

        public bool Value 
        {
            get => _value;
            set 
            {
                _value = value;
                OnPropertyChanged("Value");
            } 
        }
    }
}