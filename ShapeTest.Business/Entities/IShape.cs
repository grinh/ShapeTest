namespace ShapeTest.Business.Entities
{
	public interface IShape
	{
		string Name
		{
			get; 
			set;
		}

		double CalculateArea();
	}
}