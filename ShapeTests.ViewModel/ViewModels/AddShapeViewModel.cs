using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using ShapeTest.Business.Entities;
using ShapeTest.Business.Repositories;

namespace ShapeTests.ViewModel.ViewModels
{
    public class AddShapeViewModel : ViewModel, IPopupViewModel
    {
        #region Fields

        /// <summary>
        /// Reference to shapes repository
        /// </summary>
        private readonly IShapesRepository _ShapeRepo;

        /// <summary>
        /// Owner id
        /// </summary>
        private int _OwnerId;

        /// <summary>
        /// Command executed whenever user wants to add new shape to list
        /// </summary>
        private ICommand _AddShapeCommand;

        /// <summary>
        /// Command executed when user wants to cancel adding new shape and dismiss the window
        /// </summary>
        private ICommand _CancelCommand;

        #endregion

        #region Properties

        /// <summary>
        /// Contains information is this modal windows
        /// </summary>
        public bool IsModal => true;

        /// <summary>
        /// Contains indormation if this is Top Most 
        /// </summary>
        public bool TopMost => true;

        /// <summary>
        /// List of all types that implements IShape
        /// </summary>
        public List<Type> ShapeTypes { get; set; }

        /// <summary>
        /// Owner id
        /// </summary>
        public int OwnerId
        {
            get { return _OwnerId; }
            set { SetAndRaisePropertyChanged(ref _OwnerId, value); }
        }

        /// <summary>
        /// Command executed whenever user wants to add new shape to list
        /// </summary>
        public ICommand AddShapeCommand
        {
            get { return _AddShapeCommand; }
            set { SetAndRaisePropertyChanged(ref _AddShapeCommand, value); }
        }

        /// <summary>
        /// Command executed when user wants to cancel adding new shape and dismiss the window
        /// </summary>
        public ICommand CancelCommand
        {
            get { return _CancelCommand; }
            set { SetAndRaisePropertyChanged(ref _CancelCommand, value); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="shapeRepo"></param>
        public AddShapeViewModel(IShapesRepository shapeRepo)
        {
            //get all types that implement IShape
            ShapeTypes =
                ReflectionExtensions.GetTypes(typeof(IShape).GetTypeInfo().Assembly)
                    .Where(t => ReflectionExtensions.IsAssignableFrom(typeof(IShape), t) && t != typeof(IShape))
                    .ToList();

            _ShapeRepo = shapeRepo;
            AddShapeCommand = new MvxCommand<Type>(AddShape);
            CancelCommand = new MvxCommand(Cancel);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Handler for AddShapeCommand. It will create instance of new shape and add it to repository
        /// </summary>
        /// <param name="shape"></param>
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


        /// <summary>
        /// Handler for CancelCommand. It will close window.
        /// </summary>
        private void Cancel()
        {
            Close(this);
        }

        #endregion
    }
}
