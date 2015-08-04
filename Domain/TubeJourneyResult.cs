using System.Collections.Generic;

namespace Domain
{
    public class TubeJourneyResult
    {
        public TubeJourneyRequest TubeJourneyRequest { get; set; }

        public List<RouteResult> RouteResult { get; set; }
    }
}
