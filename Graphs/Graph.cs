using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    internal class Graph<TNode, TConnection>
        where TNode : notnull
        where TConnection : notnull, IConnection<TNode, TConnection>
    {
        private Dictionary<TNode, LinkedList<TConnection>> _nodes; // Adjacency list of nodes
        private bool _isDirectional;

        public Graph(bool isDirectional)
        {
            _nodes = new Dictionary<TNode, LinkedList<TConnection>>();
            _isDirectional = isDirectional;
        }

        public int Count
        {
            get { return _nodes.Count; }
        }

        public void AddNode(TNode node)
        {
            var list = new LinkedList<TConnection>();
            _nodes.Add(node, list);
        }

        public void AddConnection(TConnection connection)
        {
            _nodes[connection.From].AddLast(connection);

            // When not directional, connection goes both ways
            if (!_isDirectional)
            {
                TConnection opposite = connection.GetOpposite();

                if (IsUniqueConnection(opposite))
                {
                    _nodes[connection.To].AddLast(opposite);
                }
            }
        }

        public LinkedList<TConnection> GetConnections(TNode node)
        {
            return _nodes[node];
        }

        public IEnumerator<TNode> GetEnumerator()
        {
            return _nodes.Keys.GetEnumerator();
        }

        private bool IsUniqueConnection(TConnection connection)
        {
            foreach (LinkedList<TConnection> connections  in _nodes.Values)
            {
                foreach(TConnection conn in connections)
                {
                    if (conn.To.Equals(connection.To))
                        return false;
                }
            }

            return true;
        }
    }
}
