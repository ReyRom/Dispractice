using CommunityToolkit.Mvvm.ComponentModel;

namespace Dispractice.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private ViewModelBase content = new PenaltyViewModel();
}
