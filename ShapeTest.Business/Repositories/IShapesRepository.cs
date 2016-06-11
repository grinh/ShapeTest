using System.Collections.Generic;
using ShapeTest.Business.Entities;

namespace ShapeTest.Business.Repositories
{
    public interface IShapesRepository
    {
        event ShapeAddedEventHandler ShapeAdded;

        IList<IShape> GetShapes();

        void AddShape(IShape shape);

        bool RemoveShape(IShape shape);
    }
}
