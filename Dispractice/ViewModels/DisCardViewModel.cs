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

        public async Task LoadServicemanData(Serviceman serviceman)
        {
            Serviceman = await _service.GetServicemanByIdAsync(serviceman.Id)?? new Serviceman();
        }

        public DisCardViewModel()
        {
            PageName = "Служебная карточка";
        }

        private Serviceman serviceman;
        public Serviceman Serviceman
        {
            get => serviceman;
            protected set
            {
                SetProperty(ref serviceman, value);
                OnPropertyChanged(nameof(Commendations));
                OnPropertyChanged(nameof(Penalties));
            }
        }

        public ICollection<Commendation> Commendations => Serviceman.Commendations;
        public ICollection<Penalty> Penalties => Serviceman.Penalties;

        [RelayCommand]
        public void AddCommendation()
        {
            _navigation.NavigateTo<CommendationViewModel>(x => x.Serviceman = Serviceman);
        }

        [RelayCommand]
        public void EditCommendation(Commendation commendation)
        {
            _navigation.NavigateTo<CommendationViewModel>(x => {
                x.Commendation = commendation;
                x.Serviceman = Serviceman;
            });
        }

        [RelayCommand]
        public void AddPenalty()
        {
            _navigation.NavigateTo<PenaltyViewModel>(x => x.Serviceman = Serviceman);
        }

        [RelayCommand]
        public void EditPenalty(Penalty penalty)
        {
            _navigation.NavigateTo<PenaltyViewModel>(x =>
            {
                x.Penalty = penalty;
                x.Serviceman = Serviceman;
            });
        }
    }
}
