using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeTest.Business.Entities;
using ShapeTests.ViewModel.ViewModels;

namespace ShapeTest.ViewModel.UnitTests
{
    [TestClass]
    public class TriangleViewModelTests
    {
        [TestMethod]
        public void ShouldUpdateViewModelOnTriangleChanged()
        {
            // Arrange
            const string expectedName = "NewName";
            const double expectedBase = 42;
            const double expectedHeight = 3.14;

            Triangle testTriangle = CreateTriangle(expectedName, expectedBase, expectedHeight);

//            TriangleViewModel viewModel = new TriangleViewModel();
//
//            // Act
//            viewModel.Triangle = testTriangle;
//
//            // Assert
//            viewModel.Name.Should().Be(expectedName);
//            viewModel.Base.Should().Be(expectedBase);
//            viewModel.Height.Should().Be(expectedHeight);            
        }

        [TestMethod]
        public void ShouldUpdateTriangleNameWhenViewModelNameChanges()
        {
            // Arrange
            const string oldName = "OldName";
            const string expectedName = "NewName";
            const double expectedBase = 42;
            const double expectedHeight = 3.14;

            Triangle testTriangle = CreateTriangle(oldName, expectedBase, expectedHeight);

//            TriangleViewModel viewModel = new TriangleViewModel { Triangle = testTriangle };
//
//            // Act
//            viewModel.Name = expectedName;
//
//            // Assert
//            viewModel.Name.Should().Be(expectedName);
//            viewModel.Base.Should().Be(expectedBase);
//            viewModel.Height.Should().Be(expectedHeight);
//
//            testTriangle.Name.Should().Be(expectedName);
//            testTriangle.Base.Should().Be(expectedBase);
//            testTriangle.Height.Should().Be(expectedHeight);
        }

        [TestMethod]
        public void ShouldUpdateTriangleBaseWhenViewModelNameChanges()
        {
            // Arrange
            const double oldBase = 23;
            const string expectedName = "NewName";
            const double expectedBase = 42;
            const double expectedHeight = 3.14;

            Triangle testTriangle = CreateTriangle(expectedName, oldBase, expectedHeight);

//            TriangleViewModel viewModel = new TriangleViewModel { Triangle = testTriangle };
//
//            // Act
//            viewModel.Base = expectedBase;
//
//            // Assert
//            viewModel.Name.Should().Be(expectedName);
//            viewModel.Base.Should().Be(expectedBase);
//            viewModel.Height.Should().Be(expectedHeight);
//
//            testTriangle.Name.Should().Be(expectedName);
//            testTriangle.Base.Should().Be(expectedBase);
//            testTriangle.Height.Should().Be(expectedHeight);
        }

        [TestMethod]
        public void ShouldUpdateTriangleHeightWhenViewModelNameChanges()
        {
            // Arrange
            const double oldHeight = 12;
            const string expectedName = "NewName";
            const double expectedBase = 42;
            const double expectedHeight = 3.14;

            Triangle testTriangle = CreateTriangle(expectedName, expectedBase, oldHeight);

//            TriangleViewModel viewModel = new TriangleViewModel { Triangle = testTriangle };
//
//            // Act
//            viewModel.Height = expectedHeight;
//
//            // Assert
//            viewModel.Name.Should().Be(expectedName);
//            viewModel.Base.Should().Be(expectedBase);
//            viewModel.Height.Should().Be(expectedHeight);
//
//            testTriangle.Name.Should().Be(expectedName);
//            testTriangle.Base.Should().Be(expectedBase);
//            testTriangle.Height.Should().Be(expectedHeight);
        }

        private Triangle CreateTriangle(string name, double triBase, double triHeight)
        {
            return new Triangle
            {
                Name = name,
                Base = triBase,
                Height = triHeight
            };
        }
    }
}
