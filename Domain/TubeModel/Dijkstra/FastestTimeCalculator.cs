using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.TubeModel.Dijkstra
{
    public class FastestTimeCalculator : RouteCalculatorBase
    {

        protected override bool ProcessNode(Node node, List<Node> queue, string finishStation, string excludingStation)
        {
            throw new NotImplementedException();
        }

        protected override List<RouteResult> ExtractResults()
        {
            throw new NotImplementedException();
        }
    }
}