using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using ServiceApp.Database;
using ServiceApp.Database.Models;
using ServiceApp.Repository;
using System.Text.Json;

namespace ServiceApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ServiceAppContext _context;
        private readonly IRepository<Client> _repository;

        public ClientController(ServiceAppContext context, IRepository<Client> repository)
        {
            _context = context;
            _repository = repository;
        }

        [HttpGet]
        [Route("clients")]
        public async Task<IActionResult> GetAllClients()
        {
            var clients = _repository.GetAllItems;

            if (clients == null)
            {
                return NotFound("Did not found any devices!");
            }

            return Ok(clients);

        }

        [HttpGet]
        [Route("client")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = _repository.GetByIdAsynk(id);
            if (client is null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddClientAsync(Client client)
        {
            if (ModelState.IsValid)
            {
                await _repository.InsertAsync(new Client
                {
                    Name = client.Name
                });
                _repository.SaveAsync();
            }
            return Ok("added new client");
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteClientAsync(int id)
        {
            Client? client = await _repository.GetByIdAsynk(id);
            if (client is not null)
            {
                _repository.DeleteAsync(client);
                _repository.SaveAsync();
                return Ok();
            }
            return NotFound();
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateClientAsync(Client client)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateAsync(client);
                _repository.SaveAsync();
                return Ok("update completed");
            }
            else
            {
                return BadRequest("update ");
            }
        }
    }
}
