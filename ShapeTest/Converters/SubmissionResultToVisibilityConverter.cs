using ShapeTest.Business.Enums;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ShapeTest.Wpf.Converters
{
	public class SubmissionResultToVisibilityConverter:IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			bool invert = parameter != null;
			SubmissionResult result = value as SubmissionResult? ?? SubmissionResult.None;

			return result == SubmissionResult.Success
				? invert ? Visibility.Collapsed : Visibility.Visible
				: result == SubmissionResult.Failure ? invert ? Visibility.Visible : Visibility.Collapsed : Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
