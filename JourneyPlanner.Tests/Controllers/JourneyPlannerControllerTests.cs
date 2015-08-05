using System.Collections.Generic;
using System.Web.Http;
using Domain;
using JourneyPlanner.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace JourneyPlanner.Tests.Controllers
{
    [TestClass]
    public class JourneyPlannerControllerTests
    {
        private JourneyPlannerController journeyPlannerController;
        private Mock<IJourneyPlanner> mockJourneyPlanner;

        [TestInitialize]
        public void Arrange()
        {
            this.mockJourneyPlanner = new Mock<IJourneyPlanner>();
            this.journeyPlannerController = new JourneyPlannerController(mockJourneyPlanner.Object);
        }

        [TestMethod]
        public void GetJourney_VerifyCallsSupportingClasses_True()
        {
            this.mockJourneyPlanner.Setup(x => x.FindByShortestDistance(It.IsAny<TubeJourneyRequest>()));
          
            journeyPlannerController.GetJourney(Constants.Embankment, Constants.Holborn);

            this.mockJourneyPlanner.Verify(x => x.FindByShortestDistance(It.IsAny<TubeJourneyRequest>()), Times.Once);
        }

         [TestMethod]
         public void GetJourney_VerifyReturnsCorrectResult_True()
         {
            var tubeJourneyRequest = new TubeJourneyRequest(Constants.Embankment, Constants.Holborn);
            this.mockJourneyPlanner.Setup(x => x.FindByShortestDistance(tubeJourneyRequest));
          
            var result = journeyPlannerController.GetJourney(Constants.Embankment, Constants.Holborn);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(TubeJourneyResult));
            Assert.AreEqual(result.TubeJourneyRequest.StartStation,tubeJourneyRequest.StartStation);
            Assert.AreEqual(result.TubeJourneyRequest.FinishStation,tubeJourneyRequest.FinishStation);
        }

         [TestMethod]
         [ExpectedException(typeof(HttpResponseException))]
         public void GetJourney_VerifyNotFoundExceptionThrowIfNoResults_True()
         {
            var tubeJourneyRequest = new TubeJourneyRequest(Constants.Embankment, Constants.Embankment);
            this.mockJourneyPlanner.Setup(x => x.FindByShortestDistance(tubeJourneyRequest));
          
            journeyPlannerController.GetJourney(Constants.Embankment, Constants.Holborn);
        }
    }
}
