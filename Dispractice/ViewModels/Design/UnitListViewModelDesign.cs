using CommunityToolkit.Mvvm.Input;
using Dispractice.Extensions;
using Dispractice.Models;
using Dispractice.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace Dispractice.ViewModels.Design
{
    public class UnitListViewModelDesign : UnitListViewModel
    {
        public UnitListViewModelDesign() : base()
        {
            AddCommand = new RelayCommand<Unit>(AddUnit);
            var u0 = new Unit()
            {
                Name = "ВЧ",
                Positions = new ObservableCollection<Position>()
                {
                    new Position()
                    {
                        Name="Командир части"
                    }
                },
                SubUnits = new ObservableCollection<Unit>()
            };
            var u1 = new Unit()
            {
                ParentUnit = u0,
                Name = "Командование",
                SubUnits = new ObservableCollection<Unit>()
            };
            u0.SubUnits.Add(u1);
            Units = new ObservableCollection<ITreeNode>()
            {
                u0.CreateUnitTreeNode(),
            };
        }
    }
}
