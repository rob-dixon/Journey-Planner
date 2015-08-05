using System;
using System.Collections.Generic;
using Domain.TubeModel;
using Domain.TubeModel.Dijkstra;
using System.Linq;

namespace Domain
{
    public class TubeJourneyPlanner : IJourneyPlanner
    {
        private readonly Graph tubeGraph;
        private RouteCalculatorBase routeCalculator;
        
        public TubeJourneyPlanner()
        {
            this.tubeGraph = new TubeGraphFactory().CreateTubeGraph();            
        }

        public List<RouteResult> FindByFewestStations(TubeJourneyRequest tubeJourneyRequest)
        {
            throw new NotImplementedException();
        }

        public List<RouteResult> FindByFastestTime(TubeJourneyRequest tubeJourneyRequest)
        {
            throw new NotImplementedException();
        }

        public List<RouteResult> FindByShortestDistance(TubeJourneyRequest tubeJourneyRequest)
        {
            var bestRoute = new List<RouteResult>();
            var viaCheck = !string.IsNullOrEmpty(tubeJourneyRequest.ViaStation);
            var originalStartStation = tubeJourneyRequest.StartStation;

            if (tubeJourneyRequest.StartStation == tubeJourneyRequest.FinishStation)
            {
                return bestRoute;
            }

            this.routeCalculator = new ShortestDistanceCalculator();
            
            
            // if via then first get best route from via to finish (last part of route)
            if (viaCheck)
            {
                var lastRoute = this.routeCalculator.CalculateRoute(this.tubeGraph,
                                                            tubeJourneyRequest.ViaStation,
                                                            tubeJourneyRequest.FinishStation,
                                                            tubeJourneyRequest.ExcludingStation);
                // get best route from start
                var bestRouteToVia = this.routeCalculator.CalculateRoute(this.tubeGraph,
                                                            originalStartStation,
                                                            tubeJourneyRequest.ViaStation,
                                                            tubeJourneyRequest.FinishStation);

                bestRoute.AddRange(bestRouteToVia);
                bestRoute.AddRange(lastRoute);
            }
            else
            {
                bestRoute = this.routeCalculator.CalculateRoute(this.tubeGraph,
                                                            tubeJourneyRequest.StartStation,
                                                            tubeJourneyRequest.FinishStation,
                                                            tubeJourneyRequest.ExcludingStation);
            }
                       
            
            
            return bestRoute;
        }
    }
}