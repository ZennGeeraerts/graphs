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

        public BFS(Graph<TNode> graph) { _graph = graph; }

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

            // Keep going as long as we have nodes in the queue
            while (queue.Count > 0)
            {
                TNode node = queue.Dequeue();
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
                        queue.Enqueue(neighbour);
                    }
                }
            }

            return result;
        }
    }
}
