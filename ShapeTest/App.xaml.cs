using System;
using System.Windows;
using MvvmCross.Platform;
using MvvmCross.Wpf.Views;
using MvvmCross.Core.ViewModels;

namespace ShapeTest.Wpf
{
    public partial class App : Application
    {
        private bool _SetupComplete = false;

        private void DoSetup()
        {
            LoadMvxAssemblyResources();

            var presenter = new ShapeTestPresenter(MainWindow);
            var setup = new Setup(Dispatcher, presenter);
            setup.Initialize();

            var start = Mvx.Resolve<IMvxAppStart>();
            start.Start();

            _SetupComplete = true;
        }

        protected override void OnActivated(EventArgs e)
        {
            if (!_SetupComplete)
                DoSetup();

            base.OnActivated(e);
        }

        private void LoadMvxAssemblyResources()
        {
            for (var i = 0; ; i++)
            {
                string key = "MvxAssemblyImport" + i;
                var data = TryFindResource(key);
                if (data == null)
                    return;
            }
        }
    }
}
