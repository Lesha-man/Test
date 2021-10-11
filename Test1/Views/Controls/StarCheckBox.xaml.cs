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
        typeof(IconEntry),
        defaultBindingMode: BindingMode.TwoWay);

        public bool IsChecked
        {
            get => (bool)GetValue(IsCheckedProperty);
            set => SetValue(IsCheckedProperty, value);
        }

        public static readonly BindableProperty CheckedChangedProperty = BindableProperty.Create(
        nameof(CheckedChanged),
        typeof(ICommand),
        typeof(IconEntry));

        public ICommand CheckedChanged
        {
            get => (ICommand)GetValue(CheckedChangedProperty);
            set => SetValue(CheckedChangedProperty, value);
        }

        public static readonly BindableProperty StrokeProperty = BindableProperty.Create(
        nameof(Stroke),
        typeof(Brush),
        typeof(IconEntry));

        public Brush Stroke
        {
            get => (Brush)GetValue(StrokeProperty);
            set => SetValue(StrokeProperty, value);
        }

        public static readonly BindableProperty FillProperty = BindableProperty.Create(
        nameof(Fill),
        typeof(Brush),
        typeof(IconEntry));

        public Brush Fill
        {
            get => (Brush)GetValue(FillProperty);
            set => SetValue(FillProperty, value);
        }

        public static readonly BindableProperty BorderThicknessProperty = BindableProperty.Create(
        nameof(BorderThickness),
        typeof(double),
        typeof(IconEntry));

        public double BorderThickness
        {
            get => (double)GetValue(BorderThicknessProperty);
            set => SetValue(BorderThicknessProperty, value);
        }

        public static readonly BindableProperty CornerTypeProperty = BindableProperty.Create(
        nameof(CornerType),
        typeof(PenLineJoin),
        typeof(IconEntry));

        public PenLineJoin CornerType
        {
            get => (PenLineJoin)GetValue(CornerTypeProperty);
            set => SetValue(CornerTypeProperty, value);
        }

        public static readonly BindableProperty PointsProperty = BindableProperty.Create(
        nameof(Points),
        typeof(PointCollection),
        typeof(IconEntry));

        private int _cornerNumber;
        private int _size;
        private int _radius;

        public int CornersNumber
        {
            get => _cornerNumber;
            set 
            {
                _cornerNumber = value;
                StarPoints(_cornerNumber, _size, _radius);
            } 
        }
        public int Size
        {
            get => _size;
            set
            {
                _size = value;
                StarPoints(_cornerNumber, _size, _radius);
            }
        }
        public int Radius
        {
            get => _radius;
            set
            {
                _radius = value;
                StarPoints(_cornerNumber, _size, _radius);
            }
        }
        public PointCollection Points
        {
            get => (PointCollection)GetValue(PointsProperty);
            set => SetValue(PointsProperty, value);
        }
        public StarCheckBox()
        {
            InitializeComponent();
        }

        private void StarPoints(int num_points, double outSize, double inSize)
        {
            Points = new PointCollection();
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
    }
}