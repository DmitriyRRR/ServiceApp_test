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
        public ClientController(IRepository<Client> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("clients")]
        public async Task<IActionResult> GetAllClients()
        {
            var clients = _repository.GetAll();
            if (clients is null)
            {
                return NotFound();
            }
            return Ok(clients);
        }

        [HttpGet]
        [Route("client")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = _repository.GetById(id);
            if (client is null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateClient(Client client)
        {
            _repository.Update(client);
            _repository.Save();
            return Ok(client);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task DeleteClientAsync(int id)
        {
            Client? client = _repository.GetById(id);
            _repository.Delete(client);
            _repository.Save();
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddClientAsync(Client client)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(new Client
                {
                    Name = client.Name
                });
                await _context.SaveChangesAsync();
            }
            return Ok(client);
        }
    }
}
