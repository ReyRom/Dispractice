using CommunityToolkit.Mvvm.ComponentModel;
using Dispractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispractice.ViewModels
{
    public partial class PositionViewModel:ViewModelBase
    {
        [ObservableProperty]
        private MilitaryPosition position;

        [ObservableProperty]
        private bool isEditMode;
    }
}
