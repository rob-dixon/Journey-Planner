using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.TubeModel.Dijkstra
{
    
    public class RouteCalculator
    {
        private readonly List<RouteResult> routeResults;
        
        public RouteCalculator()
        {
            this.routeResults = new List<RouteResult>();
        }

        public virtual List<RouteResult> CalculateRoute(Graph graph, string startingNode, string finishStation)
        {
            if (!graph.Nodes.ContainsKey(startingNode))
            {
                throw new ArgumentException("Starting node must be in graph.");
            }

            this.Initialise(graph, startingNode);
            this.ProcessGraph(graph, finishStation);

            return this.routeResults.OrderBy(x => x.TimeFromStart).ToList();
        }

        private void Initialise(Graph graph, string startingNode)
        {
            // set distance to all nodes to be infinite value
            foreach (var node in graph.Nodes.Values)
            {
                node.DistanceFromStart = double.PositiveInfinity;
            }

            // initialize the start node to zero
            graph.Nodes[startingNode].DistanceFromStart = 0;

            // clear any previous route results
            this.routeResults.Clear();
        }

        protected virtual void ProcessGraph(Graph graph, string finishStation)
        {
            var finished = false;
            var queue = graph.Nodes.Values.ToList();
            while (!finished)
            {
                // get the node from the node list with the smallest distance (placed first in queue)
                var nextNode = queue.OrderBy(n => n.DistanceFromStart).FirstOrDefault(n => !double.IsPositiveInfinity(n.DistanceFromStart));

                if (nextNode != null)
                {
                    finished = ProcessNode(nextNode, queue, finishStation);
                    if (finished)
                    {
                        return;
                    }
                    queue.Remove(nextNode);
                }
                else
                {
                    finished = true;
                }
            }
        }

        protected virtual bool ProcessNode(Node node, List<Node> queue, string finishStation)
        {
            // get all the connections for the node being processed
            var connections = node.Connections.Where(c => queue.Contains(c.Target)).OrderBy(x => x.Distance);

            // iterate through all the connections from this node
            foreach (var connection in connections)
            {
                // calculate the 
                var distance = node.DistanceFromStart + connection.Distance;
                if (distance < connection.Target.DistanceFromStart)
                {
                    connection.Target.DistanceFromStart = distance;

                    this.routeResults.Add(new RouteResult
                    {
                        ConnectionMedium = connection.ConnectionMedium.ToString(),
                        FromStation = node.Name,
                        ToStation = connection.Target.Name,
                        TimeFromStart = distance
                    });

                    if (connection.Target.Name == finishStation)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
