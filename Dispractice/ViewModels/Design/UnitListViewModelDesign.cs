using CommunityToolkit.Mvvm.Input;
using Dispractice.Models;
using System.Collections.ObjectModel;

namespace Dispractice.ViewModels.Design
{
    public class UnitListViewModelDesign : UnitListViewModel
    {
        public UnitListViewModelDesign() : base()
        {
            AddCommand = new RelayCommand<MilitaryUnit>(AddUnit);
            var u0 = new MilitaryUnit()
            {
                Name = "ВЧ",
                Positions = new ObservableCollection<MilitaryPosition>()
                {
                    new MilitaryPosition()
                    {
                        Name="Командир части"
                    }
                },
                SubUnits = new ObservableCollection<MilitaryUnit>()
            };
            var u1 = new MilitaryUnit()
            {
                ParentUnit = u0,
                Name = "Командование",
                SubUnits = new ObservableCollection<MilitaryUnit>()
            };
            u0.SubUnits.Add(u1);
            Units = new ObservableCollection<IMilitaryTreeNode>()
            {
                u0
            };
        }
    }
}
