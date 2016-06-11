using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using MvvmCross.Core.ViewModels;
using ShapeTest.Business.Entities;
using ShapeTest.Business.Repositories;
using ShapeTest.Business.Services;
using ShapeTests.ViewModel.ViewModels;

namespace ShapeTests.ViewModel
{
    public class ShapesViewModel : ViewModel
    {
        private readonly IShapesRepository _ShapesRepo;
        private readonly IComputeAreaService _ComputeAreaService;
        private readonly ISubmissionService _SubmissionService;

        private ObservableCollection<IShape> _Shapes;

        private IShape _SelectedShape;

        private double _TotalArea;

        private MvxCommand _AddTriangleCommand;
        private MvxCommand _RemoveTriangleCommand;
        private MvxCommand _ComputeAreaCommand;
        private MvxCommand _SubmitAreaCommand;

        public ShapesViewModel(IShapesRepository shapeRepo, 
                               IComputeAreaService computeAreaService,
                               ISubmissionService submissionService)
        {
            _ShapesRepo = shapeRepo;
            _ComputeAreaService = computeAreaService;
            _SubmissionService = submissionService;

            AddTriangleCommand = new MvxCommand(AddTriangle);
            RemoveTriangleCommand = new MvxCommand(RemoveSelectedTriangle);
            ComputeAreaCommand = new MvxCommand(ComputeTotalArea);
            SubmitAreaCommand = new MvxCommand(SubmitArea);
        }

        public ObservableCollection<IShape> Shapes
        {
            get { return _Shapes; }
            set { SetAndRaisePropertyChanged(ref _Shapes, value); }
        }

        public IShape SelectedShape
        {
            get { return _SelectedShape; }
            set { SetAndRaisePropertyChanged(ref _SelectedShape, value); }
        }

        public double TotalArea
        {
            get { return _TotalArea; }
            set { SetAndRaisePropertyChanged(ref _TotalArea, value); }
        }

        public MvxCommand AddTriangleCommand
        {
            get { return _AddTriangleCommand; }
            set { SetAndRaisePropertyChanged(ref _AddTriangleCommand, value);}
        }

        public MvxCommand RemoveTriangleCommand
        {
            get { return _RemoveTriangleCommand; }
            set { SetAndRaisePropertyChanged(ref _RemoveTriangleCommand, value); }
        }

        public MvxCommand ComputeAreaCommand
        {
            get { return _ComputeAreaCommand; }
            set { SetAndRaisePropertyChanged(ref _ComputeAreaCommand, value); }
        }

        public MvxCommand SubmitAreaCommand
        {
            get { return _SubmitAreaCommand; }
            set { SetAndRaisePropertyChanged(ref _SubmitAreaCommand, value); }
        }

        public override void Start()
        {
           Shapes = new ObservableCollection<IShape>(_ShapesRepo.GetShapes());
           SelectedShape = Shapes.FirstOrDefault();

            _ShapesRepo.ShapeAdded += OnShapeAdded;
        }

        public void AddTriangle()
        {
            ShowViewModel<AddTriangleViewModel>();
        }

        public void OnShapeAdded(object sender, ShapeEventArgs args)
        {
            Shapes.Add(args.Shape);
        }

        public void RemoveSelectedTriangle()
        {
            if (SelectedShape != null)
            {
                _ShapesRepo.RemoveShape(SelectedShape);
                Shapes.Remove(SelectedShape);
	            SelectedShape = null;
            }
        }

        public void ComputeTotalArea()
        {
            TotalArea = _ComputeAreaService.ComputeTotalArea();
        }

        public void SubmitArea()
        {
            _SubmissionService.SubmitTotalArea(TotalArea);
        }
    }
}
