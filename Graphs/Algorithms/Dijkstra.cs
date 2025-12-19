using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Algorithms
{
    public class Dijkstra<TNode> where TNode : notnull
    {
        private Graph<TNode, WeightedConnection<TNode>> _graph;

        public Dijkstra(Graph<TNode, WeightedConnection<TNode>> graph) { _graph = graph; }

        public Dictionary<TNode, double> FindPath(TNode start)
        {
            PriorityQueue<TNode, double> queue = new PriorityQueue<TNode, double>();
            Dictionary<TNode, double> distances = new Dictionary<TNode, double>();

            foreach (TNode node in _graph)
            {
                distances[node] = double.MaxValue;
            }

            distances[start] = 0.0;

            queue.Enqueue(start, 0.0);

            while (queue.Count > 0)
            {
                TNode node = queue.Dequeue();

                LinkedList<WeightedConnection<TNode>> connections = _graph.GetConnections(node);
                foreach (WeightedConnection<TNode> conn in connections)
                {
                    double newDist = distances[node] + conn.Weight;
                    if (newDist < distances[conn.To])
                    {
                        distances[conn.To] = newDist;
                        queue.Enqueue(conn.To, newDist);
                    }
                }
            }

            return distances;
        }
    }
}
