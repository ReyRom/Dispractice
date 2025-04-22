using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dispractice.Extensions;
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
    public partial class UnitListViewModel:ViewModelBase
    {
        protected UnitListViewModel()
        {
            PageName = "Список подразделений";
        }

        public ObservableCollection<ITreeNode> Units { get; set; } = [];

        public ICommand AddCommand {  get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand EditCommand { get; set; }

        [ObservableProperty]
        private bool isChanged = false;


        IServicemanService _service;
        NavigationService _navigation;
        public UnitListViewModel(IServicemanService service, NavigationService navigation) : this()
        {
            _service = service;
            _navigation = navigation;
            //Units = new ObservableCollection<IMilitaryTreeNode>(_service.GetMilitaryUnits());
            AddCommand = new RelayCommand<Unit>(AddUnit);
            RemoveCommand = new RelayCommand<Unit>(RemoveUnit, u=>u.ParentUnit!=null);
            SaveCommand = new RelayCommand(SaveData);
            EditCommand = new RelayCommand<Unit>(NavigateToEdit);
        }

        public void AddUnit(Unit? unit)
        {
            var newUnit = new Unit();
            newUnit.ParentUnit = unit;
            unit.SubUnits.Add(newUnit);
            _service.UpdateUnitWithoutSaving(newUnit);
            IsChanged=true;
            OnPropertyChanged(nameof(Units));
        }
        public void RemoveUnit(Unit? unit)
        {
            var parent = unit?.ParentUnit;
            parent.SubUnits.Remove(unit);
            var subunits = unit.SubUnits.ToList();
            foreach (var u in subunits)
            {
                RemoveUnit(u);
            }
            _service.RemoveUnitWithoutSaving(unit);
            IsChanged=true;
            OnPropertyChanged(nameof(Units));
        }
        public void SaveData()
        {
            _service.Save();
            IsChanged=false;
        }

        public void NavigateToEdit(Unit? unit)
        {
            _navigation.NavigateTo<UnitViewModel>((Action<UnitViewModel>?)(x=> x.Unit = unit));
            IsChanged = true;
        }
    }
}
