namespace ShapeTest.Business.Entities
{
	public sealed class Rectangle : ObservableEntity, IShape
	{
		private string _Name;
		private double _Width;
		private double _Length;

		public string Name
		{
			get { return _Name; }
			set { SetAndRaiseIfChanged(ref _Name, value); }
		}

		public double CalculateArea()
		{
			return Width * Length;
		}

		public double Width
		{
			get { return _Width; }
			set { SetAndRaiseIfChanged(ref _Width, value); }
		}

		public double Length
		{
			get { return _Length; }
			set { SetAndRaiseIfChanged(ref _Length, value); }
		}
	}
}