using ShapeTest.Business.Repositories;
using System.Linq;

namespace ShapeTest.Business.Services
{
    public class ComputeAreaService : IComputeAreaService
    {
        /// <summary>
        /// Reference to shapes repository
        /// </summary>
        private readonly IShapesRepository _ShapesRepo;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="shapesRepo"></param>
        public ComputeAreaService(IShapesRepository shapesRepo)
        {
            _ShapesRepo = shapesRepo;
        }

        /// <summary>
        /// Computes total area of all shapes
        /// </summary>
        /// <returns></returns>
        public double ComputeTotalArea()
        {
            var shapes = _ShapesRepo.GetShapes();

            return shapes.Sum(shape => shape.CalculateArea());
        }
    }
}
