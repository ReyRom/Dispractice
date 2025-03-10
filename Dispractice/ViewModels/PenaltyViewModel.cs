﻿using CommunityToolkit.Mvvm.ComponentModel;
using Dispractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
