using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.TubeModel.Dijkstra
{
    public class FastestTimeCalculator : RouteBaseCalculator
    {
        public override List<Node> CalculateRoute(Graph graph, string startingNode, string finishStation)
        {
            return base.CalculateRoute(graph, startingNode, finishStation);
        }
    }
}