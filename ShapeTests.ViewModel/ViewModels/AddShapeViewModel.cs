using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace ShapeTests.ViewModel.ViewModels
{
    using ShapeTest.Business.Entities;
    using ShapeTest.Business.Repositories;

    public class AddShapeViewModel : ViewModel, IPopupViewModel
    {
        private readonly IShapesRepository _ShapeRepo;

        private int _OwnerId;

        private IMvxCommand _AddShapeCommand;
        private IMvxCommand _CancelCommand;

        public bool IsModal => true;

        public bool TopMost => true;

	    public List<Type> ShapeTypes { get; set; }


        public int OwnerId
        {
            get { return _OwnerId;} 
            set { SetAndRaisePropertyChanged(ref _OwnerId, value); }
        }

        public IMvxCommand AddShapeCommand
        {
            get { return _AddShapeCommand; }
            set { SetAndRaisePropertyChanged(ref _AddShapeCommand, value);}
        }

        public IMvxCommand CancelCommand
        {
            get { return _CancelCommand; }
            set { SetAndRaisePropertyChanged(ref _CancelCommand, value);}
        }


        public AddShapeViewModel(IShapesRepository shapeRepo)
        {
            //get all types that implement IShape
            ShapeTypes = ReflectionExtensions.GetTypes(typeof(IShape).GetTypeInfo().Assembly).Where(t => ReflectionExtensions.IsAssignableFrom(typeof(IShape), t) && t != typeof(IShape)).ToList();
            
			_ShapeRepo = shapeRepo;
	        AddShapeCommand = new MvxCommand<Type>(AddShape);
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
