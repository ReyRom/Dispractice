using Avalonia.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dispractice.Models;
using Dispractice.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Dispractice.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public ViewModelBase Content => _navigation.Current;

    private NavigationService _navigation;

    public HomeViewModel Home { get; set; }

    public bool IsNavBarVisible => Content is not HomeViewModel;

    public MainViewModel(NavigationService navigation)
    {
        Home = App.Services.GetRequiredService<HomeViewModel>();
        _navigation = navigation;
        _navigation.Navigated += _navigation_Navigated; ;

        NavigateCommand = new RelayCommand<string>(NavigateTo);

        GoBackCommand = new RelayCommand(() =>
        {
             _navigation.GoBack();
        }, () => _navigation.Count > 1);

        NavigationList = new Dictionary<string,string>()
        {
            { nameof(ServicemanListViewModel), "Список военнослужащих"},
            { nameof(StructureViewModel), "Штат"}
        };
        NavigateTo(nameof(HomeViewModel));
    }

    private void _navigation_Navigated(object? sender, EventArgs e)
    {
        OnPropertyChanged(nameof(Content));
        OnPropertyChanged(nameof(IsNavBarVisible));
        GoBackCommand.NotifyCanExecuteChanged();
    }

    public ICommand NavigateCommand { get; set; }
    public RelayCommand GoBackCommand { get; set; }

    public Dictionary<string, string> NavigationList { get; private set; }
    public void NavigateTo(string page)
    {
        _navigation.NavigateTo(page);
    }
}