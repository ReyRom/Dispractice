using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispractice.Extensions
{
    public interface ITreeNode
    {
        object? Data { get; }
        IEnumerable<ITreeNode> SubElements { get; }
    }

    public class TreeNode<T> : ITreeNode
    {
        private T item;

        private readonly Func<T, IEnumerable<ITreeNode>> _subElementsFactory;

        public TreeNode(T item, Func<T, IEnumerable<ITreeNode>> subElementsFactory)
        {
            this.item = item;
            _subElementsFactory = subElementsFactory;
        }

        public object? Data => item;

        public IEnumerable<ITreeNode> SubElements => _subElementsFactory(item);
    }
}
