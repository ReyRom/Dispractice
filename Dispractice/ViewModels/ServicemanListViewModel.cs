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
        readonly NavigationService _navigation = null!;
        readonly IServicemanService _service = null!;

        public ServicemanListViewModel()
        {
            PageName = "Список военнослужащих";
        }

        public ServicemanListViewModel(IServicemanService service, NavigationService navigation): this()
        {
            _navigation = navigation;
            _service = service;

            _navigation.Navigated += _navigation_Navigated;
            
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



        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Filtred))]
        private ObservableCollection<Serviceman> servicemans = new ObservableCollection<Serviceman>();

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

        public IEnumerable<Serviceman> Filtred
        {
            get
            {
                IEnumerable<Serviceman> filtred = Servicemans;

                if (SelectedUnit != null)
                {
                    filtred = filtred.Where(x => x.Position?.Unit == SelectedUnit);
                }

                return filtred.Where(x=>x.LongServicemanString.Contains(SearchString, StringComparison.InvariantCultureIgnoreCase));
            }
        }


        

        [RelayCommand]
        public void OpenServiceman(Serviceman serviceman)
        {
            _navigation.NavigateTo<DisCardViewModel>(async x => await x.LoadServicemanData(serviceman));
        }

        [RelayCommand]
        public void AddServiceman()
        {
            _navigation.NavigateTo<ServicemanViewModel>(x => x.Serviceman = new Serviceman());
        }
    }
}
