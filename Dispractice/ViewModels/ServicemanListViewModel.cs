using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dispractice.Models;
using Dispractice.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Dispractice.ViewModels
{
    public partial class ServicemanListViewModel:ViewModelBase
    {

        NavigationService _navigation;
        //IServicemanService _service;
        public ServicemanListViewModel(NavigationService navigation)
        {
            PageName = "Список военнослужащих";

            _navigation = navigation;

            OpenServicemanCommand = new RelayCommand<Serviceman>(OpenServicemanDetails);
            //_service = service;

            //Servicemans = new ObservableCollection<Serviceman>(_service.GetServicemenSortedByRank());
        }

        public ICommand OpenServicemanCommand { get; set; }
        public void OpenServicemanDetails(Serviceman serviceman)
        {
            _navigation.NavigateTo<ServicemanViewModel>(x=>x.Serviceman = serviceman);
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

                return filtred.Where(x=>x.LongServicemanString.Contains(SearchString, StringComparison.InvariantCultureIgnoreCase));
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
