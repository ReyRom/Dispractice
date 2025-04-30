using Dispractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispractice.Extensions
{
    public static class ModelExtensions
    {
        public static ITreeNode CreateTreeNode<TNode>(TNode item, Func<TNode, IEnumerable<ITreeNode>> subElementsFactory)
        {
            return new TreeNode<TNode>(item, subElementsFactory);
        }
        public static ITreeNode CreateUnitTreeNode(this Unit unit)
        {
            return CreateTreeNode(unit, u =>
                u.SubUnits.Select(CreateUnitTreeNode)
                 .Cast<ITreeNode>()
                 .Union(u.Positions.Select(p => CreateTreeNode(p, _ => Enumerable.Empty<ITreeNode>())))
            );
        }

    }
}
