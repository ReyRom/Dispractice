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


        public ICollection<Unit> Units { get; set; } = new ObservableCollection<Unit>();


        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(SelectedUnitName), nameof(SelectedUnitShortName))]
        private Unit selectedUnit;

        public string SelectedUnitName
        {
            get => SelectedUnit?.Name ?? "";
            set
            {
                if (SelectedUnit != null)
                {
                    SelectedUnit.Name = value;
                    _service.UpdateUnitWithoutSaving(SelectedUnit);
                    IsChanged = true;
                }
            }
        }

        public string SelectedUnitShortName
        {
            get => SelectedUnit?.ShortName ?? "";
            set
            {
                if (SelectedUnit != null)
                {
                    SelectedUnit.ShortName = value;
                    _service.UpdateUnitWithoutSaving(selectedUnit);
                    IsChanged = true;
                }
            }
        }

        #region Commands
        public ICommand AddUnitCommand { get; set; }
        public ICommand AddPositionCommand { get; set; }
        public ICommand RemoveUnitCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand EditPositionCommand { get; set; }
        public ICommand DeletePositionCommand { get; set; }
        public ICommand EditCommand { get; }

        #endregion


        IServicemanService _service;
        NavigationService _navigation;
        public StructureViewModel(IServicemanService service, NavigationService navigation) : this()
        {
            _service = service;
            _navigation = navigation;
            
            AddUnitCommand = new RelayCommand<Unit>(AddUnit);
            RemoveUnitCommand = new RelayCommand<Unit>(RemoveUnit, u => u.ParentUnit != null);
            SaveCommand = new RelayCommand(SaveData);

            AddPositionCommand = new RelayCommand<Unit>(AddPosition, u => u != null);
            EditPositionCommand = new RelayCommand<Position>(NavigateToEditPosition);
            DeletePositionCommand = new RelayCommand<Position>(RemovePosition);

            InitializationTask = LoadUnitsAsync();
        }

        private async Task LoadUnitsAsync()
        {
            Units = [..await _service.GetMilitaryUnits()];
        }

        private void RemovePosition(Position? position)
        {
            var parent = position.Unit;
            if (parent != null)
            {
                parent.Positions.Remove(position);
            }
            _service.RemovePositionWithoutSaving(position);
            IsChanged = true;
        }

        public void AddUnit(Unit? unit)
        {
            var newUnit = new Unit();
            newUnit.ParentUnit = unit;
            unit.SubUnits.Add(newUnit);
            _service.UpdateUnitWithoutSaving(newUnit);
            IsChanged = true;
        }

        public void AddPosition(Unit? unit)
        {
            var newPosition = new Position();
            newPosition.Unit = unit;
            unit.Positions.Add(newPosition);
            _service.UpdatePositionWithoutSaving(newPosition);
            IsChanged = true;
        }
        public void RemoveUnit(Unit? unit)
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

        public void NavigateToEditPosition(Position? position)
        {
            _navigation.NavigateTo<PositionViewModel>(x => { x.Position = position; });
            IsChanged = true;
        }
    }
}
