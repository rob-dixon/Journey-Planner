using System;
using System.Net;
using System.Web.Http;
using JourneyPlanner.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JourneyPlanner.Tests.Services
{
    [TestClass]
    public class StationValidatorTests
    {
        private IStationValidator stationValidator;

        [TestInitialize]
        public void Arrange()
        {
            this.stationValidator = new StationValidator();
        }

        [TestMethod]
        public void ValidateRequest_ThrowsBadRequestErrorGivenInvalidParams_True()
        {
            try
            {
                this.stationValidator.ValidateRequest("xxx", null, null, null);
                Assert.Fail("Exception not thrown");
            }
            catch (HttpResponseException ex)
            {
                Assert.IsNotNull(ex);
                Assert.AreEqual(ex.Response.StatusCode,HttpStatusCode.BadRequest);
                Assert.AreEqual(ex.Response.Content.ReadAsStringAsync().Result,"startStation");
            }
        }
    }
}
