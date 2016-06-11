using ShapeTest.Business.Repositories;

namespace ShapeTest.Business.Services
{
    using System.Linq;

    public class ComputeAreaService : IComputeAreaService
    {
        private readonly IShapesRepository _ShapesRepo;

        public ComputeAreaService(IShapesRepository shapesRepo)
        {
            _ShapesRepo = shapesRepo;
        }

        public double ComputeTotalArea()
        {
            var shapes = _ShapesRepo.GetShapes();

            return shapes.Sum(shape => shape.CalculateArea());
        }
    }
}
