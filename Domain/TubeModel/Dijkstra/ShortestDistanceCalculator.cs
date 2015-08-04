using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.TubeModel.Dijkstra
{
    public class ShortestDistanceCalculator : RouteBaseCalculator
    {
        public override List<Node> CalculateRoute(Graph graph, string startingNode, string finishStation)
        {
            return base.CalculateRoute(graph, startingNode, finishStation);
        }
    }


}
