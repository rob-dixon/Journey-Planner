using System.Collections.Generic;

namespace Domain
{
    public interface IJourneyPlanner
    {
        List<RouteResult> FindByFewestStations(TubeJourneyRequest tubeJourneyRequest);

        List<RouteResult> FindByFastestTime(TubeJourneyRequest tubeJourneyRequest);

        List<RouteResult> FindByShortestDistance(TubeJourneyRequest tubeJourneyRequest);
    }
}
