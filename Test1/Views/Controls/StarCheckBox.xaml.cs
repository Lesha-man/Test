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
    public partial class StarCheckBox : ContentView
    {
        public static readonly BindableProperty IsCheckedProperty = BindableProperty.Create(
        nameof(IsChecked),
        typeof(bool),
        typeof(StarCheckBox),
        defaultBindingMode: BindingMode.TwoWay);

        public bool IsChecked
        {
            get => (bool)GetValue(IsCheckedProperty);
            set => SetValue(IsCheckedProperty, value);
        }

        public static readonly BindableProperty CheckedChangedProperty = BindableProperty.Create(
        nameof(CheckedChanged),
        typeof(ICommand),
        typeof(StarCheckBox));

        public ICommand CheckedChanged
        {
            get => (ICommand)GetValue(CheckedChangedProperty);
            set => SetValue(CheckedChangedProperty, value);
        }

        public static readonly BindableProperty StrokeProperty = BindableProperty.Create(
        nameof(Stroke),
        typeof(Brush),
        typeof(StarCheckBox));

        public Brush Stroke
        {
            get => (Brush)GetValue(StrokeProperty);
            set => SetValue(StrokeProperty, value);
        }

        public static readonly BindableProperty FillProperty = BindableProperty.Create(
        nameof(Fill),
        typeof(Brush),
        typeof(StarCheckBox));

        public Brush Fill
        {
            get => (Brush)GetValue(FillProperty);
            set => SetValue(FillProperty, value);
        }

        public static readonly BindableProperty BorderThicknessProperty = BindableProperty.Create(
        nameof(BorderThickness),
        typeof(double),
        typeof(StarCheckBox));

        public double BorderThickness
        {
            get => (double)GetValue(BorderThicknessProperty);
            set => SetValue(BorderThicknessProperty, value);
        }

        static void OnEventNameChanged(BindableObject bindable, object oldValue, object newValue)
        {
            return;
        }

        public static readonly BindableProperty CornerTypeProperty = BindableProperty.Create(
        nameof(CornerType),
        typeof(PenLineJoin),
        typeof(StarCheckBox));

        public PenLineJoin CornerType
        {
            get => (PenLineJoin)GetValue(CornerTypeProperty);
            set => SetValue(CornerTypeProperty, value);
        }


        public static readonly BindableProperty CornersNumberProperty = BindableProperty.Create(
        nameof(CornersNumber),
        typeof(int),
        typeof(StarCheckBox),
        propertyChanged: OnEventFormChanged);
        public int CornersNumber
        {
            get => (int)GetValue(CornersNumberProperty);
            set => SetValue(CornersNumberProperty, value);
        }

        public static readonly BindableProperty SizeProperty = BindableProperty.Create(
        nameof(Size),
        typeof(double),
        typeof(StarCheckBox),
        propertyChanged: OnEventFormChanged);
        public double Size
        {
            get => (double)GetValue(SizeProperty);
            set => SetValue(SizeProperty, value);
        }

        public static readonly BindableProperty RadiusProperty = BindableProperty.Create(
        nameof(Radius),
        typeof(double),
        typeof(StarCheckBox),
        propertyChanged: OnEventFormChanged);
        public double Radius
        {
            get => (double)GetValue(RadiusProperty);
            set => SetValue(RadiusProperty, value);
        }

        public PointCollection Points
        {
            get;
            set;
        }

        public StarCheckBox()
        {
            Points = new PointCollection();

            InitializeComponent();
        }

        private void StarPoints(int num_points, double outSize, double inSize)
        {
            Points.Clear();

            double outHalf = outSize / 2;
            double inHalf = inSize / 2;

            // Start at the top.
            double theta = -Math.PI / 2;
            double dtheta = Math.PI / num_points;
            for (int i = 0; i < num_points; i++)
            {
                Points.Add(new Point(
                    outHalf + outHalf * Math.Cos(theta),
                    outHalf + outHalf * Math.Sin(theta)));
                theta += dtheta;
                Points.Add(new Point(
                    outHalf + inHalf * Math.Cos(theta),
                    outHalf + inHalf * Math.Sin(theta)));
                theta += dtheta;
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            IsChecked = !IsChecked;
        }

        static void OnEventFormChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((StarCheckBox)bindable).StarPoints(((StarCheckBox)bindable).CornersNumber, ((StarCheckBox)bindable).Size, ((StarCheckBox)bindable).Radius);
        }
    }
}