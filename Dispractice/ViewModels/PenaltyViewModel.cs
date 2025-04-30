using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dispractice.Models;
using Dispractice.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Dispractice.ViewModels
{
    public partial class PenaltyViewModel : ViewModelBase
    {
        readonly NavigationService _navigation = null!;
        readonly IServicemanService _service = null!;

        public PenaltyViewModel()
        {
            PageName = "Взыскание";
        }
        public PenaltyViewModel(NavigationService navigation, IServicemanService service) : this()
        {
            _navigation = navigation;
            _service = service;
        }



        [ObservableProperty]
        private Penalty penalty = new Penalty() { DateApplied = DateTime.Today, DateExecuted = DateTime.Today, OffenseDate = DateTime.Today, Type = PenaltyType.Reprimand };

        [ObservableProperty]
        private Serviceman serviceman;

        public IEnumerable<PenaltyType> PenaltyTypes => PenaltyRegistry.Info.Select(x => x.Key);

        public PenaltyType SelectedPenaltyType
        {
            get => Penalty.Type;
            set
            {
                Penalty.Type = value;
                OnPropertyChanged(nameof(SelectedPenaltyType));
            }
        }



        [RelayCommand]
        public async Task Save()
        {
            Penalty.Serviceman = Serviceman;

            await _service.AddOrUpdatePenaltyAsync(Penalty);

            _navigation.GoBack();
        }

        [RelayCommand]
        public void Cancel()
        {
            _navigation.GoBack();
        }
    }
}
