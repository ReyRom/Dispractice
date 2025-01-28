using Dispractice.Models;
using Dispractice.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispractice.ViewModels.Design
{
    public class ServicemanListViewModelDesign : ServicemanListViewModel
    {
        public ServicemanListViewModelDesign()
        {
            Servicemans = new ObservableCollection<Serviceman> 
            { 
                new Serviceman() { Name = "Test1" },
                new Serviceman() { Name = "Test2" },
                new Serviceman() { Name = "Test3" },
            };
        }
    }
}
