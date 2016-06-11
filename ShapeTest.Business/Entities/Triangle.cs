namespace ShapeTest.Business.Entities
{
    using System;
    using System.Collections.Generic;

	public interface IShape
	{
		string Name
		{
			get; 
			set;
		}

		double CalculateArea();
	}

	public class ObservableEntity
	{
		public void OnEntityChanged()
		{
			EntityChangedEventHandler handler = EntityChanged;
			handler?.Invoke(this, EventArgs.Empty);
		}

		public void SetAndRaiseIfChanged<T>(ref T backingField, T newValue)
		{
			if (!EqualityComparer<T>.Default.Equals(backingField, newValue))
			{
				backingField = newValue;
				OnEntityChanged();
			}
		}

		public event EntityChangedEventHandler EntityChanged;
	}


    public class Triangle: ObservableEntity, IShape
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
		    return 0.5*Base*Height;
	    }

	    public double Base
        {
            get { return _Base; }
            set { SetAndRaiseIfChanged(ref _Base, value); }
        }

        public double Height
        {
            get { return _Height;}
            set { SetAndRaiseIfChanged(ref _Height, value); }
        }
    }
}
