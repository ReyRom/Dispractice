using CommunityToolkit.Mvvm.Input;
using Dispractice.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Dispractice.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    readonly NavigationService _navigation = null!;

    public ViewModelBase Content => _navigation.Current;
    public Dictionary<string, string> NavigationList { get; private set; }
    public HomeViewModel Home { get; set; }

    public bool IsNavBarVisible => Content is not HomeViewModel;

    public MainViewModel(NavigationService navigation)
    {
        Home = App.Services.GetRequiredService<HomeViewModel>();
        _navigation = navigation;
        _navigation.Navigated += _navigation_Navigated; ;

        NavigationList = new Dictionary<string, string>()
        {
            { nameof(ServicemanListViewModel), "Список военнослужащих"},
            { nameof(StructureViewModel), "Штат"}
        };

        _navigation.NavigateTo(Home);
    }

    private void _navigation_Navigated(object? sender, EventArgs e)
    {
        OnPropertyChanged(nameof(Content));
        OnPropertyChanged(nameof(IsNavBarVisible));
        GoBackCommand.NotifyCanExecuteChanged();
    }

    [RelayCommand]
    public void Navigate(string page)
    {
        _navigation.NavigateTo(page);
    }

    [RelayCommand(CanExecute = nameof(CanExecuteGoBack))]
    public void GoBack()
    {
        _navigation.GoBack();
    }
    private bool CanExecuteGoBack() => _navigation.Count > 1;

}