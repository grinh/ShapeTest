using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using ShapeTest.Business.Repositories;
using ShapeTest.Business.Services;

namespace ShapeTests.ViewModel
{
    public class ShapeApplication : MvxApplication
    {
        public ShapeApplication()
        {
            Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<ShapesViewModel>());
        }

        public override void Initialize()
        {
            Mvx.LazyConstructAndRegisterSingleton<IShapesRepository>(() => new ShapesRepository());
            Mvx.RegisterType<IComputeAreaService, ComputeAreaService>();
            Mvx.RegisterType<ISubmissionService, SubmissionService>();
        }
    }
}
