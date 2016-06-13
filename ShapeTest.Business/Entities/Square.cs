namespace ShapeTest.Business.Entities
{
	public sealed class Square : ObservableEntity, IShape
	{
	    #region Fields

	    /// <summary>
	    /// Square is rectangle with equal width and length
	    /// </summary>
	    private readonly Rectangle _Rect;

	    #endregion

	    #region Properties

	    /// <summary>
	    /// Custom name of a shape
	    /// </summary>
	    public string Name
	    {
	        get { return _Rect.Name; }
	        set { _Rect.Name = value; }
	    }

	    /// <summary>
	    /// Side length of rectangle
	    /// </summary>
	    public double SideLength
	    {
	        get { return _Rect.Length; }
	        set
	        {
	            _Rect.Length = value;
	            _Rect.Width = value;
	        }
	    }

	    #endregion

	    #region Constructor

	    /// <summary>
	    /// Class constructor
	    /// </summary>
	    public Square()
	    {
	        _Rect = new Rectangle();
	    }

	    #endregion

	    #region Methods

	    /// <summary>
	    /// Can compute shape area
	    /// </summary>
	    /// <returns></returns>
	    public double CalculateArea()
	    {
	        return _Rect.CalculateArea();
	    }

	    #endregion
	}
}