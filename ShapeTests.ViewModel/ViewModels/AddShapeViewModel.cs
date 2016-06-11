using System;
using System.Collections.Generic;
using MvvmCross.Core.ViewModels;

namespace ShapeTests.ViewModel.ViewModels
{
    using ShapeTest.Business.Entities;
    using ShapeTest.Business.Repositories;

    public class AddShapeViewModel : ViewModel, IPopupViewModel
    {
        private readonly IShapesRepository _ShapeRepo;

        private int _OwnerId;

        private IMvxCommand _AddTriangleCommand;
        private IMvxCommand _CancelCommand;

        public bool IsModal => true;

        public bool TopMost => true;

	    public List<Type> ShapeTypes { get; set; }


        public int OwnerId
        {
            get { return _OwnerId;} 
            set { SetAndRaisePropertyChanged(ref _OwnerId, value); }
        }

        public IMvxCommand AddTriangleCommand
        {
            get { return _AddTriangleCommand; }
            set { SetAndRaisePropertyChanged(ref _AddTriangleCommand, value);}
        }

        public IMvxCommand CancelCommand
        {
            get { return _CancelCommand; }
            set { SetAndRaisePropertyChanged(ref _CancelCommand, value);}
        }


        public AddShapeViewModel(IShapesRepository shapeRepo)
        {
			ShapeTypes = new List<Type> { typeof(Triangle), typeof(Circle), typeof(Square), typeof(Rectangle) };
			_ShapeRepo = shapeRepo;
	        AddTriangleCommand = new MvxCommand<Type>(AddShape);
            CancelCommand = new MvxCommand(Cancel);
        }

	    private void AddShape(Type shape)
	    {
			IShape newShape = Activator.CreateInstance(shape) as IShape;

		    if (newShape != null)
		    {
			    newShape.Name = "New Shape";
				_ShapeRepo.AddShape(newShape);
		    }

			Close(this);
		}

        public void Cancel()
        {
            Close(this);
        }
    }
}
