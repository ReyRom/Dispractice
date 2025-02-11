using Dispractice.Models;
using Dispractice.Services;
using Microsoft.Extensions.DependencyInjection;
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
        public ServicemanListViewModelDesign():base(App.Services.GetService<NavigationService>())
        {
            Servicemans = new ObservableCollection<Serviceman> 
            { 
                new Serviceman() { Name = "Test1", Surname = "qwe", Patronomic="asd", IsNaval = false, RankIndex=0 },
                new Serviceman() { Name = "Test2", IsNaval = false, RankIndex=0 },
                new Serviceman() { Name = "Test3", IsNaval = false, RankIndex=0 },
            };
        }
    }
}
