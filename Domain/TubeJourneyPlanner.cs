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
            //var viaCheck = !string.IsNullOrEmpty(tubeJourneyRequest.ViaStation);
            //var originalFinishStation = tubeJourneyRequest.FinishStation;

            if (tubeJourneyRequest.StartStation == tubeJourneyRequest.FinishStation)
            {
                return bestRoute;
            }

            this.routeCalculator = new ShortestDistanceCalculator();

            /*
            // if having to go via a station calculate first the best route to the via station (i.e. make via the finish station)
            // w
            // then make via station the start route and work from via station to original finish station
            if (viaCheck)
            {
                tubeJourneyRequest.FinishStation = tubeJourneyRequest.ViaStation;
                bestRoute = this.routeCalculator.CalculateRoute(this.tubeGraph, 
                                                            tubeJourneyRequest.StartStation, 
                                                            tubeJourneyRequest.FinishStation,
                                                            tubeJourneyRequest.ExcludingStation);
                tubeJourneyRequest.FinishStation = originalFinishStation;

                bestRoute.AddRange(this.routeCalculator.CalculateRoute(this.tubeGraph, 
                                                            tubeJourneyRequest.ViaStation, 
                                                            tubeJourneyRequest.FinishStation,
                                                            tubeJourneyRequest.ExcludingStation));
                return bestRoute;

            }
            */
                
            bestRoute = this.routeCalculator.CalculateRoute(this.tubeGraph, 
                                                            tubeJourneyRequest.StartStation, 
                                                            tubeJourneyRequest.FinishStation,
                                                            tubeJourneyRequest.ExcludingStation);
            
            
            return bestRoute;
        }
    }
}