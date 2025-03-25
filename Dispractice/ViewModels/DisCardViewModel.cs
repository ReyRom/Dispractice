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

        public void AddCommendation()
        {
            _navigation.NavigateTo<CommendationViewModel>();
        }
        public void EditCommendation(Commendation commendation)
        {
            _navigation.NavigateTo<CommendationViewModel>(x=>x.Commendation = commendation);
        }
    }
}
