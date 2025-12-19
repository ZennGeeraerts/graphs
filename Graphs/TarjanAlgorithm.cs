using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Graphs
{
    internal class TarjanAlgorithm<TNode, TConnection>
        where TNode : notnull
        where TConnection : notnull, IConnection<TNode, TConnection>
    {
        private Graph<TNode, TConnection> _graph;
        private const int _Unvisited = -1;

        public TarjanAlgorithm(Graph<TNode, TConnection> graph) { _graph = graph; }

        public List<List<TNode>> FindStronglyConnectedComponents()
        {
            int index = 0;

            Dictionary<TNode, int> ids = new Dictionary<TNode, int>(_graph.Count); // Node ids
            Dictionary<TNode, int> lowLinkValues = new Dictionary<TNode, int>(_graph.Count); // Lowest link from a node
            HashSet<TNode> onStack = new HashSet<TNode>(); // Track whether a node is on the stack
            Stack<TNode> stack = new Stack<TNode>(); // The actual stack
            List<List<TNode>> components = new List<List<TNode>>(); // Strongly connected component table

            foreach (TNode node in _graph)
            {
                ids[node] = _Unvisited;
            }

            foreach (TNode node in _graph)
            {
                if (ids[node] == _Unvisited)
                {
                    DepthFirstSearch(node, ref index, ids, lowLinkValues, stack, onStack, components);
                }
            }

            return components;
        }

        private void DepthFirstSearch(TNode node,
            ref int index,
            Dictionary<TNode, int> ids,
            Dictionary<TNode, int> lowLinkValues,
            Stack<TNode> stack,
            HashSet<TNode> onStack,
            List<List<TNode>> components)
        {
            stack.Push(node);
            onStack.Add(node);

            ids[node] = lowLinkValues[node] = index++;

            // Visit all neighbours and update the low link value to the minimum
            LinkedList<TConnection> connections = _graph.GetConnections(node);
            foreach (TConnection conn in connections)
            {
                if (ids[conn.To] == _Unvisited)
                {
                    DepthFirstSearch(conn.To, ref index, ids, lowLinkValues, stack, onStack, components);
                }
                else if (onStack.Contains(conn.To))
                {
                    lowLinkValues[node] = Math.Min(lowLinkValues[node], lowLinkValues[conn.To]);
                }
            }

            // After visiting all the neighbours of node
            // If we're at the start of a SCC
            // empty the seen stack until we're back to the start of the SCC.
            if (ids[node] == lowLinkValues[node])
            {
                List<TNode> component = new List<TNode>();

                while (true)
                {
                    var n = stack.Pop();
                    onStack.Remove(n);
                    component.Add(n);

                    if (n.Equals(node))
                        break;
                }

                components.Add(component);
            }
        }
    }
}
