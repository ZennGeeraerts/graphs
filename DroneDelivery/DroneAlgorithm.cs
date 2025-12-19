using Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneDelivery
{
    internal class DroneAlgorithm
    {
        private Graph<City, WeightedConnection<City>> _graph;
        private const int _MaxBattery = 10;

        public DroneAlgorithm(Graph<City, WeightedConnection<City>> graph) { _graph = graph; }

        public double FindPath(City start, City dst)
        {
            PriorityQueue<(City, int), double> queue = new PriorityQueue<(City, int), double>();
            Dictionary<City, double[]> distances = new Dictionary<City, double[]>();

            foreach (City city in _graph)
            {
                distances[city] = new double[_MaxBattery + 1];
                Array.Fill(distances[city], double.MaxValue);
            }

            distances[start][_MaxBattery] = 0.0;

            queue.Enqueue((start, _MaxBattery), 0.0);

            while (queue.Count > 0)
            {
                queue.TryDequeue(out var state, out double spent);
                var (city, battery) = state;

                if (city == dst)
                    return spent;

                if (spent > distances[city][battery])
                    continue;

                LinkedList<WeightedConnection<City>> connections = _graph.GetConnections(city);
                foreach (WeightedConnection<City> conn in connections)
                {
                    if (battery < conn.Weight)
                        continue;

                    int newBattery = battery - (int)conn.Weight;

                    if (city.CanRecharge)
                        newBattery = _MaxBattery;

                    double newSpent = spent + conn.Weight;
                    if (newSpent < distances[conn.To][newBattery])
                    {
                        distances[conn.To][newBattery] = newSpent;
                        queue.Enqueue((conn.To, newBattery), newSpent);
                    }
                }
            }

            return -1;
        }
    }
}
