namespace ShapeTest.Business.Entities
{
	public class Square : ObservableEntity, IShape
	{
		private readonly Rectangle _Rect;

		public string Name
		{
			get { return _Rect.Name; }
			set { _Rect.Name = value; }
		}

		public double SideBase
		{
			get { return _Rect.Length; }
			set
			{
				_Rect.Length = value;
				_Rect.Width = value;
			}
		}

		public Square()
		{
			_Rect = new Rectangle();
		}

		public double CalculateArea()
		{
			return _Rect.CalculateArea();
		}
	}
}