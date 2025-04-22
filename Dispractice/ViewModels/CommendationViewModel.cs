using CommunityToolkit.Mvvm.ComponentModel;
using Dispractice.Models;
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
        [ObservableProperty]
        private Commendation commendation = new Commendation();

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


        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }
    }
}
