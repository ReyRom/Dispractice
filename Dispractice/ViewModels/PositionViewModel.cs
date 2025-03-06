using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dispractice.Models;
using Dispractice.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Dispractice.ViewModels
{
    public partial class PositionViewModel:ViewModelBase
    {
        [ObservableProperty]
        private MilitaryPosition position;

        public PositionViewModel()
        {
            PageName = "Должность";
        }

        public PositionViewModel(NavigationService navigation)
        {
            OkCommand = new RelayCommand(() => { navigation.GoBack(); });
        }

        public ICommand OkCommand { get; private set; }
    }
}
