using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    internal class WeightedConnection<TNode> : Connection<TNode>
        where TNode : notnull
    {
        private float _weight = 0;
        public WeightedConnection(TNode from, TNode to, float weight) : base(from, to)
        {
            _weight = weight;
        }

        public float Weight { get { return _weight; } }

        public override Connection<TNode> GetOpposite()
        {
            return new WeightedConnection<TNode>(To, From, _weight);
        }
    }
}
