using Dispractice.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispractice.ViewModels.Design
{
    public class PositionListViewModelDesign : PositionListViewModel
    {
        public PositionListViewModelDesign()
        {
            var u0 = new Unit()
            {
                Name = "ВЧ",
                Positions = new ObservableCollection<Position>()
                {
                    new Position()
                    {
                        Name="Командир части"
                    },
                    new Position()
                    {
                        Name="Командир части"
                    },
                    new Position()
                    {
                        Name="Командир части"
                    },
                    new Position()
                    {
                        Name="Командир части"
                    },
                    new Position()
                    {
                        Name="Командир части"
                    },
                    new Position()
                    {
                        Name="Командир части"
                    },
                    new Position()
                    {
                        Name="Командир части"
                    },
                    new Position()
                    {
                        Name="Командир части"
                    },
                    new Position()
                    {
                        Name="Командир части"
                    },
                    new Position()
                    {
                        Name="Командир части"
                    },
                    new Position()
                    {
                        Name="Командир части"
                    },
                    new Position()
                    {
                        Name="Командир части"
                    },
                    new Position()
                    {
                        Name="Командир части"
                    }

                },
                SubUnits = new ObservableCollection<Unit>()
            };
            MilitaryUnit = u0;
            IsEditMode = true;
        }
    }
}
