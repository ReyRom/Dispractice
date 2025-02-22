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
    public partial class UnitListViewModel:ViewModelBase
    {
        protected UnitListViewModel()
        {
            PageName = "Список подразделений";
        }

        public ObservableCollection<IMilitaryTreeNode> Units { get; set; } = new ObservableCollection<IMilitaryTreeNode>();

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
            Units = new ObservableCollection<IMilitaryTreeNode>(_service.GetMilitaryUnits());
            AddCommand = new RelayCommand<MilitaryUnit>(AddUnit);
            RemoveCommand = new RelayCommand<MilitaryUnit>(RemoveUnit, u=>u.ParentUnit!=null);
            SaveCommand = new RelayCommand(SaveData);
            EditCommand = new RelayCommand<MilitaryUnit>(NavigateToEdit);
        }

        public void AddUnit(MilitaryUnit? unit)
        {
            var newUnit = new MilitaryUnit();
            newUnit.ParentUnit = unit;
            unit.SubUnits.Add(newUnit);
            _service.UpdateUnitWithoutSaving(newUnit);
            IsChanged=true;
            OnPropertyChanged(nameof(Units));
        }
        public void RemoveUnit(MilitaryUnit? unit)
        {
            var parent = unit.ParentUnit;
            if (parent != null)
            {
                parent.SubUnits.Remove(unit);
            }
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

        public void NavigateToEdit(MilitaryUnit? unit)
        {
            _navigation.NavigateTo<UnitViewModel>(x=>x.Unit = unit);
            IsChanged = true;
        }
    }
}
