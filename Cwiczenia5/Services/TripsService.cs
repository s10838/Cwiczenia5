using Cwiczenia5.Models;
using Cwiczenia5.Repositories;

public class TripsService : ITripsService
{
    private readonly ITripsRepository _tripsRepository;

    public TripsService(ITripsRepository tripsRepository)
    {
        _tripsRepository = tripsRepository;
    }

    public async Task<IEnumerable<Trip>> GetTripsAsync()
    {
        return await _tripsRepository.GetAllTripsAsync();
    }

    public async Task<bool> TripExistsAsync(int idTrip)
    {
        return await _tripsRepository.TripExistsAsync(idTrip);
    }

    public async Task<bool> IsClientAssignedToTripAsync(int idClient, int idTrip)
    {
        return await _tripsRepository.IsClientAssignedToTripAsync(idClient, idTrip);
    }

    public async Task AssignClientToTripAsync(ClientTrip clientTrip)
    {
        await _tripsRepository.AssignClientToTripAsync(clientTrip);
    }
}