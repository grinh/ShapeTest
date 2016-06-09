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
        private readonly ITrianglesRepository _TrianglesRepo;
        private readonly IComputeAreaService _ComputeAreaService;
        private readonly ISubmissionService _SubmissionService;

        private ObservableCollection<TriangleListItemViewModel> _TriangleListItems;

        private TriangleListItemViewModel _SelectedTriangleListItemViewModel;

        private TriangleViewModel _SelectedTriangleContentViewModel;

        private double _TotalArea;

        private MvxCommand _AddTriangleCommand;
        private MvxCommand _RemoveTriangleCommand;
        private MvxCommand _ComputeAreaCommand;
        private MvxCommand _SubmitAreaCommand;

        public ShapesViewModel(ITrianglesRepository triangleRepo, 
                               IComputeAreaService computeAreaService,
                               ISubmissionService submissionService)
        {
            _TrianglesRepo = triangleRepo;
            _ComputeAreaService = computeAreaService;
            _SubmissionService = submissionService;

            _TriangleListItems = new ObservableCollection<TriangleListItemViewModel>();

            AddTriangleCommand = new MvxCommand(AddTriangle);
            RemoveTriangleCommand = new MvxCommand(RemoveSelectedTriangle);
            ComputeAreaCommand = new MvxCommand(ComputeTotalArea);
            SubmitAreaCommand = new MvxCommand(SubmitArea);
        }

        public ObservableCollection<TriangleListItemViewModel> TriangleListItems
        {
            get { return _TriangleListItems; }
            set { SetAndRaisePropertyChanged(ref _TriangleListItems, value); }
        }

        public TriangleListItemViewModel SelectedTriangleListItemViewModel
        {
            get { return _SelectedTriangleListItemViewModel; }
            set { SetAndRaisePropertyChanged(ref _SelectedTriangleListItemViewModel, value); }
        }

        public TriangleViewModel SelectedTriangleContentViewModel
        {
            get { return _SelectedTriangleContentViewModel; }
            set { SetAndRaisePropertyChanged(ref _SelectedTriangleContentViewModel, value); }
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

        public override void RaisePropertyChanged(PropertyChangedEventArgs changedArgs)
        {
            base.RaisePropertyChanged(changedArgs);

            if (changedArgs.PropertyName == nameof(SelectedTriangleListItemViewModel))
            {
                UpdateTriangleContent();
            }
        }

        public override void Start()
        {
           List<Triangle> triangles = _TrianglesRepo.GetTriangles();
           TriangleListItems = CreateListViewModelsFromTriangeList(triangles);
           SelectedTriangleListItemViewModel = TriangleListItems.FirstOrDefault();

            _TrianglesRepo.TriangleAdded += OnTriangleAdded;
        }

        public void AddTriangle()
        {
            ShowViewModel<AddTriangleViewModel>();
        }

        public void OnTriangleAdded(object sender, TriangleEventArgs args)
        {
            TriangleListItemViewModel viewModel = new TriangleListItemViewModel { Triangle = args.Triangle };
            TriangleListItems.Add(viewModel);
        }

        public void RemoveSelectedTriangle()
        {
            if (SelectedTriangleListItemViewModel != null)
            {
                var viewModelToDelete = SelectedTriangleListItemViewModel;
                SelectedTriangleContentViewModel = null;
                _TrianglesRepo.RemoveTriangle(viewModelToDelete.Triangle);
                TriangleListItems.Remove(viewModelToDelete);
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

        private ObservableCollection<TriangleListItemViewModel> CreateListViewModelsFromTriangeList(List<Triangle> triangles)
        {
            ObservableCollection<TriangleListItemViewModel> viewModels = new ObservableCollection<TriangleListItemViewModel>();
            foreach (var triangle in triangles)
            {
                TriangleListItemViewModel viewModel = new TriangleListItemViewModel { Triangle = triangle };
                viewModels.Add(viewModel);
            }
            return viewModels;
        }

        private void UpdateTriangleContent()
        {
            if (SelectedTriangleListItemViewModel != null)
            {
                TriangleViewModel contentViewModel = new TriangleViewModel
                {
                    Triangle = _SelectedTriangleListItemViewModel.Triangle
                };
                SelectedTriangleContentViewModel = contentViewModel;
            }
            else
            {
                SelectedTriangleListItemViewModel = null;
            }
        }
    }
}
