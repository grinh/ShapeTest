using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using ShapeTest.Business.Entities;
using ShapeTest.Business.Enums;
using ShapeTest.Business.Repositories;
using ShapeTest.Business.Services;
using ShapeTests.ViewModel.ViewModels;

namespace ShapeTests.ViewModel
{
    public class ShapesViewModel : ViewModel
    {
		/// <summary>
		/// Reference to shapes repository
		/// </summary>
        private readonly IShapesRepository _ShapesRepo;

		/// <summary>
		/// Reference to service that can compute total area of all shapes
		/// </summary>
        private readonly IComputeAreaService _ComputeAreaService;

		/// <summary>
		/// Reference to a service that can submit data
		/// </summary>
        private readonly ISubmissionService _SubmissionService;

		/// <summary>
		/// Contains information if currently any submission is in progress
		/// </summary>
	    private bool _SubmissionInProgress;

		/// <summary>
		/// Constains result of last sumbmission.
		/// </summary>
	    private SubmissionResult _SubmissionResult;

		/// <summary>
		/// Contains list of shapes
		/// </summary>
        private ObservableCollection<IShape> _Shapes;

		/// <summary>
		/// Contains currently selected shape
		/// </summary>
        private IShape _SelectedShape;

		/// <summary>
		/// Computed total area 
		/// </summary>
        private double _TotalArea;

		/// <summary>
		/// Command invoked when user wants to add shape
		/// </summary>
        private ICommand _AddShapeCommand;

		/// <summary>
		/// Command invoked when user wants to remove shape from shapes list
		/// </summary>
        private ICommand _RemoveShapeCommand;

		/// <summary>
		/// Command invoked when user wants to compute total area of all shapes
		/// </summary>
        private ICommand _ComputeAreaCommand;

		/// <summary>
		/// Command invoked when user wants to submit data
		/// </summary>
        private IMvxCommand _SubmitAreaCommand;


		/// <summary>
		/// Class constructor
		/// </summary>
		/// <param name="shapeRepo"></param>
		/// <param name="computeAreaService"></param>
		/// <param name="submissionService"></param>
        public ShapesViewModel(IShapesRepository shapeRepo, 
                               IComputeAreaService computeAreaService,
                               ISubmissionService submissionService)
        {
            _ShapesRepo = shapeRepo;
            _ComputeAreaService = computeAreaService;
            _SubmissionService = submissionService;

            AddShapeCommand = new MvxCommand(AddShape);
            RemoveShapeCommand = new MvxCommand(RemoveSelectedShape);
            ComputeAreaCommand = new MvxCommand(ComputeTotalArea);
            SubmitAreaCommand = new MvxCommand(SubmitArea, CanSubmitArea);
        }

		/// <summary>
		/// "CanExecute" method for SubmitAreaCommand
		/// </summary>
		/// <returns></returns>
		private bool CanSubmitArea()
	    {
		    return !_SubmissionInProgress;
	    }

		/// <summary>
		/// Contains list of shapes
		/// </summary>
	    public ObservableCollection<IShape> Shapes
        {
            get { return _Shapes; }
            set { SetAndRaisePropertyChanged(ref _Shapes, value); }
        }

		/// <summary>
		/// Contains currently selected shape
		/// </summary>
        public IShape SelectedShape
        {
            get { return _SelectedShape; }
            set { SetAndRaisePropertyChanged(ref _SelectedShape, value); }
        }

		/// <summary>
		/// Contains computed total area of all shapes
		/// </summary>
        public double TotalArea
        {
            get { return _TotalArea; }
            set { SetAndRaisePropertyChanged(ref _TotalArea, value); }
        }

		/// <summary>
		/// Command invoked when user wants to add new shape to shapes list
		/// </summary>
        public ICommand AddShapeCommand
        {
            get { return _AddShapeCommand; }
            set { SetAndRaisePropertyChanged(ref _AddShapeCommand, value);}
        }

		/// <summary>
		/// Command invoked when user wants to remove shape from shapes list
		/// </summary>
		public ICommand RemoveShapeCommand
        {
            get { return _RemoveShapeCommand; }
            set { SetAndRaisePropertyChanged(ref _RemoveShapeCommand, value); }
        }

		/// <summary>
		/// Command invoked when user wants to compute total area of all shapes
		/// </summary>
		public ICommand ComputeAreaCommand
        {
            get { return _ComputeAreaCommand; }
            set { SetAndRaisePropertyChanged(ref _ComputeAreaCommand, value); }
        }

		/// <summary>
		/// Command invoked when user wants to submit data
		/// </summary>
		public IMvxCommand SubmitAreaCommand
        {
            get { return _SubmitAreaCommand; }
            set { SetAndRaisePropertyChanged(ref _SubmitAreaCommand, value); }
        }

		/// <summary>
		/// Contains information if currently any submission is in progress
		/// </summary>
		public bool SubmissionInProgress
	    {
		    get
		    {
			    return _SubmissionInProgress;
			}
		    private set
		    {
			    SetAndRaisePropertyChanged(ref _SubmissionInProgress, value);
		    }
		}

		/// <summary>
		/// Constains result of last sumbmission.
		/// </summary>
		public SubmissionResult SubmissionResult
	    {
		    get { return _SubmissionResult; }
		    set { SetAndRaisePropertyChanged(ref _SubmissionResult, value); }
	    }

	    public override void Start()
        {
           Shapes = new ObservableCollection<IShape>(_ShapesRepo.GetShapes());
           SelectedShape = Shapes.FirstOrDefault();

            _ShapesRepo.ShapeAdded += OnShapeAdded;
        }

        /// <summary>
        /// Handler for AddShapeCommand
        /// </summary>
        private void AddShape()
        {
            ShowViewModel<AddShapeViewModel>();
        }

        /// <summary>
        /// Event handler. Invoked whenever new shape is added to shape repository
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnShapeAdded(object sender, ShapeEventArgs args)
        {
            Shapes.Add(args.Shape);
        }


        /// <summary>
        /// Handler for RemoveShapeCommand
        /// </summary>
        private void RemoveSelectedShape()
        {
            if (SelectedShape != null)
            {
                _ShapesRepo.RemoveShape(SelectedShape);
                Shapes.Remove(SelectedShape);
	            SelectedShape = null;
            }
        }

		/// <summary>
		/// Handler for ComputeAreaCommand
		/// </summary>
		private void ComputeTotalArea()
        {
            TotalArea = _ComputeAreaService.ComputeTotalArea();
        }

        /// <summary>
        /// Handler for SubmitAreaCommand. It will try to submit computed area.
        /// </summary>
        private async void SubmitArea()
        {
	        if (SubmissionInProgress)
	        {
		        return;
	        }

			SubmissionResult = SubmissionResult.None;
	        SubmissionInProgress = true;
			SubmitAreaCommand.RaiseCanExecuteChanged();

	        await Task.Run(() =>
	        {
		        try
		        {
					_SubmissionService.SubmitTotalArea(TotalArea);
					SubmissionResult = SubmissionResult.Success;

				}
		        catch (Exception)
		        {
					SubmissionResult = SubmissionResult.Failure;
		        }
		        
		        SubmissionInProgress = false;

				SubmitAreaCommand.RaiseCanExecuteChanged();
	        });
        }
    }
}
