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
    public partial class StructureViewModel: ViewModelBase
    {
        protected StructureViewModel()
        {
            PageName = "Список подразделений";
        }
        

        [ObservableProperty]
        private bool isEditMode;
        [ObservableProperty]
        private bool isChanged = false;


        public ICollection<IMilitaryTreeNode> Units { get; set; } = new ObservableCollection<IMilitaryTreeNode>();
        [ObservableProperty]
        private MilitaryUnit selectedUnit;

        #region Commands
        public ICommand AddUnitCommand { get; set; }
        public ICommand AddPositionCommand { get; set; }
        public ICommand RemoveUnitCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand EditCommand { get; set; }
        #endregion


        IServicemanService _service;
        NavigationService _navigation;
        public StructureViewModel(IServicemanService service, NavigationService navigation) : this()
        {
            _service = service;
            _navigation = navigation;
            Units = new ObservableCollection<IMilitaryTreeNode>(_service.GetMilitaryUnits());
            AddUnitCommand = new RelayCommand<MilitaryUnit>(AddUnit);
            RemoveUnitCommand = new RelayCommand<MilitaryUnit>(RemoveUnit, u => u.ParentUnit != null);
            SaveCommand = new RelayCommand(SaveData);

            AddPositionCommand = new RelayCommand<MilitaryUnit>(AddPosition, u => u != null);
            //EditCommand = new RelayCommand<MilitaryUnit>(NavigateToEdit);
        }

        public void AddUnit(MilitaryUnit? unit)
        {
            var newUnit = new MilitaryUnit();
            newUnit.ParentUnit = unit;
            unit.SubUnits.Add(newUnit);
            _service.UpdateUnitWithoutSaving(newUnit);
            IsChanged = true;
        }

        public void AddPosition(MilitaryUnit? unit)
        {
            var newPosition = new MilitaryPosition();
            newPosition.MilitaryUnit = unit;
            unit.Positions.Add(newPosition);
            _service.UpdatePositionWithoutSaving(newPosition);
            IsChanged = true;
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
            IsChanged = true;
        }
        public void SaveData()
        {
            _service.Save();
            IsChanged = false;
        }

        public void NavigateToEdit(MilitaryUnit? unit)
        {
            _navigation.NavigateTo<UnitViewModel>(x => x.Unit = unit);
            IsChanged = true;
        }
    }
}
