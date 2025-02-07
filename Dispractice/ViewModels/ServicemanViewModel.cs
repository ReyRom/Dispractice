using CommunityToolkit.Mvvm.ComponentModel;
using Dispractice.Models;

namespace Dispractice.ViewModels
{
    public partial class ServicemanViewModel : ViewModelBase
    {
        [ObservableProperty]
        private Serviceman serviceman;

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
    }
}
