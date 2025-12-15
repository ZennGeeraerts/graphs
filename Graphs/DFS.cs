using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    internal class DFS<TNode> where TNode : notnull
    {
        private Graph<TNode> _graph;

        public DFS(Graph<TNode> graph) { _graph = graph; }

        public List<TNode> FindPath(TNode start, TNode? dst, List<TNode>? visited = null)
        {
            if (visited == null)
            {
                visited = new List<TNode>();
            }

            Stack<TNode> stack = new Stack<TNode>();
            List<TNode> result = new List<TNode>();

            stack.Push(start);
            visited.Add(start);

            while (stack.Count > 0)
            {
                TNode node = stack.Pop();
                result.Add(node);

                // Stop when we have a destination node and we found it
                if (dst != null && node.Equals(dst))
                {
                    break;
                }

                LinkedList<TNode> connections = _graph.GetConnections(node);

                foreach (TNode connNode in connections)
                {
                    if (!visited.Contains(connNode))
                    {
                        visited.Add(connNode);
                        stack.Push(connNode);
                    }
                }
            }

            return result;
        }
    }
}
