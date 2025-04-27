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
    public partial class CommendationViewModel:ViewModelBase
    {
        NavigationService _navigation;
        IServicemanService _service;

        public CommendationViewModel()
        {
            PageName = "Поощрение";
        }

        public CommendationViewModel(NavigationService navigation, IServicemanService service) : this()
        {
            _navigation = navigation;
            _service = service;
            SaveCommand = new AsyncRelayCommand(Save);
            CancelCommand = new RelayCommand(()=>_navigation.GoBack());
        }
        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(SelectedCommendationType))]
        private Commendation commendation = new Commendation() { DateAwarded = DateTime.Today, Type = CommendationType.Gratitude };

        private Serviceman serviceman = new Serviceman();
        public Serviceman Serviceman
        {
            get => serviceman;
            set
            {
                SetProperty(ref serviceman, value);
                OnPropertyChanged(nameof(NotRemovedPenalties));
                PenaltyToRemove = NotRemovedPenalties.OrderBy(x => x.DateApplied)?.First();
            }
        }

        public IEnumerable<Penalty> NotRemovedPenalties => Serviceman.Penalties.Where(x => x.DateRemoved == null);

        [ObservableProperty]
        private Penalty? penaltyToRemove = null;

        public IEnumerable<CommendationType> CommendationTypes => CommendationRegistry.Info.Select(x=>x.Key);

        public CommendationType SelectedCommendationType
        {
            get => Commendation.Type;
            set
            {
                Commendation.Type = value;
                OnPropertyChanged(nameof(IsRemove));
            }
        }

        public bool IsRemove => Commendation.Type == CommendationType.Removal;


        public async Task Save()
        {
            Commendation.Serviceman = Serviceman;

            await _service.AddOrUpdateCommendationAsync(Commendation);

            if (IsRemove)
            {

            }

            _navigation.GoBack();
        }

        
    }
}
