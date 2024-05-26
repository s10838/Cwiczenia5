using Cwiczenia5.Models;

public interface ITripsService
{
    Task<IEnumerable<Trip>> GetTripsAsync();
    Task<bool> TripExistsAsync(int idTrip);
    Task<bool> IsClientAssignedToTripAsync(int idClient, int idTrip);
    Task AssignClientToTripAsync(ClientTrip clientTrip);
}