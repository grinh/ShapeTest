using System;
using ShapeTest.Business.Entities;

namespace ShapeTest.Business.Repositories
{
    public class TriangleEventArgs : EventArgs
    {
        public TriangleEventArgs(Triangle triangle)
        {
            Triangle = triangle;
        }

        public Triangle Triangle { get; }
    }
}
