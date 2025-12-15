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

            // Keep going as long as we have nodes in the stack
            while (stack.Count > 0)
            {
                TNode node = stack.Pop();
                result.Add(node);

                // Stop when we have a destination node and we found it
                if (dst != null && node.Equals(dst))
                {
                    break;
                }

                LinkedList<TNode> neighbours = _graph.GetConnections(node);

                foreach (TNode neighbour in neighbours)
                {
                    if (!visited.Contains(neighbour))
                    {
                        visited.Add(neighbour);
                        stack.Push(neighbour);
                    }
                }
            }

            return result;
        }
    }
}
