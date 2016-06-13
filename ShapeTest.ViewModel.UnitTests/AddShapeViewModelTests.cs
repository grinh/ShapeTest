using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvvmCross.Core.ViewModels;
using ShapeTest.Business.Entities;
using ShapeTest.Business.Repositories;
using ShapeTests.ViewModel.ViewModels;

namespace ShapeTest.ViewModel.UnitTests
{
    [TestClass]
    public class AddShapeViewModelTests
    {
        private MvvmCrossTestSetup TestSetup;
        private const double precision = 0.001;
        private Mock<IShapesRepository> _MockShapesRepository;

        [TestInitialize]
        public void Setup()
        {
            TestSetup = new MvvmCrossTestSetup();
            TestSetup.Setup();
            _MockShapesRepository = new Mock<IShapesRepository>();
        }

        [TestMethod]
        public void ShouldAddNewShapes()
        {
            Type expectedType1 = typeof(Circle);
            Type expectedType2 = typeof(Triangle);
            Type expectedType3 = typeof(Square);
            Type expectedType4 = typeof(Rectangle);

            const int expectedCount = 4;
            var shapes = new List<IShape>();

            _MockShapesRepository.Setup(p => p.GetShapes()).Returns(shapes);
            _MockShapesRepository.Setup(p => p.AddShape(It.IsAny<IShape>())).Callback<IShape>(shape => shapes.Add(shape));

            

            var viewModel = new AddShapeViewModel(_MockShapesRepository.Object);

            viewModel.AddShapeCommand.Execute(typeof(Circle));
            viewModel.AddShapeCommand.Execute(typeof(Triangle));
            viewModel.AddShapeCommand.Execute(typeof(Square));
            viewModel.AddShapeCommand.Execute(typeof(Rectangle));

            shapes.Count.Should().Be(expectedCount);

            shapes.Should().Contain(p => p.GetType() == expectedType1);
            shapes.Should().Contain(p => p.GetType() == expectedType2);
            shapes.Should().Contain(p => p.GetType() == expectedType3);
            shapes.Should().Contain(p => p.GetType() == expectedType4);
        }

        [TestMethod]
        public void ShouldContainAllShapeTypes()
        {
            //each new shape type shoud be included in this list. Otherwise test will fail
            IList<Type> expectedShapeTypes =new List<Type> {typeof(Circle), typeof(Triangle), typeof(Square), typeof(Rectangle)};

            var viewModel = new AddShapeViewModel(_MockShapesRepository.Object);

            viewModel.ShapeTypes.Count.Should().Be(expectedShapeTypes.Count);

            viewModel.ShapeTypes.ShouldAllBeEquivalentTo(expectedShapeTypes);
        }

        [TestMethod]
        public void ShouldAlwaysBeModalAndTopMost()
        {
            var viewModel = new AddShapeViewModel(_MockShapesRepository.Object);
            viewModel.TopMost.Should().Be(true);
            viewModel.IsModal.Should().Be(true);
        }

        [TestMethod]
        public void ShouldSetAndGetOwnerId()
        {
            const int ownerId = 123;

            var viewModel = new AddShapeViewModel(_MockShapesRepository.Object);

            viewModel.OwnerId = ownerId;

            viewModel.OwnerId.Should().Be(ownerId);
        }

        [TestMethod]
        public void ShouldClosePopup()
        {
            var viewModel = new AddShapeViewModel(_MockShapesRepository.Object);

            TestSetup.Setup();

            viewModel.CancelCommand.Execute(null);

            TestSetup.MvxViewDispatcher.Verify(p=>p.ChangePresentation(It.IsAny<MvxClosePresentationHint>()));
        }
    }
}
