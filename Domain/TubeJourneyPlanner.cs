using System.Collections.Generic;
using Domain.TubeModel;
using Domain.TubeModel.Dijkstra;
using System.Linq;

namespace Domain
{
    public class TubeJourneyPlanner : ITubeJourneyPlanner
    {
        private readonly Graph tubeGraph;
        private readonly RouteCalculator routeCalculator;
        
        public TubeJourneyPlanner()
        {
            this.tubeGraph = new TubeGraphFactory().CreateTubeGraph();
            this.routeCalculator = new RouteCalculator();
        }

        public List<RouteResult> FindByFewestStations(TubeJourneyRequest tubeJourneyRequest)
        {
            this.routeCalculator.CalculateRoute(this.tubeGraph, tubeJourneyRequest.StartStation, tubeJourneyRequest.FinishStation);
            throw new System.NotImplementedException();
        }

        public List<RouteResult> FindByFastestTime(TubeJourneyRequest tubeJourneyRequest)
        {
            var result = this.routeCalculator.CalculateRoute(this.tubeGraph, tubeJourneyRequest.StartStation, tubeJourneyRequest.FinishStation);
            return result;
        }

        public List<RouteResult> FindByShortestDistance(TubeJourneyRequest tubeJourneyRequest)
        {
            var allRoutes = this.routeCalculator.CalculateRoute(this.tubeGraph, tubeJourneyRequest.StartStation, tubeJourneyRequest.FinishStation);
            
            var bestRoute = new List<RouteResult>();

            bestRoute.Add(allRoutes[allRoutes.Count-1]);
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