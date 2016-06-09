using ShapeTests.ViewModel;

namespace ShapeTest.Wpf.Views
{
    public partial class ShapesView
    {
        public ShapesView()
        {
            InitializeComponent();
        }

        public new ShapesViewModel ViewModel
        {
            get { return (ShapesViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }
    }
}
