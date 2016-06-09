using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MvvmCross.Core.ViewModels;

namespace ShapeTests.ViewModel
{
    public class ViewModel : MvxViewModel
    {
        public void SetAndRaisePropertyChanged<T>(ref T backingField, T newValue, [CallerMemberName] string memberName = "")
        {
            if (string.IsNullOrEmpty(memberName))
            {
                return;
            }

            if (EqualityComparer<T>.Default.Equals(backingField, newValue))
            {
                return;
            }

            backingField = newValue;
            RaisePropertyChanged(memberName);
        }
    }
}
