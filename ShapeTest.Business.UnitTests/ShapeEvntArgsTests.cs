using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeTest.Business.Entities;
using ShapeTest.Business.Repositories;

namespace ShapeTest.Business.UnitTests
{
	[TestClass]
	public class ShapeEvntArgsTests
	{
		[TestMethod]
		public void ShoulBeTheSameShapeInEventArgs()
		{
			var circle = new Circle();

			var args = new ShapeEventArgs(circle);

			args.Shape.Should().Be(circle);
		}
	}
}
