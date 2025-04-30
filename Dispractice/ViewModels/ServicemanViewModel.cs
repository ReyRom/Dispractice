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
        readonly IServicemanService _service = null!;
        readonly NavigationService _navigation = null!;

        public ServicemanViewModel(IServicemanService service, NavigationService navigation)
        {
            _service = service;
            _navigation = navigation;
        }


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

        public bool IsEditMode => Serviceman.Id != 0;

        public bool IsNaval
        {
            get => Serviceman.IsNaval;
            set
            {
                Serviceman.IsNaval = value;
                OnPropertyChanged(nameof(IsNaval));
            }
        }

        public IEnumerable<Rank> Ranks => RankData.GetRanks();

        public Rank SelectedRank
        {
            get => Serviceman.Rank.GetRank();
            set
            {
                Serviceman.Rank = value.GetRank();
                OnPropertyChanged(nameof(SelectedRank));
            }
        }

        public Task<IEnumerable<Unit>> Units => _service.GetMilitaryUnitsList();

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Positions))]
        private Unit? selectedUnit;


        public IEnumerable<Position> Positions => SelectedUnit?.GetSubPositions() ?? [];

        public Position? SelectedPosition
        {
            get => Serviceman.Position;
            set
            {
                Serviceman.Position = value;
                OnPropertyChanged(nameof(SelectedPosition));
            }
        }



        [RelayCommand]
        public async Task Save()
        {
            await _service.AddOrUpdateServicemanAsync(Serviceman);
            _navigation.GoBack();
        }

        [RelayCommand]
        public void Delete()
        {
            _service.RemoveServicemanAsync(Serviceman);
            _navigation.GoBack(2);
        }

        [RelayCommand]
        public void Cancel()
        {
            _navigation.GoBack();
        }
    }
}
