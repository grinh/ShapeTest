using System.Collections.Generic;
using ShapeTest.Business.Entities;

namespace ShapeTest.Business.Repositories
{
    public interface IShapesRepository
    {
        /// <summary>
        /// Event raised when shape is added to repository
        /// </summary>
        event ShapeAddedEventHandler ShapeAdded;

        /// <summary>
        /// Returns list of shapes
        /// </summary>
        /// <returns></returns>
        IList<IShape> GetShapes();

        /// <summary>
        /// Adds new shape to repository
        /// </summary>
        /// <param name="shape"></param>
        void AddShape(IShape shape);

        /// <summary>
        /// Removes shape from repository
        /// </summary>
        /// <param name="shape"></param>
        /// <returns></returns>
        bool RemoveShape(IShape shape);
    }
}
