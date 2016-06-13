using System;

namespace ShapeTest.Business.Entities
{
	public sealed class Circle : ObservableEntity, IShape
	{
		private string _Name;
		private double _Radius;

		public string Name
		{
			get { return _Name; }
			set { SetAndRaiseIfChanged(ref _Name, value); }
		}


		public double Radius
		{
			get { return _Radius; }
			set { SetAndRaiseIfChanged(ref _Radius, value); }
		}

		public double CalculateArea()
		{
			return Math.PI * _Radius * _Radius;
		}
	}
}