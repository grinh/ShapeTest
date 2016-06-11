using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ShapeTest.Business.Entities;

namespace ShapeTest.Wpf.TemplateSelectors
{
	public class AddShapeButtonContentTemplateSelector: DataTemplateSelector
	{
		public DataTemplate UnknownShapeDataTemplate { get; set; }

		public DataTemplate TriangleDataTemplate { get; set; }
		public DataTemplate CircleDataTemplate { get; set; }
		public DataTemplate RectangleDataTemplate { get; set; }
		public DataTemplate SquarepeDataTemplate { get; set; }


		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			Type value = item as Type;
			if (value != null)
			{
				if (value == typeof(Triangle))
				{
					return TriangleDataTemplate;
				}

				if (value == typeof(Rectangle))
				{
					return RectangleDataTemplate;
				}

				if (value == typeof(Circle))
				{
					return CircleDataTemplate;
				}

				if (value == typeof(Square))
				{
					return SquarepeDataTemplate;
				}
			}
			
			return UnknownShapeDataTemplate;
		}
	}
}
