using MvvmCross.Wpf.Platform;
using System.Windows.Threading;
using MvvmCross.Core.ViewModels;
using MvvmCross.Wpf.Views;
using ShapeTests.ViewModel;

namespace ShapeTest.Wpf
{
    using MvvmCross.Platform.Platform;

    public class Setup : MvxWpfSetup
    {
        public Setup(Dispatcher uiThreadDispatcher, IMvxWpfViewPresenter presenter)
            : base(uiThreadDispatcher, presenter)
        {            
        }

        protected override IMvxApplication CreateApp()
        {
            return new ShapeApplication();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
    }
}
