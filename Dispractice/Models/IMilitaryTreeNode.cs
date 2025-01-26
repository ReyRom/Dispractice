using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispractice.Models
{
    public interface IMilitaryTreeNode
    {
        IMilitaryTreeNode Element { get; }
        IEnumerable<IMilitaryTreeNode> SubElements { get; }
    }
}
