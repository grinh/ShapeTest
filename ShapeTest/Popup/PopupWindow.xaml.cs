namespace ShapeTest.Wpf.Popup
{
    using ShapeTests.ViewModel.ViewModels;

    /// <summary>
    /// Interaction logic for PopupWindow.xaml
    /// </summary>
    public partial class PopupWindow
    {
        private bool _CanClose;

        public PopupWindow()
        {
            InitializeComponent();
        }

        public IPopupViewModel ViewModel
        {
            get { return (IPopupViewModel)DataContext; }
            set { DataContext = value; }
        }

        public void ForceClose()
        {
            _CanClose = true;
            Close();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !_CanClose;
            base.OnClosing(e);
        }
    }
}
