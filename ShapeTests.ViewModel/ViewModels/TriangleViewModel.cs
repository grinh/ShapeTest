using System;

namespace ShapeTests.ViewModel.ViewModels
{
    using System.ComponentModel;

    using ShapeTest.Business.Entities;

    public class TriangleViewModel : ViewModel
    {
        private string _Name;
        private double _Base;
        private double _Height;

        private Triangle _Triangle;

        public string Name
        {
            get { return _Name; }
            set { SetAndRaisePropertyChanged(ref _Name, value); }
        }

        public double Base
        {
            get { return _Base; }
            set { SetAndRaisePropertyChanged(ref _Base, value); }
        }

        public double Height
        {
            get { return _Height; }
            set { SetAndRaisePropertyChanged(ref _Height, value); }
        }

        public Triangle Triangle
        {
            get
            {
                return _Triangle;
            }
            set
            {
                SetAndUpdateTraingleIfChanged(value);
            }
        }

        public override void RaisePropertyChanged(PropertyChangedEventArgs changedArgs)
        {
            base.RaisePropertyChanged(changedArgs);
            if (changedArgs.PropertyName == nameof(Name))
            {
                Triangle.Name = Name;
            }
            else if (changedArgs.PropertyName == nameof(Base))
            {
                Triangle.Base = Base;
            }
            else if (changedArgs.PropertyName == nameof(Height))
            {
                Triangle.Height = Height;
            }
        }

        private void SetAndUpdateTraingleIfChanged(Triangle newTriangle)
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

        private void UpdateViewModel()
        {
            Name = _Triangle.Name;
            Base = _Triangle.Base;
            Height = _Triangle.Height;
        }
    }
}
