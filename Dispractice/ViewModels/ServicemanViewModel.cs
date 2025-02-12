using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dispractice.Models;
using Dispractice.Services;
using System;
using System.Windows.Input;

namespace Dispractice.ViewModels
{
    public partial class ServicemanViewModel : ViewModelBase
    {
        [ObservableProperty]
        private Serviceman serviceman = new Serviceman();

        private IServicemanService _service;

        public ServicemanViewModel(IServicemanService service, NavigationService navigation)
        {
            _service = service;
            SaveCommand = new RelayCommand(AddOrUpdateServiceman);
            CancelCommand = new RelayCommand(() => { navigation.GoBack(); });
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

        public Rank[] Ranks
        {
            get
            {
                return IsNaval ? RankData.NavalRanks : RankData.Ranks;
            }
        }

        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public void AddOrUpdateServiceman()
        {
            throw new NotImplementedException();
        }
    }
}
