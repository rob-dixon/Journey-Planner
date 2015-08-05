using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Domain;
using Domain.TubeModel;
using Domain.TubeModel.Dijkstra;

namespace ConsoleApplication1
{

   

    class Program
    {

        static void Main()
        {
            

            var tubeJourneyPlanner = new TubeJourneyPlanner();

            var bestRoute = tubeJourneyPlanner.FindByShortestDistance(new TubeJourneyRequest(
                                                                            Constants.TottenhamCourtRoad, 
                                                                            Constants.Embankment,
                                                                            viaStation:Constants.Blackfriars))
                                                                            .ToList();

            // start at end of routes, loop down to find route back


            foreach (RouteResult t in bestRoute)
            {
                Console.WriteLine(" {0} - {1} - {2} - {3}", t.FromStation, 
                    t.ToStation, 
                    t.DistanceFromStart, 
                    t.ConnectionMedium);
            }


            Console.ReadKey();
        }

       
        
    }
}
