using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Network.Constants;

namespace Network.Services
{
    public class TubeJourneyPlanner
    {
        private readonly Station[,] matrix;
        private readonly Constants stationHelper;
        private readonly RouteCalculator routeCalculator;

        public TubeJourneyPlanner(Station[,] matrix, Constants stationHelper, RouteCalculator routeCalculator)
        {
            this.matrix = matrix;
            this.stationHelper = stationHelper;
            this.routeCalculator = routeCalculator;
        }

        public TubeJourneyPlanner()
        {
            this.matrix = new MatrixFactory().CreateMatrix();
            this.stationHelper = new Constants();
            this.routeCalculator = new RouteCalculator(this.matrix, this.stationHelper);
        }

        public TubeJourneyResult CalculateJourney(string fromStation, string toStation, string viaStation, string excludingStation)
        {
            var bestRouteResult = new List<RouteResult>();
           

            var source = Array.FindIndex(this.stationHelper.GetStations(), t => String.Compare(t, fromStation, StringComparison.OrdinalIgnoreCase) == 0);
            var destination = Array.FindIndex(this.stationHelper.GetStations(), t => String.Compare(t, toStation, StringComparison.OrdinalIgnoreCase) == 0);

            var matrixStation = this.matrix[source, destination];
            if (matrixStation != null)
            {
                bestRouteResult.Add(new RouteResult
                {
                    LineToStation = String.Join(", ", matrixStation.Branches),
                    Station = toStation
                });
            }
            else
            {
                // ok no direct match what stations can I get to from source
                //var reachableStations = this.GetReachableStations(source).ToList();
                bestRouteResult = this.routeCalculator.FindBestRoute(source, destination);
            }

            return new TubeJourneyResult
            {
                ExcludingStation = excludingStation,
                FromStation = fromStation,
                ToStation = toStation,
                ViaStation = viaStation,
                RouteResults = bestRouteResult
            };
        }
    }
}
