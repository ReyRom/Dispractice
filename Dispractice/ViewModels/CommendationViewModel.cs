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
        private Commendation commendation = new Commendation() { DateAwarded = DateTime.Now, Type = CommendationType.Gratitude };

        [ObservableProperty]
        private Serviceman serviceman = new Serviceman();
       
        public IEnumerable<Penalty> NotRemovedPenalties => Serviceman.Penalties.Where(x => x.DateRemoved == null);

        public Dictionary<CommendationType, string> CommendationTypes => CommendationRegistry.Info;

        public KeyValuePair<CommendationType, string> SelectedCommendationType
        {
            get => new KeyValuePair<CommendationType, string>(Commendation.Type, Commendation.Type.GetDescription());
            set
            {
                Commendation.Type = value.Key;
                OnPropertyChanged(nameof(IsRemove));
            }
        }

        public bool IsRemove => Commendation.Type == CommendationType.Removal;


        public async Task Save()
        {
            Commendation.Serviceman = Serviceman;

            await _service.AddOrUpdateCommendationAsync(Commendation);

            _navigation.GoBack();
        }

        
    }
}
