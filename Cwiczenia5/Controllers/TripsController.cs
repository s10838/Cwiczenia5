using Microsoft.AspNetCore.Mvc;
using Cwiczenia5.Services;
using Cwiczenia5.Models;
using Cwiczenia5.DTO;

namespace Cwiczenia5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TripsController : ControllerBase
    {
        private readonly ITripsService _tripsService;
        private readonly IClientsService _clientsService;

        public TripsController(ITripsService tripsService, IClientsService clientsService)
        {
            _tripsService = tripsService;
            _clientsService = clientsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTrips()
        {
            var trips = await _tripsService.GetTripsAsync();
            return Ok(trips);
        }

        [HttpPost("{idTrip}/clients")]
        public async Task<IActionResult> AssignClientToTrip(int idTrip, [FromBody] AddClientToTripDto addClientToTripDto)
        {
            if (idTrip != addClientToTripDto.IdTrip)
            {
                return BadRequest("Trip ID in URL does not match Trip ID in body.");
            }

            var tripExists = await _tripsService.TripExistsAsync(idTrip);
            if (!tripExists)
            {
                return NotFound("Trip not found.");
            }

            var client = await _clientsService.GetClientByPeselAsync(addClientToTripDto.Pesel);
            if (client == null)
            {
                client = new Client
                {
                    FirstName = addClientToTripDto.FirstName,
                    LastName = addClientToTripDto.LastName,
                    Email = addClientToTripDto.Email,
                    Telephone = addClientToTripDto.Telephone,
                    Pesel = addClientToTripDto.Pesel
                };
                await _clientsService.AddClientAsync(client);
            }

            var isClientAssigned = await _tripsService.IsClientAssignedToTripAsync(client.IdClient, idTrip);
            if (isClientAssigned)
            {
                return BadRequest("Client is already assigned to this trip.");
            }

            var clientTrip = new ClientTrip
            {
                IdClient = client.IdClient,
                IdTrip = idTrip,
                RegisteredAt = DateTime.UtcNow,
                PaymentDate = addClientToTripDto.PaymentDate
            };

            await _tripsService.AssignClientToTripAsync(clientTrip);
            return CreatedAtAction(nameof(GetTrips), new { idTrip = idTrip }, clientTrip);
        }
    }
}
