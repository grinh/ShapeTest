using System.Windows;
using System.Windows.Controls;
using ShapeTest.Business.Entities;

namespace ShapeTest.Wpf.TemplateSelectors
{
	public class ShapeContentTemplateSelector: DataTemplateSelector
	{
		public DataTemplate TriangleTemplate { get; set; }
		public DataTemplate CircleTemplate { get; set; }
		public DataTemplate RectangleTemplate { get; set; }
		public DataTemplate SquareTemplate { get; set; }	

		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			if (item is Triangle)
			{
				return TriangleTemplate;
			}

			if (item is Circle)
			{
				return CircleTemplate;
			}

			if (item is Rectangle)
			{
				return RectangleTemplate;
			}

			if (item is Square)
			{
				return SquareTemplate;
			}

			return base.SelectTemplate(item, container);
		}
	}
}
