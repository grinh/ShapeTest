namespace ShapeTest.Business.Entities
{
	public class Triangle : ObservableEntity, IShape
	{
		private string _Name;
		private double _Base;
		private double _Height;

		public string Name
		{
			get { return _Name; }
			set { SetAndRaiseIfChanged(ref _Name, value); }
		}

		public double CalculateArea()
		{
			return 0.5 * Base * Height;
		}

		public double Base
		{
			get { return _Base; }
			set { SetAndRaiseIfChanged(ref _Base, value); }
		}

		public double Height
		{
			get { return _Height; }
			set { SetAndRaiseIfChanged(ref _Height, value); }
		}
	}
}