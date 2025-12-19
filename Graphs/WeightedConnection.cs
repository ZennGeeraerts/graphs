using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class WeightedConnection<TNode> : IConnection<TNode, WeightedConnection<TNode>>
        where TNode : notnull
    {
        private TNode _from;
        private TNode _to;
        private double _weight = 0;
        public WeightedConnection(TNode from, TNode to, double weight)
        {
            _from = from;
            _to = to;
            _weight = weight;
        }

        public TNode From { get { return _from; } }
        public TNode To { get { return _to; } }
        public double Weight { get { return _weight; } }

        public WeightedConnection<TNode> GetOpposite()
        {
            return new WeightedConnection<TNode>(_to, _from, _weight);
        }
    }
}
