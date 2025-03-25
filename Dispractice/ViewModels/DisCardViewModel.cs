using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dispractice.Models;
using Dispractice.Services;
using Microsoft.EntityFrameworkCore.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Dispractice.ViewModels
{
    public partial class DisCardViewModel : ViewModelBase
    {
        readonly IServicemanService _service;
        readonly NavigationService _navigation;

        public ICommand EditCommand { get; set; }

        public DisCardViewModel(IServicemanService service, NavigationService navigation)
        {
            _service = service;
            _navigation = navigation;

            EditCommand = new RelayCommand<Serviceman>(s => _navigation.NavigateTo<ServicemanViewModel>(p => p.Serviceman = s));
        }

        public DisCardViewModel()
        {
            PageName = "Служебная карточка";
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
