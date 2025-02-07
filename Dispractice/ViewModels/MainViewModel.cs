using Avalonia.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dispractice.Models;
using Dispractice.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Dispractice.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private ViewModelBase content;

    
    private NavigationService _navigation;
    public MainViewModel(NavigationService navigation)
    {
        _navigation = navigation;
        NavigateCommand = new RelayCommand<ViewModelBase>(NavigateTo);
        NavigationList = new List<ViewModelBase>()
        {
            _navigation.CreateNavigatable<ServicemanListViewModel>(),
            
        };
        NavigateTo(NavigationList.First());
    }

    ICommand NavigateCommand { get; set; }
    public ICollection<ViewModelBase> NavigationList { get; private set; }
    public void NavigateTo(ViewModelBase page)
    {
        _navigation.NavigateTo(page);
        Content = _navigation.Current;
        OnPropertyChanged(nameof(Content));
    }
}