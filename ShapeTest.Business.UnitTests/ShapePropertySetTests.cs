using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeTest.Business.Entities;

namespace ShapeTest.Business.UnitTests
{
	[TestClass]
	public class ShapePropertySetTests
	{
		[TestMethod]
		public void ShouldSetProperlyTriangleProperties()
		{
			const string name = "Shape";
			const double value1 = 2;
			const double value2 = 2;

			var triangle = new Triangle
			{
				Height = value1,
				Base = value2,
				Name = name
			};

			triangle.Name.Should().Be(name);
			triangle.Height.Should().Be(value1);
			triangle.Base.Should().Be(value2);
		}

		[TestMethod]
		public void ShouldSetProperlyRectangleProperties()
		{
			const string name = "Shape";
			const double value1 = 2;
			const double value2 = 3;

			var triangle = new Rectangle()
			{
				Length = value1,
				Width = value2,
				Name = name
			};

			triangle.Name.Should().Be(name);
			triangle.Length.Should().Be(value1);
			triangle.Width.Should().Be(value2);
		}

		[TestMethod]
		public void ShouldSetProperlySquareProperties()
		{
			const string name = "Shape";
			const double value1 = 2;
			var triangle = new Square()
			{
				SideLength = value1,
				Name = name
			};

			triangle.Name.Should().Be(name);
			triangle.SideLength.Should().Be(value1);
		}

		[TestMethod]
		public void ShouldSetProperlyCircleProperties()
		{
			const string name = "Shape";
			const double value1 = 2;

			var triangle = new Circle()
			{
				Radius = value1,
				Name = name
			};

			triangle.Name.Should().Be(name);
			triangle.Radius.Should().Be(value1);
		}
	}
}
