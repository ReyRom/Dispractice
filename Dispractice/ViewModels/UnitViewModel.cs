using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dispractice.Models;
using Dispractice.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Dispractice.ViewModels
{
    public partial class UnitViewModel: ViewModelBase
    {
        protected UnitViewModel() 
        {

        }

        public ICommand OkCommand { get; set; }


        [ObservableProperty]
        private MilitaryUnit unit;

        private IServicemanService _service;
        private NavigationService _navigation;

        public UnitViewModel(IServicemanService service, NavigationService navigation) : this()
        {
            _service = service;
            _navigation = navigation;

            OkCommand = new RelayCommand(GoBack);
        }
        
        public void GoBack()
        {
            _navigation.GoBack();
        }

    }
}
