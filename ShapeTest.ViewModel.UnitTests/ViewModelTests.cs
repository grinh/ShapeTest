using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.WeakSubscription;

namespace ShapeTest.ViewModel.UnitTests
{
    [TestClass]
    public class ViewModelTests
    {
        class TestViewModel:ShapeTests.ViewModel.ViewModel
        {
            public TestViewModel()
            {
                RaisePropertyChangedRaised = false;
                PropertyName = null;
            }

            public bool RaisePropertyChangedRaised { get; private set; }
            public string PropertyName { get; private set; }

            public override void RaisePropertyChanged(PropertyChangedEventArgs changedArgs)
            {
                base.RaisePropertyChanged(changedArgs);
                RaisePropertyChangedRaised = true;
                PropertyName = changedArgs.PropertyName;
            }
        }

        [TestMethod]
        public void ShouldSetAndRaisePropertyChange()
        {
            const int expectedValue = 1;
            const string propertyName = "someProperty";
            int field = 0;

            var viewModel = new TestViewModel();
            
            viewModel.SetAndRaisePropertyChanged(ref field, 1, propertyName);

            field.Should().Be(expectedValue);

            viewModel.RaisePropertyChangedRaised.Should().Be(true);
            viewModel.PropertyName.Should().Be(propertyName);
        }

        [TestMethod]
        public void ShouldNotSetAndNotRaisePropertyChange()
        {
            const int expectedValue = 0;
            const string propertyName = "someProperty";
            int field = 0;

            var viewModel = new TestViewModel();

            viewModel.SetAndRaisePropertyChanged(ref field, 0, propertyName);

            field.Should().Be(expectedValue);

            viewModel.RaisePropertyChangedRaised.Should().Be(false);
        }

        [TestMethod]
        public void ShouldNotSetAndNotRaisePropertyChangeWhenThereIsNoCaller()
        {
            const int expectedValue = 0;
            const string propertyName = "someProperty";
            int field = 0;

            var viewModel = new TestViewModel();

            viewModel.SetAndRaisePropertyChanged(ref field, 1, null);

            field.Should().Be(expectedValue);

            viewModel.RaisePropertyChangedRaised.Should().Be(false);
        }
    }
}
