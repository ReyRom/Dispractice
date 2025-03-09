using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dispractice.Models;
using Dispractice.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Dispractice.ViewModels
{
    public partial class ServicemanViewModel : ViewModelBase
    {
        private Serviceman serviceman = new Serviceman();
        public Serviceman Serviceman
        {
            get => serviceman;
            set
            {
                SetProperty(ref serviceman, value);
                SelectedUnit = value.MilitaryPosition?.MilitaryUnit;
                OnPropertyChanged(nameof(Units));
            }
        }

        private IServicemanService _service;
        private NavigationService _navigation;
        public ServicemanViewModel(IServicemanService service, NavigationService navigation)
        {
            _service = service;
            _navigation = navigation;
            SaveCommand = new RelayCommand(SaveServiceman);
            CancelCommand = new RelayCommand(() => { _navigation.GoBack(); });
            DeleteCommand = new RelayCommand(DeleteServiceman);
        }

        public bool IsNaval
        {
            get
            {
                return Serviceman.IsNaval;
            }
            set
            {
                Serviceman.IsNaval = value;
                OnPropertyChanged(nameof(IsNaval));
                OnPropertyChanged(nameof(Ranks));
            }
        }

        public IEnumerable<Rank> Ranks
        {
            get
            {
                return IsNaval ? RankData.NavalRanks : RankData.Ranks;
            }
        }

        public IEnumerable<MilitaryUnit> Units
        {
            get
            {
                return _service.GetMilitaryUnitsList();
            }
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Positions))]
        private MilitaryUnit? selectedUnit;


        public IEnumerable<MilitaryPosition> Positions
        {
            get
            {
                return SelectedUnit?.GetSubPositions() ?? [];
            }
        }

        public MilitaryPosition? SelectedPosition
        {
            set
            {
                Serviceman.MilitaryPosition = value;
                OnPropertyChanged(nameof(SelectedPosition));
            }
            get
            {
                return Serviceman.MilitaryPosition;
            }
        }

        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        

        public void SaveServiceman()
        {
            _service.AddOrUpdateServiceman(Serviceman);
            _navigation.GoBack();
        }

        public void DeleteServiceman()
        {
            _service.RemoveServiceman(Serviceman);
            _navigation.GoBack();
        }
    }
}
