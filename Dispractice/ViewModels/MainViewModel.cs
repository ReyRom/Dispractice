using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dispractice.Models;
using System.Collections.Generic;
using System.Windows.Input;

namespace Dispractice.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private ViewModelBase content = new PenaltyViewModel();

    ICommand NavigateCommand { get; set; }
    
    public MainViewModel()
    {
        NavigateCommand = new RelayCommand<ViewModelBase>(NavigateTo);
    }

    public ICollection<ViewModelBase> NavigationList { get; } = [new PenaltyViewModel()];

    public void NavigateTo(ViewModelBase? page)
    {
        Content = page;
    }
}