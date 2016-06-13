using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvvmCross.Core.ViewModels;
using ShapeTest.Business.Entities;
using ShapeTest.Business.Enums;
using ShapeTest.Business.Repositories;
using ShapeTest.Business.Services;
using ShapeTests.ViewModel;
using ShapeTests.ViewModel.ViewModels;

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

			viewModel.ComputeAreaCommand.Execute(null);

			viewModel.TotalArea.Should().BeApproximately(expectedTotalArea, precision);
		}

        [TestMethod]
	    public void ShouldRemoveSelectedShape()
        {
            const int expectedCount = 0;

            var shapes = new List<IShape>()
            {
                new Square
                {
                    SideBase = 2
                }
            };

            _MockShapesRepository.Setup(p => p.GetShapes()).Returns(shapes);
            _MockShapesRepository.Setup(p => p.RemoveShape(It.IsAny<IShape>())).Callback<IShape>(sh => shapes.Remove(sh));

            var viewModel = new ShapesViewModel(_MockShapesRepository.Object, _MockComputeAreaService.Object, _MockSubmissionService.Object);

            viewModel.Start();

            viewModel.SelectedShape = shapes.Single();

            viewModel.RemoveShapeCommand.Execute(null);

            shapes.Count.Should().Be(expectedCount);
	    }

        [TestMethod]
        public void ShouldNotRemoveAnyShape()
        {
            const int expectedCount = 1;

            var shapes = new List<IShape>()
            {
                new Square
                {
                    SideBase = 2
                }
            };

            _MockShapesRepository.Setup(p => p.GetShapes()).Returns(shapes);
            _MockShapesRepository.Setup(p => p.RemoveShape(It.IsAny<IShape>())).Callback<IShape>(sh => shapes.Remove(sh));

            var viewModel = new ShapesViewModel(_MockShapesRepository.Object, _MockComputeAreaService.Object, _MockSubmissionService.Object);

            viewModel.Start();

            viewModel.SelectedShape = null;

            viewModel.RemoveShapeCommand.Execute(null);

            shapes.Count.Should().Be(expectedCount);
        }


        [TestMethod]
	    public void ShoudShowAddNewShapeWindow()
        {
            var expectedCalledType = typeof(AddShapeViewModel);

            var viewModel = new ShapesViewModel(_MockShapesRepository.Object, _MockComputeAreaService.Object, _MockSubmissionService.Object);

            Type calledType = null;

            TestSetup.Setup();

            TestSetup.MvxViewDispatcher.Setup(p => p.ShowViewModel(It.IsAny<MvxViewModelRequest>())).Callback<MvxViewModelRequest>(request => calledType = request.ViewModelType);

            viewModel.AddShapeCommand.Execute(null);
            
            TestSetup.MvxViewDispatcher.Verify(p=>p.ShowViewModel(It.IsAny<MvxViewModelRequest>()));
            calledType.Should().Be(expectedCalledType);
        }

	    [TestMethod]
	    public void ShouldAddShapeToShapesWhenShapeIsAddedToRepo()
	    {
	        const int expectedCount = 2;

            var shapes = new List<IShape>()
            {
                new Square
                {
                    SideBase = 2
                }
            };
            
            _MockShapesRepository.Setup(p => p.GetShapes()).Returns(shapes);

            var viewModel = new ShapesViewModel(_MockShapesRepository.Object, _MockComputeAreaService.Object,_MockSubmissionService.Object);

            viewModel.Start();

            _MockShapesRepository.Raise(repository => repository.ShapeAdded += null, new ShapeEventArgs(new Circle()));

	        viewModel.Shapes.Count.Should().Be(expectedCount);
	    }

	    [TestMethod]
	    public async Task ShouldSubmitData()
        {
            var viewModel = new ShapesViewModel(_MockShapesRepository.Object, _MockComputeAreaService.Object, _MockSubmissionService.Object);

            await viewModel.SubmitAreaAsync();

            _MockSubmissionService.Verify(p=>p.SubmitTotalArea(It.IsAny<double>()));

            viewModel.SubmissionResult.Should().Be(SubmissionResult.Success);

            viewModel.SubmissionInProgress.Should().Be(false);

            viewModel.SubmitAreaCommand.CanExecute().Should().Be(true);
        }

        [TestMethod]
        public async Task ShouldFailSubmitingData()
        {
            _MockSubmissionService.Setup(p => p.SubmitTotalArea(It.IsAny<double>())).Throws(new Exception());

            var viewModel = new ShapesViewModel(_MockShapesRepository.Object, _MockComputeAreaService.Object, _MockSubmissionService.Object);

            await viewModel.SubmitAreaAsync();

            _MockSubmissionService.Verify(p => p.SubmitTotalArea(It.IsAny<double>()));

            viewModel.SubmissionResult.Should().Be(SubmissionResult.Failure);
            
            viewModel.SubmissionInProgress.Should().Be(false);

            viewModel.SubmitAreaCommand.CanExecute().Should().Be(true);
        }

        [TestMethod]
        public async Task ShouldNotSubmitDataIfDataSubmissionIsInProgress()
        {
            _MockSubmissionService.Setup(p => p.SubmitTotalArea(It.IsAny<double>())).Callback(()=>Thread.Sleep(1000));

            var viewModel = new ShapesViewModel(_MockShapesRepository.Object, _MockComputeAreaService.Object, _MockSubmissionService.Object);

            //do not await this. Test needs to proceed before this method is compleated
            viewModel.SubmitAreaAsync();

            viewModel.SubmissionInProgress.Should().Be(true);

            viewModel.SubmitAreaCommand.CanExecute().Should().Be(false);

            await viewModel.SubmitAreaAsync();
        }
    }
}
