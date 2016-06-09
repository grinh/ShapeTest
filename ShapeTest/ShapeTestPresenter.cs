using System;
using System.Collections.Generic;
using System.Windows;
using MvvmCross.Wpf.Views;
using MvvmCross.Core.ViewModels;
using ShapeTest.Wpf.Popup;
using ShapeTests.ViewModel.ViewModels;
using System.Linq;

namespace ShapeTest.Wpf
{
    public class ShapeTestPresenter : MvxSimpleWpfViewPresenter
    {
        private readonly List<PopupWindow> _Popups;

        private Window _MainWindow;
        private bool _IsMainWindowDisabled;

        public ShapeTestPresenter(Window mainWindow)
            : base(mainWindow)
        {
            _MainWindow = mainWindow;
            _Popups = new List<PopupWindow>();
        }

        public override void Present(FrameworkElement frameworkElement)
        {
            var model = frameworkElement.DataContext as IPopupViewModel;
            if (model != null)
            {
                PresentPopup(frameworkElement, model);
            }
            else
            {
                base.Present(frameworkElement);
            }
        }

        public override void ChangePresentation(MvxPresentationHint hint)
        {
            var closeHint = hint as MvxClosePresentationHint;

            IPopupViewModel popupViewModel = closeHint?.ViewModelToClose as IPopupViewModel;

            if (popupViewModel != null)
            {
                ClosePopup(popupViewModel);
                return;
            }

            base.ChangePresentation(hint);
        }

        private void PresentPopup(FrameworkElement frameworkElemenet, IPopupViewModel popupViewModel)
        {
            var popup = new PopupWindow
            {
                Owner = _MainWindow,
                Content = frameworkElemenet,
                DataContext = frameworkElemenet.DataContext,
                Topmost = popupViewModel.TopMost
            };

            if (popupViewModel.IsModal)
            {
                DisableMainContentWindow();
            }

            _Popups.Add(popup);

            foreach (var subPopups in _Popups.Where(p => !p.Equals(popup)))
            {
                subPopups.IsEnabled = false;
            }

            popup.Show();
        }

        private void ClosePopup(IPopupViewModel viewModel)
        {
            PopupWindow popup = _Popups.FirstOrDefault(p => ((FrameworkElement)p.Content).DataContext == viewModel);
            if (popup != null)
            {
                _Popups.Remove(popup);

                if (viewModel.IsModal && _Popups.Count == 0)
                {
                    EnableMainContentWindow();
                }

                if (_Popups.Count > 0)
                {
                    _Popups.Last().IsEnabled = true;
                }

                popup.ForceClose();

                // WORKAROUND: This is here because sometimes when closing a popup,
                // WPF will minimize the MainWindow even after removing it as owner.
                // If there's a better way to avoid this, I'm all ears.
                _MainWindow.Activate();
            }
        }

        private void DisableMainContentWindow()
        {
            if (!_IsMainWindowDisabled)
            {
                _MainWindow.Activated += OnMainWindowActivated;
                _MainWindow.IsEnabled = false;
                _IsMainWindowDisabled = true;
            }
        }

        private void EnableMainContentWindow()
        {
            if (_IsMainWindowDisabled)
            {
                _MainWindow.Activated -= OnMainWindowActivated;
                _MainWindow.IsEnabled = true;
                _IsMainWindowDisabled = false;
            }
        }
        private void OnMainWindowActivated(object sender, EventArgs args)
        {
            if (_Popups.Count > 0)
            {
                _Popups.Last().Focus();
            }
        }
    }
}
