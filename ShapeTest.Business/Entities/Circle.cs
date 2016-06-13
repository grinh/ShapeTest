using System;

namespace ShapeTest.Business.Entities
{
	public sealed class Circle : ObservableEntity, IShape
    {
	    #region Fields

	    /// <summary>
	    /// Custom name of a shape
	    /// </summary>
	    private string _Name;

	    /// <summary>
	    /// Radius of a circle
	    /// </summary>
	    private double _Radius;

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
	    /// Radius of a circle
	    /// </summary>
	    public double Radius
	    {
	        get { return _Radius; }
	        set { SetAndRaiseIfChanged(ref _Radius, value); }
	    }

	    #endregion

	    #region Methods

	    /// <summary>
	    /// Can compute shape area
	    /// </summary>
	    /// <returns></returns>
	    public double CalculateArea()
	    {
	        return Math.PI*_Radius*_Radius;
	    }

	    #endregion
	}
}