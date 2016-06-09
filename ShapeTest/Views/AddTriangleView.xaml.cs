using ShapeTests.ViewModel.ViewModels;

namespace ShapeTest.Wpf.Views
{
    public partial class AddTriangleView
    {
        public AddTriangleView()
        {
            InitializeComponent();
        }

        public new AddTriangleViewModel ViewModel
        {
            get { return (AddTriangleViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }
    }
}
