using CommunityToolkit.Mvvm.ComponentModel;
using Dispractice.Models;
using Dispractice.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispractice.ViewModels
{
    public partial class DisCardViewModel : ViewModelBase
    {
        readonly ServicemanService _servicemanService;

        public DisCardViewModel(ServicemanService servicemanService)
        {
            this._servicemanService = servicemanService;
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Commendations))]
        [NotifyPropertyChangedFor(nameof(Penalties))]
        private Serviceman serviceman;

        public ICollection<Commendation> Commendations => Serviceman.Commendations;
        public ICollection<Penalty> Penalties => Serviceman.Penalties;

        public bool IsNaval
        {
            get => Serviceman.IsNaval;
            set
            {
                Serviceman.IsNaval = value;
                OnPropertyChanged(nameof(Ranks));
                OnPropertyChanged(nameof(SelectedRank));
            }
        }

        public Rank SelectedRank
        {
            get => Ranks[Serviceman.RankIndex];
            set => Serviceman.RankIndex = value.SeniorityOrder;
        }

        public Rank[] Ranks => IsNaval ? RankData.NavalRanks : RankData.Ranks;
    }
}
