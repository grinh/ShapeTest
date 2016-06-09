using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;

namespace ShapeTest.Wpf.Controls
{
    public class PopupWindowControl : Window
    {
        public static readonly DependencyProperty CenterWithinOwnerProperty;

        static PopupWindowControl()
        {
            CenterWithinOwnerProperty = DependencyProperty.Register("CenterWithinOwner", typeof(bool), typeof(PopupWindowControl));
        }

        public PopupWindowControl()
        {
            Loaded += OnWindowLoaded;
        }

        public bool CenterWithinOwner
        {
            get { return (bool)GetValue(CenterWithinOwnerProperty); }
            set { SetValue(CenterWithinOwnerProperty, value); }
        }

        protected void OnWindowLoaded(object sender, EventArgs e)
        {
            if (Owner != null)
            {
                Owner.LocationChanged += OnOwnerLocationChanged;
                Owner.SizeChanged += OnOwnerSizeChanged;
                Owner.StateChanged += OnOwnerStateChanged;
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            if (Owner != null)
            {
                Owner.LocationChanged -= OnOwnerLocationChanged;
                Owner.SizeChanged -= OnOwnerSizeChanged;
                Owner.StateChanged -= OnOwnerStateChanged;
            }
        }

        private void OnOwnerLocationChanged(object sender, EventArgs args)
        {
            CenterInsideOwner();
        }

        private void OnOwnerSizeChanged(object sender, EventArgs args)
        {
            CenterInsideOwner();
        }

        private void OnOwnerStateChanged(object sender, EventArgs args)
        {
            CenterInsideOwner();
        }

        private void CenterInsideOwner()
        {
            if (Owner != null && CenterWithinOwner)
            {
                if (Owner.WindowState == WindowState.Normal)
                {
                    Left = Owner.Left + (Owner.Width / 2) - (Width / 2);
                    Top = Owner.Top + (Owner.Height / 2) - (Height / 2);
                }
                else
                {
                    WindowInteropHelper windowHelper = new WindowInteropHelper(Owner);
                    Screen current = Screen.FromHandle(windowHelper.Handle);
                    // ReSharper disable PossibleLossOfFraction
                    Left = current.Bounds.Left + (current.Bounds.Width / 2) - (Width / 2);
                    Top = current.Bounds.Top + (current.Bounds.Height / 2) - (Height / 2);
                    // ReSharper restore PossibleLossOfFraction
                }
            }
        }
    }
}
