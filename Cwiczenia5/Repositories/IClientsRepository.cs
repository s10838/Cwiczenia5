using Cwiczenia5.Models;

namespace Cwiczenia5.Repositories
{
    public interface IClientsRepository
    {
        Task<IEnumerable<Client>> GetClientsAsync();
        Task<Client> GetClientByIdAsync(int id);
        Task<Client> GetClientByPeselAsync(string pesel);
        Task AddClientAsync(Client client);
        Task UpdateClientAsync(Client client);
        Task DeleteClientAsync(int id);
        Task<bool> ClientHasTripsAsync(int idClient);
    }
}