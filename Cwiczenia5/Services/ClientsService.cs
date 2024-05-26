using Cwiczenia5.Models;
using Cwiczenia5.Repositories;

namespace Cwiczenia5.Services
{
    public class ClientsService : IClientsService
    {
        private readonly IClientsRepository _clientsRepository;

        public ClientsService(IClientsRepository clientsRepository)
        {
            _clientsRepository = clientsRepository;
        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            return await _clientsRepository.GetClientsAsync();
        }

        public async Task<Client> GetClientByIdAsync(int id)
        {
            return await _clientsRepository.GetClientByIdAsync(id);
        }

        public async Task<Client> GetClientByPeselAsync(string pesel)
        {
            return await _clientsRepository.GetClientByPeselAsync(pesel);
        }

        public async Task AddClientAsync(Client client)
        {
            await _clientsRepository.AddClientAsync(client);
        }

        public async Task UpdateClientAsync(Client client)
        {
            await _clientsRepository.UpdateClientAsync(client);
        }

        public async Task DeleteClientAsync(int id)
        {
            await _clientsRepository.DeleteClientAsync(id);
        }

        public async Task<bool> ClientHasTripsAsync(int idClient)
        {
            return await _clientsRepository.ClientHasTripsAsync(idClient);
        }
    }
}