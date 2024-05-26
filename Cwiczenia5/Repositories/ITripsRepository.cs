using Cwiczenia5.Models;

namespace Cwiczenia5.Repositories
{
    public interface ITripsRepository
    {
        Task<IEnumerable<Trip>> GetAllTripsAsync();
        Task<bool> TripExistsAsync(int idTrip);
        Task<bool> IsClientAssignedToTripAsync(int idClient, int idTrip);
        Task AssignClientToTripAsync(ClientTrip clientTrip);
    }
}