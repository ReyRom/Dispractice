using CommunityToolkit.Mvvm.ComponentModel;
using System.Threading.Tasks;

namespace Dispractice.ViewModels;

public class ViewModelBase : ObservableObject
{
    public string PageName { get; set; }


    TaskNotifier? _initializationTask;
    public Task? InitializationTask
    {
        get => _initializationTask;
        set => SetPropertyAndNotifyOnCompletion(ref _initializationTask, value);
    }
}
