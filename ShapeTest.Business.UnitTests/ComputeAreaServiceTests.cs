using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShapeTest.Business.Entities;
using ShapeTest.Business.Repositories;
using ShapeTest.Business.Services;

namespace ShapeTest.Business.UnitTest
{
    [TestClass]
    public class ComputeAreaServiceTests
    {
        private const double ExpectedPrecision = 0.001;

        private MockRepository _MockRepository;
        private Mock<IShapesRepository> _MockShapeRepository;

		[TestInitialize]
        public void Setup()
        {
            _MockRepository = new MockRepository(MockBehavior.Strict);
            _MockShapeRepository = _MockRepository.Create<IShapesRepository>();
		}

        [TestMethod]
        public void ShouldComputeTotalArea()
        {
            // Arrange
            const double expectedResult = 17;

            IList<IShape> shapes = new List<IShape>
            {
                new Triangle
                    {
                        Base = 2,
                        Height = 4
                    },
                new Triangle
                    {
                        Base = 3,
                        Height = 6
                    },
				new Square
					{
						SideBase = 2
					}
			};

            _MockShapeRepository.Setup(m => m.GetShapes()).Returns(shapes);

            ComputeAreaService computeAreaService = new ComputeAreaService(_MockShapeRepository.Object);

            // Act
            var result = computeAreaService.ComputeTotalArea();

            // Assert
            result.Should().BeApproximately(expectedResult, ExpectedPrecision);

            _MockShapeRepository.VerifyAll();
        }

		[TestMethod]
		public void ShouldComputeEmpty()
		{
			// Arrange
			const double expectedResult = 0;

			IList<IShape> shapes = new List<IShape>();

			_MockShapeRepository.Setup(m => m.GetShapes()).Returns(shapes);

			ComputeAreaService computeAreaService = new ComputeAreaService(_MockShapeRepository.Object);

			// Act
			var result = computeAreaService.ComputeTotalArea();

			// Assert
			result.Should().BeApproximately(expectedResult, ExpectedPrecision);

			_MockShapeRepository.VerifyAll();
		}
	}
}
