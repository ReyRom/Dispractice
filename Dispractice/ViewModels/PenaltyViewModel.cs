using CommunityToolkit.Mvvm.ComponentModel;
using Dispractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Dispractice.ViewModels
{
    public partial class PenaltyViewModel:ViewModelBase
    {
        [ObservableProperty]
        private Penalty penalty;

        [ObservableProperty]
        private Serviceman serviceman;

        public PenaltyViewModel()
        {
            PageName = "Взыскание";
        }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }
    }
}
