using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.TubeModel.Dijkstra
{
    
    public abstract class RouteCalculatorBase
    {
        protected readonly List<RouteResult> RouteResults;

        protected RouteCalculatorBase()
        {
            this.RouteResults = new List<RouteResult>();
        }

        public List<RouteResult> CalculateRoute(Graph graph, string startingNode, string finishStation, string excludingStation)
        {
            if (!graph.Nodes.ContainsKey(startingNode))
            {
                throw new ArgumentException("Starting node must be in graph.");
            }

            this.Initialise(graph, startingNode);
            this.ProcessGraph(graph, finishStation, excludingStation);

            return this.ExtractResults();
        }

        protected abstract List<RouteResult> ExtractResults();

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
            this.RouteResults.Clear();
        }

        private void ProcessGraph(Graph graph, string finishStation, string excludingStation)
        {
            var finished = false;
            var queue = graph.Nodes.Values.ToList();

            while (!finished)
            {
                // get the node from the node list with the smallest distance (placed first in queue)
                var nextNode = queue.OrderBy(n => n.DistanceFromStart).FirstOrDefault(n => !double.IsPositiveInfinity(n.DistanceFromStart));

                if (nextNode != null)
                {
                    finished = ProcessNode(nextNode, queue, finishStation, excludingStation);
                    if (finished)
                    {
                        return;
                    }
                    // check route results here for via??
                    queue.Remove(nextNode);
                }
                else
                {
                    finished = true;
                }
            }
        }

        protected abstract bool ProcessNode(Node node, List<Node> queue, string finishStation, string exludingStation);
      
    }
}
