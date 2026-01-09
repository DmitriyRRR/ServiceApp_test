using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
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
        private readonly IRepository<Client> _repository;
        private readonly ServiceAppContext _context;

        public ClientController(IRepository<Client> repository, ServiceAppContext context)
        {
            _repository = repository;
            _context = context;
        }

        [HttpGet]
        [Route("clients")]
        public async Task<IActionResult> GetAllClients()
        {
            var clients =await _context.Clients.Include(c=>c.Devices).ToListAsync();
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
            // Client? client = await _repository.GetByIdAsync(id);
            Client? client = await _context.Clients.Include(c=>c.Devices).FirstOrDefaultAsync();
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
                _repository.Insert(new Client
                {
                    Name = client.Name
                });
                await _repository.SaveAsync();
                return Ok(client);
            }
            else
            {
                return BadRequest("Add did not complete");
            }
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateClient(Client client)
        {
            _repository.Update(client);
            await _repository.SaveAsync();
            return Ok(client);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            Client? client =await _repository.GetByIdAsync(id);
            if (client!= null)
            {
                _repository.Delete(client);
                await _repository.SaveAsync();
                return Ok();
            }
            else
            {
                return BadRequest("Delete problem");
            }
        }
    }
}
