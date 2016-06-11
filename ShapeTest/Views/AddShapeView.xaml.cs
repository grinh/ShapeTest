using ShapeTests.ViewModel.ViewModels;

namespace ShapeTest.Wpf.Views
{
    public partial class AddShapeView
    {
        public AddShapeView()
        {
            InitializeComponent();
        }

        public new AddShapeViewModel ViewModel
        {
            get { return (AddShapeViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }
    }
}
