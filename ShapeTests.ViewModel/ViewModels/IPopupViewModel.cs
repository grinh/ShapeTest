namespace ShapeTests.ViewModel.ViewModels
{
    public interface IPopupViewModel
    {
        bool IsModal { get; }
        int OwnerId { get; }
        bool TopMost { get; }
    }
}
