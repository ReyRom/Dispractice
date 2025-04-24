using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dispractice.Extensions;
using Dispractice.Models;
using Dispractice.Services;
using Microsoft.EntityFrameworkCore;
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
        public ServicemanListViewModel()
        {
            PageName = "Список военнослужащих";
        }

        NavigationService _navigation;
        IServicemanService _service;
        public ServicemanListViewModel(IServicemanService service, NavigationService navigation): this()
        {
            _navigation = navigation;
            _service = service;

            _navigation.Navigated += _navigation_Navigated;

            OpenServicemanCommand = new RelayCommand<Serviceman>(OpenServicemanDetails);
            AddServicemanCommand = new RelayCommand(OpenAddServiceman);
            
            InitializationTask = LoadServicemans();
        }

        public async Task LoadServicemans()
        {
            Servicemans = [..await _service.GetServicemenSortedByRankAsync().ToListAsync()];
        }

        private void _navigation_Navigated(object? sender, NavigationEventArgs e)
        {
            if(e.NavigatedTo == this.GetType())
            {
                InitializationTask = LoadServicemans();
            }
        }

        public ICommand OpenServicemanCommand { get; set; }
        public void OpenServicemanDetails(Serviceman serviceman)
        {
            _navigation.NavigateTo<DisCardViewModel>(async x => await x.LoadServicemanData(serviceman));
        }

        public ICommand AddServicemanCommand { get; set; }
        public void OpenAddServiceman()
        {
            _navigation.NavigateTo<ServicemanViewModel>(x => x.Serviceman = new Serviceman());
        }


        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Filtred))]
        private ObservableCollection<Serviceman> servicemans = new ObservableCollection<Serviceman>();


        public IEnumerable<Serviceman> Filtred
        {
            get
            {
                IEnumerable<Serviceman> filtred = Servicemans;

                if (SelectedUnit != null)
                {
                    filtred = filtred.Where((Func<Serviceman, bool>)(x => x.Position?.Unit == SelectedUnit));
                }

                return filtred.Where(x=>x.LongServicemanString.Contains(SearchString, StringComparison.InvariantCultureIgnoreCase));
            }
        }


        [NotifyPropertyChangedFor(nameof(Filtred))]
        [ObservableProperty]
        private string searchString = String.Empty;

        [NotifyPropertyChangedFor(nameof(Filtred))]
        [ObservableProperty]
        private Unit selectedUnit;


        public Task<IEnumerable<Unit>> Units
        {
            get
            {
                return _service.GetMilitaryUnitsList();
            }
        }
    }
}
