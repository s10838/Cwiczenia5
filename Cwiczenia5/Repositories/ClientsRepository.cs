using Microsoft.EntityFrameworkCore;
using Cwiczenia5.Context;
using Cwiczenia5.Models;

namespace Cwiczenia5.Repositories
{
    public class ClientsRepository : IClientsRepository
    {
        private readonly S10838Context _context;

        public ClientsRepository(S10838Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetClientByIdAsync(int id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task<Client> GetClientByPeselAsync(string pesel)
        {
            return await _context.Clients.SingleOrDefaultAsync(c => c.Pesel == pesel);
        }

        public async Task AddClientAsync(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClientAsync(Client client)
        {
            _context.Entry(client).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClientAsync(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client != null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ClientHasTripsAsync(int idClient)
        {
            return await _context.ClientTrips.AnyAsync(ct => ct.IdClient == idClient);
        }
    }
}