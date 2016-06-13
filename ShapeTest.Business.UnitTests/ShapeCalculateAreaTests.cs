using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeTest.Business.Entities;

namespace ShapeTest.Business.UnitTests
{
	[TestClass]
	public class ShapeCalculateAreaTests
	{
		private const double ExpectedPrecision = 0.001;

		[TestMethod]
		public void ShouldCalculateAreaOfTriandles()
		{
			const double expectedResult = 2d;
			const double expectedResult2 = 0d;
			const double expectedResult3 = 0d;
			const double expectedResult4 = 0d;
			const double expectedResult5 = 1000000d;
			const double expectedResult6 = 0.005d;

			var triangle = new Triangle
			{
				Base = 2d,
				Height = 2d,
			};

			var triangle2 = new Triangle();

			var triangle3 = new Triangle
			{
				Base = 0d,
				Height = 1d
			};

			var triangle4 = new Triangle
			{
				Base = 1d,
				Height = 0d
			};

			var triangle5 = new Triangle
			{
				Base = 2000000d,
				Height = 1d
			};

			var triangle6 = new Triangle
			{
				Base = 0.1,
				Height = 0.1d
			};

			var result  = triangle.CalculateArea();
			var result2 = triangle2.CalculateArea();
			var result3 = triangle3.CalculateArea();
			var result4 = triangle4.CalculateArea();
			var result5 = triangle5.CalculateArea();
			var result6 = triangle6.CalculateArea();

			result.Should().BeApproximately(expectedResult, ExpectedPrecision);
			result2.Should().BeApproximately(expectedResult2, ExpectedPrecision);
			result3.Should().BeApproximately(expectedResult3, ExpectedPrecision);
			result4.Should().BeApproximately(expectedResult4, ExpectedPrecision);
			result5.Should().BeApproximately(expectedResult5, ExpectedPrecision);
			result6.Should().BeApproximately(expectedResult6, ExpectedPrecision);
		}

		[TestMethod]
		public void ShouldCalculateAreaOfRectangles()
		{
			const double expectedResult = 4d;
			const double expectedResult2 = 0d;
			const double expectedResult3 = 0d;
			const double expectedResult4 = 0d;
			const double expectedResult5 = 2000000d;
			const double expectedResult6 = 0.01d;

			var rectangle = new Rectangle()
			{
				Width = 2d,
				Length = 2d,
			};

			var rectangle2 = new Rectangle();

			var rectangle3 = new Rectangle
			{
				Width = 0d,
				Length = 1d
			};

			var rectangle4 = new Rectangle
			{
				Width = 1d,
				Length = 0d
			};

			var rectangle5 = new Rectangle
			{
				Width = 2000000d,
				Length = 1d
			};

			var rectangle6 = new Rectangle
			{
				Width = 0.1d,
				Length = 0.1d
			};

			var result = rectangle.CalculateArea();
			var result2 = rectangle2.CalculateArea();
			var result3 = rectangle3.CalculateArea();
			var result4 = rectangle4.CalculateArea();
			var result5 = rectangle5.CalculateArea();
			var result6 = rectangle6.CalculateArea();

			result.Should().BeApproximately(expectedResult, ExpectedPrecision);
			result2.Should().BeApproximately(expectedResult2, ExpectedPrecision);
			result3.Should().BeApproximately(expectedResult3, ExpectedPrecision);
			result4.Should().BeApproximately(expectedResult4, ExpectedPrecision);
			result5.Should().BeApproximately(expectedResult5, ExpectedPrecision);
			result6.Should().BeApproximately(expectedResult6, ExpectedPrecision);
		}

		[TestMethod]
		public void ShouldCalculateAreaOfSquares()
		{
			const double expectedResult = 4d;
			const double expectedResult2 = 0d;
			const double expectedResult3 = 0d;
			const double expectedResult4 = 0.01d;
			const double expectedResult5 = 4000000000000d;

			var square = new Square()
			{
				SideLength = 2d,
				
			};

			var square2 = new Square();

			var square3 = new Square
			{
				SideLength = 0d,
			};

			var square4 = new Square
			{
				SideLength = 0.1d
			};

			var square5 = new Square
			{
				SideLength = 2000000d
			};

			var result = square.CalculateArea();
			var result2 = square2.CalculateArea();
			var result3 = square3.CalculateArea();
			var result4 = square4.CalculateArea();
			var result5 = square5.CalculateArea();

			result.Should().BeApproximately(expectedResult, ExpectedPrecision);
			result2.Should().BeApproximately(expectedResult2, ExpectedPrecision);
			result3.Should().BeApproximately(expectedResult3, ExpectedPrecision);
			result4.Should().BeApproximately(expectedResult4, ExpectedPrecision);
			result5.Should().BeApproximately(expectedResult5, ExpectedPrecision);
		}

		[TestMethod]
		public void ShouldCalculateAreaOfCircles()
		{
			const double expectedResult = 12.5663d;
			const double expectedResult2 = 0d;
			const double expectedResult3 = 0d;
			const double expectedResult4 = 0.0314d;
			const double expectedResult5 = 12566370614359.172;

			var circle = new Circle()
			{
				Radius = 2d,
			};

			var circle2 = new Circle();

			var circle3 = new Circle
			{
				Radius = 0d,
			};

			var circle4 = new Circle
			{
				Radius = 0.1d
			};

			var circle5 = new Circle
			{
				Radius = 2000000d
			};

			var result = circle.CalculateArea();
			var result2 = circle2.CalculateArea();
			var result3 = circle3.CalculateArea();
			var result4 = circle4.CalculateArea();
			var result5 = circle5.CalculateArea();

			result.Should().BeApproximately(expectedResult, ExpectedPrecision);
			result2.Should().BeApproximately(expectedResult2, ExpectedPrecision);
			result3.Should().BeApproximately(expectedResult3, ExpectedPrecision);
			result4.Should().BeApproximately(expectedResult4, ExpectedPrecision);
			result5.Should().BeApproximately(expectedResult5, ExpectedPrecision);
		}
	}
}
