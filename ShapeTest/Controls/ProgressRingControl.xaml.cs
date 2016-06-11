using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShapeTest.Wpf.Controls
{
	/// <summary>
	/// Interaction logic for ProgressRingControl.xaml
	/// </summary>
	public partial class ProgressRingControl : UserControl
	{
		public ProgressRingControl()
		{
			InitializeComponent();
		}

		public bool IsActive
		{
			get { return (bool)GetValue(IsActiveProperty); }
			set { SetValue(IsActiveProperty, value); }
		}

		// Using a DependencyProperty as the backing store for IsActive.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty IsActiveProperty =
			DependencyProperty.Register("IsActive", typeof(bool), typeof(ProgressRingControl), new PropertyMetadata(false, OnIsActiveChanged));

		private static void OnIsActiveChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var progressRing = (ProgressRingControl) d;
			bool isActive = (bool) e.NewValue;
			VisualStateManager.GoToState(progressRing, isActive?"Active": "NotActive", false);
		}


		public string Message
		{
			get { return (string)GetValue(MessageProperty); }
			set { SetValue(MessageProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Message.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty MessageProperty =
			DependencyProperty.Register("Message", typeof(string), typeof(ProgressRingControl), new PropertyMetadata(string.Empty, OnMessageChanged));

		private static void OnMessageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			string value = e.NewValue as string;
			var tb = ((ProgressRingControl)d).MessageTb;
			if (string.IsNullOrEmpty(value))
			{
				tb.Visibility = Visibility.Collapsed;
				tb.Text = string.Empty;
			}
			else
			{
				tb.Visibility = Visibility.Visible;
				tb.Text = value;
			}
		}
	}
}
