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

            var bestRoute = tubeJourneyPlanner.FindByShortestDistance(new TubeJourneyRequest(Constants.TottenhamCourtRoad, Constants.Monument)).ToList();

            // start at end of routes, loop down to find route back


            for (var i = 0; i < bestRoute.Count; i++)
            {
               Console.WriteLine(" {0} - {1} - {2} - {3}", bestRoute[i].FromStation, 
                                                            bestRoute[i].ToStation, 
                                                            bestRoute[i].TimeFromStart, 
                                                            bestRoute[i].ConnectionMedium);
            }
             

            Console.ReadKey();
        }

       
        
    }
}
