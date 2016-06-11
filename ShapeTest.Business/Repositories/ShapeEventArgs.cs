using System;
using ShapeTest.Business.Entities;

namespace ShapeTest.Business.Repositories
{
    public class ShapeEventArgs : EventArgs
    {
        public ShapeEventArgs(IShape shape)
        {
            Shape = shape;
        }

        public IShape Shape { get; }
    }
}
