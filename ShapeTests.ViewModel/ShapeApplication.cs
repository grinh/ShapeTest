using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace ShapeTests.ViewModel
{
    using ShapeTest.Business.Repositories;
    using ShapeTest.Business.Services;

    public class ShapeApplication : MvxApplication
    {
        public ShapeApplication()
        {
            Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<ShapesViewModel>());
        }

        public override void Initialize()
        {
            Mvx.LazyConstructAndRegisterSingleton<ITrianglesRepository>(() => new TrianglesRepository());
            Mvx.RegisterType<IComputeAreaService, ComputeAreaService>();
            Mvx.RegisterType<ISubmissionService, SubmissionService>();
        }
    }
}
