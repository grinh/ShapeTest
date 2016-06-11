using MvvmCross.Core.ViewModels;

namespace ShapeTests.ViewModel.ViewModels
{
    using ShapeTest.Business.Entities;
    using ShapeTest.Business.Repositories;

    public class AddTriangleViewModel : ViewModel, IPopupViewModel
    {
        private readonly IShapesRepository _ShapeRepo;

        private int _OwnerId;

        private MvxCommand _AddTriangleCommand;
        private MvxCommand _CancelCommand;

        public bool IsModal => true;

        public bool TopMost => true;

        public int OwnerId
        {
            get { return _OwnerId;} 
            set { SetAndRaisePropertyChanged(ref _OwnerId, value); }
        }

        public MvxCommand AddTriangleCommand
        {
            get { return _AddTriangleCommand; }
            set { SetAndRaisePropertyChanged(ref _AddTriangleCommand, value);}
        }

        public MvxCommand CancelCommand
        {
            get { return _CancelCommand; }
            set { SetAndRaisePropertyChanged(ref _CancelCommand, value);}
        }


        public AddTriangleViewModel(IShapesRepository shapeRepo)
        {
            _ShapeRepo = shapeRepo;
            AddTriangleCommand = new MvxCommand(AddTriangle);
            CancelCommand = new MvxCommand(Cancel);
        }

        public void AddTriangle()
        {
            Triangle triangle = new Triangle
            {
                Name = "New Triangle"                            
            };

            _ShapeRepo.AddShape(triangle);
            Close(this);
        }

        public void Cancel()
        {
            Close(this);
        }
    }
}
