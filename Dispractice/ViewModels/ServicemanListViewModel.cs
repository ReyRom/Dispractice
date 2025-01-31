using CommunityToolkit.Mvvm.ComponentModel;
using Dispractice.Models;
using Dispractice.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispractice.ViewModels
{
    public partial class ServicemanListViewModel:ViewModelBase
    {
        //IServicemanService _service;
        public ServicemanListViewModel()
        {
            //_service = service;

            //Servicemans = new ObservableCollection<Serviceman>(_service.GetServicemenSortedByRank());
        }

        public ObservableCollection<Serviceman> Servicemans { get; set; } = new ObservableCollection<Serviceman>();

        public List<MilitaryUnit> Units { get; set; } = new List<MilitaryUnit>();

        public IEnumerable<Serviceman> Filtred
        {
            get
            {
                IEnumerable<Serviceman> filtred = Servicemans;

                if (SelectedUnit != null)
                {
                    filtred = filtred.Where(x => x.MilitaryPosition.MilitaryUnit == SelectedUnit);
                }

                return filtred.Where(x=>x.LongServicemanString.Contains(SearchString));
            }
        }

        [NotifyPropertyChangedFor(nameof(Filtred))]
        [ObservableProperty]
        private string searchString = String.Empty;

        [NotifyPropertyChangedFor(nameof(Filtred))]
        [ObservableProperty]
        private MilitaryUnit selectedUnit;
    }
}
