using System;
using ShapeTest.Business.Entities;

namespace ShapeTests.ViewModel.ViewModels
{
    public class TriangleListItemViewModel : ViewModel
    {
        private string _TriangleName;
        private Triangle _Triangle;

        public string TriangleName
        {
            get { return _TriangleName; }
            set { SetAndRaisePropertyChanged(ref _TriangleName, value);}
        }

        public Triangle Triangle
        {
            get { return _Triangle; }
            set { SetAndUpdateTriangleIfChanged(value); }
        }

        private void UpdateViewModel()
        {
            TriangleName = _Triangle.Name;
        }

        private void SetAndUpdateTriangleIfChanged(Triangle newTriangle)
        {
            if (!ReferenceEquals(_Triangle, newTriangle))
            {
                if (_Triangle != null)
                {
                    _Triangle.EntityChanged -= OnTriangleChanged;
                }

                _Triangle = newTriangle;

                if (_Triangle != null)
                {
                    _Triangle.EntityChanged += OnTriangleChanged;
                }

                UpdateViewModel();
            }
        }

        private void OnTriangleChanged(object sender, EventArgs args)
        {
            UpdateViewModel();
        }
    }
}
