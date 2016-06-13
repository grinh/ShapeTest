using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using ShapeTest.Business.Repositories;
using ShapeTest.Business.Services;
using ShapeTest.ViewModel.UnitTests.Helpers;
using ShapeTests.ViewModel;

namespace ShapeTest.ViewModel.UnitTests
{
    [TestClass]
    public class ShapeApplicationTests
    {
        private MvvmCrossTestSetup TestSetup;

        [TestInitialize]
        public void Setup()
        {
            TestSetup = new MvvmCrossTestSetup();
            TestSetup.Setup();
        }

        [TestMethod]
        public void ShouldRegisterInterfaces()
        {
            IMvxAppStart appStart;
            IShapesRepository shapesRepository;
            IComputeAreaService computeAreaService;
            ISubmissionService submissionService;

            var application = new ShapeApplication();
            application.Initialize();

            appStart = Mvx.Resolve<IMvxAppStart>();
            shapesRepository = Mvx.Resolve<IShapesRepository>();
            computeAreaService = Mvx.Resolve<IComputeAreaService>();
            submissionService = Mvx.Resolve<ISubmissionService>();

            appStart.Should().NotBeNull();
            shapesRepository.Should().NotBeNull();
            computeAreaService.Should().NotBeNull();
            submissionService.Should().NotBeNull();
        }
    }
}
