using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeTest.Business.Entities;
using ShapeTest.Business.Repositories;

namespace ShapeTest.Business.UnitTests
{
	[TestClass]
	public class ShapeRepositoryTests
	{
		[TestMethod]
		public void ShouldAddShape()
		{
			const int expectedCount = 1;

			var shapeRepo = new ShapesRepository();

			shapeRepo.GetShapes().Clear();

			var shape = new Triangle();
			shapeRepo.MonitorEvents();

			shapeRepo.AddShape(shape);
			var shapesFromRepo = shapeRepo.GetShapes();

			shapeRepo.ShouldRaise(nameof(shapeRepo.ShapeAdded));

			shapesFromRepo.Count.Should().Be(expectedCount);

			shapesFromRepo.First().Should().Be(shape);
		}

		[TestMethod]
		public void ShouldRemoveShape()
		{
			const int expectedCount = 0;

			var shapeRepo = new ShapesRepository();

			shapeRepo.GetShapes().Clear();

			var shape = new Triangle();

			shapeRepo.AddShape(shape);

			shapeRepo.RemoveShape(shape);

			var shapesFromRepo = shapeRepo.GetShapes();

			shapesFromRepo.Count.Should().Be(expectedCount);
		}

		[TestMethod]
		public void ShouldNotRemoveAnyShape()
		{
			const int expectedCount = 1;

			var shapeRepo = new ShapesRepository();

			shapeRepo.GetShapes().Clear();

			var shape = new Triangle();
			var shape2 = new Square();

			shapeRepo.AddShape(shape);

			shapeRepo.RemoveShape(shape2);
			shapeRepo.RemoveShape(null);

			var shapesFromRepo = shapeRepo.GetShapes();

			shapesFromRepo.Count.Should().Be(expectedCount);

			shapesFromRepo.First().Should().Be(shape);
		}
	}
}
