using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dispractice.Models;
using Dispractice.Services;
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
        private Penalty penalty = new Penalty() { DateApplied = DateTime.Today, Type = PenaltyType.Reprimand };

        [ObservableProperty]
        private Serviceman serviceman;

        public PenaltyViewModel()
        {
            PageName = "Взыскание";
        }

        NavigationService _navigation;
        IServicemanService _service;

        public PenaltyViewModel(NavigationService navigation, IServicemanService service) : this()
        {
            _navigation = navigation;
            _service = service;
            SaveCommand = new AsyncRelayCommand(Save);
            CancelCommand = new RelayCommand(() => _navigation.GoBack());
        }

        private async Task Save()
        {
            Penalty.Serviceman = Serviceman;

            await _service.AddOrUpdatePenaltyAsync(Penalty);

            _navigation.GoBack();
        }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public Dictionary<PenaltyType, string> PenaltyTypes => PenaltyRegistry.Info;

        public KeyValuePair<PenaltyType, string> SelectedPenaltyType
        {
            get => new KeyValuePair<PenaltyType, string>(Penalty.Type, Penalty.Type.GetDescription());
            set
            {
                Penalty.Type = value.Key;
                OnPropertyChanged(nameof(SelectedPenaltyType));
            }
        }
    }
}
