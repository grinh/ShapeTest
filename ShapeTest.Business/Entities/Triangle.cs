namespace ShapeTest.Business.Entities
{
	public sealed class Triangle : ObservableEntity, IShape
	{
	    #region Fields

	    /// <summary>
	    /// Custom name of a shape
	    /// </summary>
	    private string _Name;

	    /// <summary>
	    /// Base of triangle
	    /// </summary>
	    private double _Base;

	    /// <summary>
	    /// Height of triangle
	    /// </summary>
	    private double _Height;

	    #endregion

	    #region Properties

	    /// <summary>
	    /// Custom name of a shape
	    /// </summary>
	    public string Name
	    {
	        get { return _Name; }
	        set { SetAndRaiseIfChanged(ref _Name, value); }
	    }

	    /// <summary>
	    /// Base of triangle
	    /// </summary>
	    public double Base
	    {
	        get { return _Base; }
	        set { SetAndRaiseIfChanged(ref _Base, value); }
	    }

	    /// <summary>
	    /// Height of triangle
	    /// </summary>
	    public double Height
	    {
	        get { return _Height; }
	        set { SetAndRaiseIfChanged(ref _Height, value); }
	    }

	    #endregion

	    #region Methods

	    /// <summary>
	    /// Can compute shape area
	    /// </summary>
	    /// <returns></returns>
	    public double CalculateArea()
	    {
	        return 0.5*Base*Height;
	    }

	    #endregion
    }
}