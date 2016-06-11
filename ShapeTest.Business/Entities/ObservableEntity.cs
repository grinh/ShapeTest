using System;
using System.Collections.Generic;

namespace ShapeTest.Business.Entities
{
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
}