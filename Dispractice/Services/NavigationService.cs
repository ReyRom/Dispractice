using Dispractice.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispractice.Services
{
    public class NavigationService
    {
        Stack<ViewModelBase> _navigationStack = new Stack<ViewModelBase>();

        public ViewModelBase Current => _navigationStack.Peek();
        public int Count => _navigationStack.Count;

        public void NavigateTo<T>(T viewModel) where T : ViewModelBase
        {
            _navigationStack.Push(viewModel);
        }

        public void NavigateTo<T>() where T : ViewModelBase
        {
            var viewModel = App.Services.GetRequiredService<T>();
            _navigationStack.Push(viewModel);
        }

        public void GoBack(int steps = 1)
        {
            for (int i = 0; i < steps; i++)
            {
                _navigationStack.Pop();
            }
        }
    }
}
