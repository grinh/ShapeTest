using System.Collections.Generic;
using ShapeTest.Business.Entities;

namespace ShapeTest.Business.Repositories
{
    public class ShapesRepository : IShapesRepository
    {
        /// <summary>
        /// List of all shapes in repository
        /// </summary>
        private readonly IList<IShape> _Shapes;

        /// <summary>
        /// Event raised when shape is added to repository
        /// </summary>
        public event ShapeAddedEventHandler ShapeAdded;

        /// <summary>
        /// Default constructor with default shapes
        /// </summary>
        public ShapesRepository()
        {
            _Shapes = new List<IShape>
            {
                new Triangle
                {
                    Name = "Triangle 1",
                    Base = 12.5,
                    Height = 13 
                },
                new Triangle
                {
                    Name = "Triangle 2",
                    Base = 23.4,
                    Height = 14
                },
                new Triangle
                {
                    Name = "Triangle 3",
                    Base = 42,
                    Height = 22
                },
				new Rectangle()
				{
					Name = "Rectangle",
					Length = 42,
					Width = 22
				},
				new Square()
				{
					Name = "Square",
					SideLength = 22
				},
				new Circle()
				{
					Name = "Circle",
					Radius = 20
				}
			};
        }

        /// <summary>
        /// Returns list of shapes
        /// </summary>
        /// <returns></returns>
        public IList<IShape> GetShapes()
        {
            return _Shapes;
        }

        /// <summary>
        /// Adds new shape to repository
        /// </summary>
        /// <param name="shape"></param>
        public void AddShape(IShape shape)
        {
            _Shapes.Add(shape);
            OnShapeAdded(shape);
        }

        /// <summary>
        /// Removes shape from repository
        /// </summary>
        /// <param name="shape"></param>
        /// <returns></returns>
        public bool RemoveShape(IShape shape)
        {
            return _Shapes.Remove(shape);
        }

        /// <summary>
        /// Executes whenever new shape is added to repository
        /// </summary>
        /// <param name="shape"></param>
        protected void OnShapeAdded(IShape shape)
        {
            ShapeAddedEventHandler handler = ShapeAdded;
            handler?.Invoke(this, new ShapeEventArgs(shape));
        }
    }
}
