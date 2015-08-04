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

        public JourneyPlannerController(TubeJourneyPlanner tubeJourneyPlanner)
        {
            this.tubeJourneyPlanner = tubeJourneyPlanner;
        }


        [Route("api/journeyplanner/{startStation}/{toStation}/{viaStation?}/{excludingStation?}")]
        public TubeJourneyResult GetJourney(string startStation, string finishStation, string viaStation = "-", string excludingStation = "-")
        {
            var tubeJourneyRequest = new TubeJourneyRequest(startStation, finishStation, viaStation, excludingStation);

            var result = this.tubeJourneyPlanner.FindByFewestStations(tubeJourneyRequest);

            return new TubeJourneyResult {RouteResult = result, TubeJourneyRequest = tubeJourneyRequest};
        }

        [Route("api/journeyplanner/stations")]
        public string[] GetAllStations()
        {
            return new Constants().GetStations();
        }

    }
}
