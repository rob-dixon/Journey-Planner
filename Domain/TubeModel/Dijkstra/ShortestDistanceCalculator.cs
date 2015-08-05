using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Domain.TubeModel.Dijkstra
{
    public class ShortestDistanceCalculator : RouteCalculatorBase
    {
        protected override bool ProcessNode(Node node, List<Node> queue, string finishStation, string excludingStation)
        {
            // get all the connections for the node being processed
            var connections = node.Connections.Where(c => queue.Contains(c.Target)).OrderBy(x => x.Distance);

            // iterate through all the connections from this node
            foreach (var connection in connections)
            {
                var distance = node.DistanceFromStart + connection.Distance;

                if (distance < connection.Target.DistanceFromStart && connection.Target.Name != excludingStation)
                {
                    connection.Target.DistanceFromStart = distance;

                    this.RouteResults.Add(new RouteResult
                    {
                        ConnectionMedium = connection.ConnectionMedium.ToString(),
                        FromStation = node.Name,
                        ToStation = connection.Target.Name,
                        DistanceFromStart = distance
                    });
                   
                    if (connection.Target.Name == finishStation)
                    {
                        return true;
                    }
                }

            }

            return false;
        }

        protected override List<RouteResult> ExtractResults()
        {
            var allRoutes = this.RouteResults.OrderBy(x => x.DistanceFromStart).ToList();

            return this.GetBestRoute(allRoutes);
        }

        private List<RouteResult> GetBestRoute(IReadOnlyList<RouteResult> allRoutes)
        {
            var bestRoute = new List<RouteResult>();

            if (allRoutes.Count == 0)
            {
                return bestRoute;
            }

            bestRoute.Add(allRoutes[allRoutes.Count - 1]);

            var finishStation = allRoutes[allRoutes.Count - 1].FromStation;

            for (var i = allRoutes.Count - 2; i >= 0; i--)
            {
                if (allRoutes[i].ToStation == finishStation)
                {
                    bestRoute.Add(allRoutes[i]);
                    finishStation = allRoutes[i].FromStation;
                }
            }

            bestRoute.Reverse();
            return bestRoute;
        }
    }


}
