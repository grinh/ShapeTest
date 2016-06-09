using System.Collections.Generic;
using ShapeTest.Business.Entities;

namespace ShapeTest.Business.Repositories
{
    public interface ITrianglesRepository
    {
        event TriangleAddedEventHandler TriangleAdded;

        List<Triangle> GetTriangles();

        void AddTriangle(Triangle triangle);

        bool RemoveTriangle(Triangle triangle);
    }
}
