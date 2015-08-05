using System.Collections.Generic;
using System.Web.Http;
using Domain;
using JourneyPlanner.Controllers;
using JourneyPlanner.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace JourneyPlanner.Tests.Controllers
{
    [TestClass]
    public class JourneyPlannerControllerTests
    {
        private JourneyPlannerController journeyPlannerController;
        private Mock<IJourneyPlanner> mockJourneyPlanner;
        private Mock<IStationValidator> mockStationValidator;
        private List<RouteResult> routeResults;
        private TubeJourneyRequest tubeJourneyRequest;
        
        [TestInitialize]
        public void Arrange()
        {
            this.tubeJourneyRequest = new TubeJourneyRequest(Constants.Embankment, Constants.Temple);
            this.routeResults = new List<RouteResult>
            {
                new RouteResult
                {
                        ConnectionMedium = ConnectionMedium.DistrictAndCircle.ToString(), 
                        DistanceFromStart = 2,
                        FromStation = Constants.Embankment, 
                        ToStation = Constants.Temple
                }
            };
            this.mockJourneyPlanner = new Mock<IJourneyPlanner>();
            this.mockStationValidator = new Mock<IStationValidator>();
            this.mockStationValidator.Setup(
                x => x.ValidateRequest(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(this.tubeJourneyRequest);
            this.journeyPlannerController = new JourneyPlannerController(mockJourneyPlanner.Object, mockStationValidator.Object);
        }

        [TestMethod]
        public void GetJourney_VerifyCallsSupportingClasses_True()
        {
            this.mockJourneyPlanner.Setup(x => x.FindByShortestDistance(It.IsAny<TubeJourneyRequest>())).Returns(this.routeResults);
          
            journeyPlannerController.GetJourney(Constants.Embankment, Constants.Temple);

            this.mockJourneyPlanner.Verify(x => x.FindByShortestDistance(It.IsAny<TubeJourneyRequest>()), Times.Once);
            this.mockStationValidator.VerifyAll();
        }

         [TestMethod]
         public void GetJourney_VerifyReturnsCorrectResult_True()
         {
            this.mockJourneyPlanner.Setup(x => x.FindByShortestDistance(It.IsAny<TubeJourneyRequest>())).Returns(this.routeResults);;
          
            var result = journeyPlannerController.GetJourney(Constants.Embankment, Constants.Temple);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(TubeJourneyResult));
            Assert.AreEqual(result.TubeJourneyRequest.StartStation,Constants.Embankment);
            Assert.AreEqual(result.TubeJourneyRequest.FinishStation,Constants.Temple);
        }

         [TestMethod]
         [ExpectedException(typeof(HttpResponseException))]
         public void GetJourney_VerifyNotFoundExceptionThrowIfNoResults_True()
         {
            this.mockJourneyPlanner.Setup(x => x.FindByShortestDistance(tubeJourneyRequest)).Returns(new List<RouteResult>());;
          
            journeyPlannerController.GetJourney(Constants.Embankment, Constants.Holborn);
        }
    }
}
