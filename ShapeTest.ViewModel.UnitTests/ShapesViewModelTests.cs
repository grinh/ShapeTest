using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShapeTest.Business.Entities;
using ShapeTest.Business.Repositories;
using ShapeTest.Business.Services;
using ShapeTests.ViewModel;

namespace ShapeTest.ViewModel.UnitTests
{
	[TestClass]
    public class ShapesViewModelTests
	{
		private MvvmCrossTestSetup TestSetup;
		private const double precision = 0.001;
	    private Mock<IShapesRepository> _MockShapesRepository;
	    private Mock<IComputeAreaService> _MockComputeAreaService;
	    private Mock<ISubmissionService> _MockSubmissionService;

		[TestInitialize]
	    public void Setup()
	    {
			TestSetup = new MvvmCrossTestSetup();
			TestSetup.Setup();
			_MockShapesRepository = new Mock<IShapesRepository>();
			_MockComputeAreaService = new Mock<IComputeAreaService>();
			_MockSubmissionService = new Mock<ISubmissionService>();

		}

		[TestMethod]
	    public void ShoudComputeTotalArea()
		{
			const double expectedTotalArea = 4d;

			var shapes = new List<IShape>()
			{
				new Square
				{
					SideBase = 2
				}
			};

			_MockShapesRepository.Setup(p => p.GetShapes()).Returns(shapes);
			_MockComputeAreaService.Setup(p => p.ComputeTotalArea()).Returns(expectedTotalArea);

			var viewModel = new ShapesViewModel(_MockShapesRepository.Object, _MockComputeAreaService.Object,_MockSubmissionService.Object);

			viewModel.TotalArea.Should().BeApproximately(0, precision);

			viewModel.ComputeTotalArea();

			viewModel.TotalArea.Should().BeApproximately(expectedTotalArea, precision);

//			var dispatcher = new MockMvxViewDispatcher(viewDispatcherMock);
//
//			Ioc.RegisterSingleton(dispatcher);
//			Ioc.RegisterSingleton<IMvxMainThreadDispatcher>(dispatcher);
		}

    }
}
