using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    internal class Graph<TNode> where TNode : notnull
    {
        private Dictionary<TNode, LinkedList<TNode>> _nodes;
        private bool _isDirectional;

        public Graph(bool isDirectional)
        {
            _nodes = new Dictionary<TNode, LinkedList<TNode>>();
            _isDirectional = isDirectional;
        }

        public void AddNode(TNode node)
        {
            var list = new LinkedList<TNode>();
            _nodes.Add(node, list);
        }

        public void AddConnection(TNode src, TNode dst)
        {
            _nodes[src].AddLast(dst);

            if (!_isDirectional)
            {
                _nodes[dst].AddLast(src);
            }
        }

        public LinkedList<TNode> GetConnections(TNode node)
        {
            return _nodes[node];
        }

        public IEnumerator<TNode> GetEnumerator()
        {
            return _nodes.Keys.GetEnumerator();
        }
    }
}
