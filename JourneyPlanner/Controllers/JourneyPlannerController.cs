﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Channels;
using System.Web.Http;
using Domain;
using JourneyPlanner.Services;

namespace JourneyPlanner.Controllers
{
    public class JourneyPlannerController : ApiController
    {
        private readonly IJourneyPlanner tubeJourneyPlanner;
        private readonly IStationValidator stationValidator;

        public JourneyPlannerController()
        {
            this.tubeJourneyPlanner = new TubeJourneyPlanner();
            this.stationValidator = new StationValidator();
        }

        public JourneyPlannerController(IJourneyPlanner tubeJourneyPlanner, IStationValidator stationValidator)
        {
            this.tubeJourneyPlanner = tubeJourneyPlanner;
            this.stationValidator = stationValidator;
        }

        public TubeJourneyResult GetJourney(string startStation, string finishStation, string viaStation = null, string excludingStation = null)
        {
            var tubeJourneyRequest = this.stationValidator.ValidateRequest(startStation, finishStation, viaStation, excludingStation);
            List<RouteResult> result;

            try
            {
                result = this.tubeJourneyPlanner.FindByShortestDistance(tubeJourneyRequest);
            }
            catch (Exception ex)
            {
                // log ex here

                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            if (result == null || !result.Any())
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound) { Content = new StringContent("No routes found"), };
                throw new HttpResponseException(response);
            }

            return new TubeJourneyResult {RouteResult = result, TubeJourneyRequest = tubeJourneyRequest};
        }



        [Route("api/journeyplanner/stations")]
        public string[] GetAllStations()
        {
            return new Constants().GetStations();
        }
    }
}
