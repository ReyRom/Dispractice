using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dispractice.Models;
using Dispractice.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Dispractice.ViewModels
{
    public partial class CommendationViewModel:ViewModelBase
    {
        NavigationService _navigation = null!;
        IServicemanService _service = null!;


        public CommendationViewModel()
        {
            PageName = "Поощрение";
        }

        public CommendationViewModel(NavigationService navigation, IServicemanService service) : this()
        {
            _navigation = navigation;
            _service = service;
        }




        private Serviceman serviceman = new Serviceman();
        public Serviceman Serviceman
        {
            get => serviceman;
            set
            {
                SetProperty(ref serviceman, value);
                OnPropertyChanged(nameof(NotRemovedPenalties));
                PenaltyToRemove = NotRemovedPenalties.OrderBy(x => x.DateApplied).FirstOrDefault();
            }
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(SelectedCommendationType))]
        private Commendation commendation = new Commendation() { DateAwarded = DateTime.Today, Type = CommendationType.Gratitude };

        [ObservableProperty]
        private Penalty? penaltyToRemove = null;

        public CommendationType SelectedCommendationType
        {
            get => Commendation.Type;
            set
            {
                Commendation.Type = value;
                OnPropertyChanged(nameof(IsRemove));
                OnPropertyChanged(nameof(SelectedCommendationType));
            }
        }
        public bool IsRemove => Commendation.Type == CommendationType.Removal;

        public IEnumerable<Penalty> NotRemovedPenalties => Serviceman.Penalties.Where(x => x.DateRemoved == null);
        public IEnumerable<CommendationType> CommendationTypes => CommendationRegistry.Info.Select(x=>x.Key);
        



        [RelayCommand]
        public async Task Save()
        {
            Commendation.Serviceman = Serviceman;

            await _service.AddOrUpdateCommendationAsync(Commendation);

            if (IsRemove)
            {
                PenaltyToRemove.Commendation = Commendation;
                PenaltyToRemove.DateRemoved = Commendation.DateAwarded;

                await _service.AddOrUpdatePenaltyAsync(PenaltyToRemove);
            }

            _navigation.GoBack();
        }

        [RelayCommand]
        public void Cancel()
        {
            _navigation.GoBack();
        }
    }
}
