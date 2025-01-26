using CommunityToolkit.Mvvm.ComponentModel;

namespace Dispractice.ViewModels;

public class ViewModelBase : ObservableObject
{
    public string PageName { get; set; }
}
