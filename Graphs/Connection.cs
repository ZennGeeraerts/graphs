using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    internal class Connection<TNode> : IConnection<TNode, Connection<TNode>>
        where TNode : notnull
    {
        private TNode _from;
        private TNode _to;

        public Connection(TNode from, TNode to)
        {
            _from = from;
            _to = to;
        }

        public TNode From { get { return _from; } }
        public TNode To { get { return _to; } }

        public virtual Connection<TNode> GetOpposite()
        {
            return new Connection<TNode>(_to, _from);
        }
    }
}
