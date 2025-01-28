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
    public class ServicemanListViewModel:ViewModelBase
    {
        //IServicemanService _service;
        public ServicemanListViewModel()
        {
            //_service = service;

            //Servicemans = new ObservableCollection<Serviceman>(_service.GetServicemenSortedByRank());
        }

        public ObservableCollection<Serviceman> Servicemans { get; set; } = new ObservableCollection<Serviceman>();
    }
}
