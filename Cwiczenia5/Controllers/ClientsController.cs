using Microsoft.AspNetCore.Mvc;
using Cwiczenia5.Services;

namespace Cwiczenia5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientsService _clientsService;

        public ClientsController(IClientsService clientsService)
        {
            _clientsService = clientsService;
        }

        [HttpDelete("{idClient}")]
        public async Task<IActionResult> DeleteClient(int idClient)
        {
            var client = await _clientsService.GetClientByIdAsync(idClient);
            if (client == null)
            {
                return NotFound();
            }

            var hasTrips = await _clientsService.ClientHasTripsAsync(idClient);
            if (hasTrips)
            {
                return BadRequest("Client cannot be deleted because they are assigned to one or more trips.");
            }

            await _clientsService.DeleteClientAsync(idClient);
            return NoContent();
        }
    }
}
