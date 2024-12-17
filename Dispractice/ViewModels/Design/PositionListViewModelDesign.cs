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
            var u0 = new MilitaryUnit()
            {
                Name = "ВЧ",
                Positions = new ObservableCollection<MilitaryPosition>()
                {
                    new MilitaryPosition()
                    {
                        Name="Командир части"
                    },
                    new MilitaryPosition()
                    {
                        Name="Командир части"
                    },
                    new MilitaryPosition()
                    {
                        Name="Командир части"
                    },
                    new MilitaryPosition()
                    {
                        Name="Командир части"
                    },
                    new MilitaryPosition()
                    {
                        Name="Командир части"
                    },
                    new MilitaryPosition()
                    {
                        Name="Командир части"
                    },
                    new MilitaryPosition()
                    {
                        Name="Командир части"
                    },
                    new MilitaryPosition()
                    {
                        Name="Командир части"
                    },
                    new MilitaryPosition()
                    {
                        Name="Командир части"
                    },
                    new MilitaryPosition()
                    {
                        Name="Командир части"
                    },
                    new MilitaryPosition()
                    {
                        Name="Командир части"
                    },
                    new MilitaryPosition()
                    {
                        Name="Командир части"
                    },
                    new MilitaryPosition()
                    {
                        Name="Командир части"
                    }

                },
                SubUnits = new ObservableCollection<MilitaryUnit>()
            };
            MilitaryUnit = u0;
        }
    }
}
