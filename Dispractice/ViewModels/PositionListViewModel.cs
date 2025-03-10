﻿using CommunityToolkit.Mvvm.ComponentModel;
using Dispractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispractice.ViewModels
{
    public partial class PositionListViewModel:ViewModelBase
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Positions))]
        private MilitaryUnit militaryUnit;

        [ObservableProperty]
        private bool isEditMode;

        public ICollection<MilitaryPosition> Positions => militaryUnit.Positions;
    }
}
