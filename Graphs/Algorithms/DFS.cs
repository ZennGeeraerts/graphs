using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class DFS<TNode, TConnection>
        where TNode : notnull
        where TConnection : notnull, IConnection<TNode, TConnection>
    {
        private Graph<TNode, TConnection> _graph;

        public DFS(Graph<TNode, TConnection> graph) { _graph = graph; }

        public List<TNode> FindPath(TNode start, TNode? dst)
        {
            List<TNode>  visited = new List<TNode>();
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

                LinkedList<TConnection> connections = _graph.GetConnections(node);

                foreach (TConnection conn in connections)
                {
                    if (!visited.Contains(conn.To))
                    {
                        visited.Add(conn.To);
                        stack.Push(conn.To);
                    }
                }
            }

            return result;
        }
    }
}
