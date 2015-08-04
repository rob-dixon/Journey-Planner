using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Network.Constants;

namespace Network.Services
{
    public class RouteCalculator
    {
        private readonly Station[,] matrix;
        private readonly Constants stationHelper;

        public RouteCalculator(Station[,] matrix, Constants stationHelper)
        {
            this.matrix = matrix;
            this.stationHelper = stationHelper;
        }

        public List<RouteResult> FindBestRoute(int source, int destination)
        {
            var bestRouteCandidate = new List<StationPoint>();

            var reachableStations = this.GetReachableStations(source);
            
            bestRouteCandidate.AddRange(reachableStations);

            return null;

        }

        private void FindRoutes(int originSource, int source, ref List<StationPoint> routes)
        {
            var checkRoutes = routes;

            // get all reachable stations from current source where does not equal the origin source and route is not added
            var reachableStations = this.GetReachableStations(source).Where(s => s.Y != originSource).ToList();
            
            routes.AddRange(reachableStations);
            foreach (var reachableStation in reachableStations)
            {
                FindRoutes(originSource, reachableStation.Y, ref routes);
            }
        }

        private IEnumerable<StationPoint> GetReachableStations(int source)
        {
            var stationPoints = new List<StationPoint>();

            for (var j = 0; j < this.matrix.GetLength(1); j++)
            {
                if (this.matrix[source, j] !=null)
                {
                     stationPoints.Add(new StationPoint
                     {
                         Station = this.matrix[source, j],
                         X = source,
                         Y = j,
                         Name = this.stationHelper.GetStations()[j]
                     });   
                }
           
            }
            return stationPoints.ToArray();
        }
    }
}
