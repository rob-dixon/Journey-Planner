using Domain;

namespace JourneyPlanner.Services
{
    public interface IStationValidator
    {
        TubeJourneyRequest ValidateRequest(string startStation, string finishStation, string viaStation,
            string excludingStation);
    }
}