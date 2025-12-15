using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    internal class BFS<TNode> where TNode : notnull
    {
        private Graph<TNode> _graph;

        public BFS(Graph<TNode> graph)
        {
            _graph = graph;
        }

        public List<TNode> FindPath(TNode start, TNode? dst, List<TNode>? visited = null)
        {
            if (visited == null)
            {
                visited = new List<TNode>();
            }

            Queue<TNode> queue = new Queue<TNode>();
            List<TNode> result = new List<TNode>();

            queue.Enqueue(start);
            visited.Add(start);

            while (queue.Count > 0)
            {
                TNode node = queue.Dequeue();
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
                        queue.Enqueue(connNode);
                    }
                }
            }

            return result;
        }
    }
}
