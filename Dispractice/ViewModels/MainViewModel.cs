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
    public ViewModelBase Content => _navigation.Current;

    
    private NavigationService _navigation;
    public MainViewModel(NavigationService navigation)
    {
        _navigation = navigation;
        _navigation.Navigated += _navigation_Navigated; ;

        NavigateCommand = new RelayCommand<ViewModelBase>(NavigateTo);
        NavigationList = new List<ViewModelBase>()
        {
            _navigation.CreateNavigatable<ServicemanListViewModel>(),
            _navigation.CreateNavigatable<UnitListViewModel>(),
        };
        NavigateTo(NavigationList.First());
    }

    private void _navigation_Navigated(object? sender, EventArgs e)
    {
        OnPropertyChanged(nameof(Content));
    }

    ICommand NavigateCommand { get; set; }
    public ICollection<ViewModelBase> NavigationList { get; private set; }
    public void NavigateTo(ViewModelBase page)
    {
        _navigation.NavigateTo(page);
    }
}