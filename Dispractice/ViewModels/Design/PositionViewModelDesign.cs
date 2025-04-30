using Dispractice.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace Dispractice.ViewModels.Design
{
    public class PositionViewModelDesign : PositionViewModel
    {
        public PositionViewModelDesign()
        {
            var u1 = new Position()
            {
                Name = "Командир части"
            };
            var u0 = new Unit()
            {
                Name = "ВЧ",
                Positions = new ObservableCollection<Position>()
                {
                    u1
                }
            };
            u1.Unit = u0;
            Position = u1;
        }
    }
}
