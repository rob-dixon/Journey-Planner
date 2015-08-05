using Domain;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JourneyPlanner.Services
{
    public class StationValidator : IStationValidator
    {
        public TubeJourneyRequest ValidateRequest(string startStation, string finishStation, string viaStation, string excludingStation)
        {
            if (!this.ValidateStation(ref startStation))
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("startStation")
                });
            }

            if (!this.ValidateStation(ref finishStation))
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("finishStation")
                });
            }

            if (!string.IsNullOrEmpty(viaStation))
            {
                if (!this.ValidateStation(ref viaStation))
                {
                    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent("viaStation")
                    });
                }
            }

            if (!string.IsNullOrEmpty(excludingStation))
            {
                if (!this.ValidateStation(ref excludingStation))
                {
                    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent("excludingStation")
                    });
                }
            }

            return new TubeJourneyRequest(startStation,finishStation,viaStation,excludingStation);
        }

        
        private bool ValidateStation(ref string name)
        {
            var allStations = new Constants().GetStations().ToList();

            var station = name;
            name = allStations.FirstOrDefault(x => String.Compare(x, station, StringComparison.OrdinalIgnoreCase) == 0);

            return name != null;
        }
    }
}
