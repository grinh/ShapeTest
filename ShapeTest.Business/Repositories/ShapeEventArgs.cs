using System;
using ShapeTest.Business.Entities;

namespace ShapeTest.Business.Repositories
{
    public class ShapeEventArgs : EventArgs
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="shape"></param>
        public ShapeEventArgs(IShape shape)
        {
            Shape = shape;
        }

        /// <summary>
        /// Shape
        /// </summary>
        public IShape Shape { get; }
    }
}
