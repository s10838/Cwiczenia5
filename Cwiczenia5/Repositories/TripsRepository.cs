using Microsoft.EntityFrameworkCore;
using Cwiczenia5.Context;
using Cwiczenia5.Models;

namespace Cwiczenia5.Repositories
{
    public class TripsRepository : ITripsRepository
    {
        private readonly S10838Context _context;

        public TripsRepository(S10838Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Trip>> GetAllTripsAsync()
        {
            return await _context.Trips.OrderByDescending(t => t.DateFrom).ToListAsync();
        }

        public async Task<bool> TripExistsAsync(int idTrip)
        {
            return await _context.Trips.AnyAsync(t => t.IdTrip == idTrip);
        }

        public async Task<bool> IsClientAssignedToTripAsync(int idClient, int idTrip)
        {
            return await _context.ClientTrips.AnyAsync(ct => ct.IdClient == idClient && ct.IdTrip == idTrip);
        }

        public async Task AssignClientToTripAsync(ClientTrip clientTrip)
        {
            _context.ClientTrips.Add(clientTrip);
            await _context.SaveChangesAsync();
        }
    }
}