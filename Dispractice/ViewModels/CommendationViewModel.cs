using CommunityToolkit.Mvvm.ComponentModel;
using Dispractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispractice.ViewModels
{
    public partial class CommendationViewModel:ViewModelBase
    {
        [ObservableProperty]
        private Commendation commendation;

        [ObservableProperty]
        private Serviceman serviceman;

        public IEnumerable<Penalty> NotRemovedPenalties => Serviceman.Penalties.Where(x => x.DateRemoved == null);

        public bool IsRemove => false;
    }
}
