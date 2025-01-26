using CommunityToolkit.Mvvm.Input;
using Dispractice.Models;
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
        public ObservableCollection<IMilitaryTreeNode> Units { get; set; } = new ObservableCollection<IMilitaryTreeNode>();

        public ICommand AddCommand {  get; set; }
        public ICommand RemoveCommand { get; set; }

        public UnitListViewModel()
        {
            AddCommand = new RelayCommand<MilitaryUnit>(AddUnit);
            RemoveCommand = new RelayCommand<MilitaryUnit>(RemoveUnit, u=>u.ParentUnit!=null);
        }

        public void AddUnit(MilitaryUnit? unit)
        {
            var newUnit = new MilitaryUnit();
            newUnit.ParentUnit = unit;
            newUnit.SubUnits = new ObservableCollection<MilitaryUnit>();
            unit.SubUnits.Add(newUnit);
        }
        public void RemoveUnit(MilitaryUnit? unit)
        {
            var parent = unit.ParentUnit;
            if (parent != null)
            {
                parent.SubUnits.Remove(unit);
            }
        }
        public void RemovePosition(MilitaryUnit? unit)
        {
            var parent = unit.ParentUnit;
            if (parent != null)
            {
                parent.SubUnits.Remove(unit);
            }
        }
    }
}
