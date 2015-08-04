using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.TubeModel.Dijkstra
{
    public class ShortestDistanceCalculator : RouteCalculator
    {
        protected override bool ProcessNode(Node node, List<Node> queue, string finishStation)
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
