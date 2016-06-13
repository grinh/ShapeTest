namespace ShapeTest.Business.Entities
{
    /// <summary>
    /// Shape interface. All shapes needs to implement it
    /// </summary>
	public interface IShape
	{
        /// <summary>
        /// Custom name of a shape
        /// </summary>
		string Name
		{
			get; 
			set;
		}

        /// <summary>
        /// Can compute shape area
        /// </summary>
        /// <returns></returns>
		double CalculateArea();
	}
}