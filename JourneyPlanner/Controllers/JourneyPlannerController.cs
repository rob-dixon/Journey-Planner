using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain;

namespace JourneyPlanner.Controllers
{
    public class JourneyPlannerController : ApiController
    {
        private readonly IJourneyPlanner tubeJourneyPlanner;

        public JourneyPlannerController()
        {
            this.tubeJourneyPlanner = new TubeJourneyPlanner();
        }

        public JourneyPlannerController(IJourneyPlanner tubeJourneyPlanner)
        {
            this.tubeJourneyPlanner = tubeJourneyPlanner;
        }


       // [Route("api/journeyplanner/{startStation}/{toStation}/{viaStation?}/{excludingStation?}/")]
        public TubeJourneyResult GetJourney(string startStation, string finishStation, string viaStation = null, string excludingStation = null)
        {
            var tubeJourneyRequest = new TubeJourneyRequest(startStation, 
                                                            finishStation, 
                                                            viaStation, 
                                                            excludingStation);
            try
            {
                var result = this.tubeJourneyPlanner.FindByShortestDistance(tubeJourneyRequest);
                
                if (result == null || !result.Any())
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NotFound) { Content = new StringContent("No routes found"), };
                    throw new HttpResponseException(response);
                }

                return new TubeJourneyResult {RouteResult = result, TubeJourneyRequest = tubeJourneyRequest};
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [Route("api/journeyplanner/stations")]
        public string[] GetAllStations()
        {
            return new Constants().GetStations();
        }

    }
}
