using System.Collections.Generic;
using ShapeTest.Business.Entities;

namespace ShapeTest.Business.Repositories
{
    public class ShapesRepository : IShapesRepository
    {
        private readonly IList<IShape> _Shapes; 

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
                }
            };
        }

        public event ShapeAddedEventHandler ShapeAdded;

        public IList<IShape> GetShapes()
        {
            return _Shapes;
        }

        public void AddShape(IShape shape)
        {
            _Shapes.Add(shape);
            OnShapeAdded(shape);
        }

        public bool RemoveShape(IShape shape)
        {
            return _Shapes.Remove(shape);
        }

        protected void OnShapeAdded(IShape shape)
        {
            ShapeAddedEventHandler handler = ShapeAdded;
            handler?.Invoke(this, new ShapeEventArgs(shape));
        }
    }
}
