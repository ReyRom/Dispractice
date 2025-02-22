using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispractice.ViewModels.Design
{
    public class UnitViewModelDesign : UnitViewModel
    {
        public UnitViewModelDesign()
        {
            Unit = new Models.MilitaryUnit() { Name = "Воинская часть", ShortName = "ВЧ" };
        }
    }
}
