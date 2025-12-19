using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class Dijkstra<TNode> where TNode : notnull
    {
        private Graph<TNode, WeightedConnection<TNode>> _graph;

        public Dijkstra(Graph<TNode, WeightedConnection<TNode>> graph) { _graph = graph; }

        public Dictionary<TNode, double> FindPath(TNode start)
        {
            Queue<Tuple<TNode, double>> queue = new Queue<Tuple<TNode, double>>();
            Dictionary<TNode, double> distances = new Dictionary<TNode, double>();
            List<TNode> visited = new List<TNode>();

            foreach (TNode node in _graph)
            {
                distances[node] = double.MaxValue;
            }

            distances[start] = 0.0;

            queue.Enqueue(new Tuple<TNode, double>(start, 0.0));
            visited.Add(start);

            while (queue.Count > 0)
            {
                Tuple<TNode, double> item = queue.Dequeue();
                TNode node = item.Item1;
                double distance = item.Item2;

                if (distances[node] < distance)
                {
                    continue;
                }

                LinkedList<WeightedConnection<TNode>> connections = _graph.GetConnections(node);
                foreach (WeightedConnection<TNode> conn in connections)
                {
                    if (visited.Contains(conn.To))
                        continue;

                    visited.Add(conn.To);

                    double newDist = distances[node] + conn.Weight;
                    if (newDist < distances[conn.To])
                    {
                        distances[conn.To] = newDist;
                        queue.Enqueue(new Tuple<TNode, double>(node, newDist));
                    }
                }
            }

            return distances;
        }
    }
}
