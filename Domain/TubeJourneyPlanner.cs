using System.Collections.Generic;
using Domain.TubeModel;
using Domain.TubeModel.Dijkstra;
using System.Linq;

namespace Domain
{
    public class TubeJourneyPlanner : IJourneyPlanner
    {
        private readonly Graph tubeGraph;
        private RouteCalculator routeCalculator;
        
        public TubeJourneyPlanner()
        {
            this.tubeGraph = new TubeGraphFactory().CreateTubeGraph();            
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
            this.routeCalculator = new ShortestDistanceCalculator();
            var allRoutes = this.routeCalculator.CalculateRoute(this.tubeGraph, tubeJourneyRequest.StartStation, tubeJourneyRequest.FinishStation);

            var bestRoute = new List<RouteResult> { allRoutes[0] };
                       
            var finishStation = allRoutes[0].FromStation;

            for (var i = 1; i < allRoutes.Count; i++)
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