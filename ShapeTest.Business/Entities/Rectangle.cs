namespace ShapeTest.Business.Entities
{
	public sealed class Rectangle : ObservableEntity, IShape
	{
	    #region Fields

	    /// <summary>
	    /// Custom name of a shape
	    /// </summary>
	    private string _Name;

	    /// <summary>
	    /// Width of rectangle
	    /// </summary>
	    private double _Width;

	    /// <summary>
	    /// Length of rectangle
	    /// </summary>
	    private double _Length;

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
	    /// Width of rectangle
	    /// </summary>
	    public double Width
	    {
	        get { return _Width; }
	        set { SetAndRaiseIfChanged(ref _Width, value); }
	    }

	    /// <summary>
	    /// Length of rectangle
	    /// </summary>
	    public double Length
	    {
	        get { return _Length; }
	        set { SetAndRaiseIfChanged(ref _Length, value); }
	    }

	    #endregion

	    #region Methods

	    /// <summary>
	    /// Can compute shape area
	    /// </summary>
	    /// <returns></returns>
	    public double CalculateArea()
	    {
	        return Width*Length;
	    }

	    #endregion
    }
}