using Dispractice.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace Dispractice.ViewModels.Design
{
    public class PositionViewModelDesign : PositionViewModel
    {
        public PositionViewModelDesign()
        {
            var u1 = new MilitaryPosition()
            {
                Name = "Командир части"
            };
            var u0 = new MilitaryUnit()
            {
                Name = "ВЧ",
                Positions = new ObservableCollection<MilitaryPosition>()
                {
                    u1
                }
            };
            u1.MilitaryUnit = u0;
            Position = u1;
        }
    }
}
