using System.Collections.Generic;

namespace Network
{
    public class TubeJourneyResult
    {
        public string FromStation { get; set; }

        public string ToStation { get; set; }

        public string ViaStation { get; set; }

        public string ExcludingStation { get; set; }

        public int TimeMinutes { get; set; }

        public List<RouteResult> RouteResults { get; set; }

        public TubeJourneyResult()
        {
            this.RouteResults = new List<RouteResult>();
        }
    }
}