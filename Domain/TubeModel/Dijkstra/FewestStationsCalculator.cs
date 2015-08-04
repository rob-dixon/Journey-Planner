using System.Collections.Generic;

namespace Domain.TubeModel.Dijkstra
{
    public class FewestStationsCalculator : RouteBaseCalculator
    {
        public override List<Node> CalculateRoute(Graph graph, string startingNode, string finishStation)
        {
            return base.CalculateRoute(graph, startingNode, finishStation);
        }
    }
}