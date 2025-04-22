using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dispractice.Models;
using Dispractice.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
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
                SelectedUnit = value.Position?.Unit;
                OnPropertyChanged(nameof(IsEditMode));
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

        public bool IsEditMode
        {
            get
            {
                return Serviceman.Id != 0;
            }
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
            }
        }

        public IEnumerable<Rank> Ranks
        {
            get
            {
                return RankData.GetRanks();
            }
        }

        public Rank SelectedRank
        {
            get
            {
                return Serviceman.Rank.GetRank();
            }
            set
            {
                Serviceman.Rank = value.GetRank();
                OnPropertyChanged(nameof(SelectedRank));
            }
        }

        public Task<IEnumerable<Unit>> Units
        {
            get
            {
                return _service.GetMilitaryUnitsList();
            }
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Positions))]
        private Unit? selectedUnit;


        public IEnumerable<Position> Positions
        {
            get
            {
                return SelectedUnit?.GetSubPositions() ?? [];
            }
        }

        public Position? SelectedPosition
        {
            set
            {
                Serviceman.Position = value;
                OnPropertyChanged(nameof(SelectedPosition));
            }
            get
            {
                return Serviceman.Position;
            }
        }

        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        

        public void SaveServiceman()
        {
            _service.AddOrUpdateServicemanAsync(Serviceman);
            _navigation.GoBack();
        }

        public void DeleteServiceman()
        {
            _service.RemoveServicemanAsync(Serviceman);
            _navigation.GoBack(2);
        }
    }
}
