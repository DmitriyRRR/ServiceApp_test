using Microsoft.AspNetCore.Mvc;
using ServiceApp.Models;
using System.Text.Json;

namespace ServiceApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ServiceAppContext _context;
        public ClientController(ServiceAppContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("clients")]
        public async Task<IActionResult> GetAllClients()
        {
            bool isClients = _context.Clients.Any();
            if (isClients)
            {
                var clients = _context.Clients.ToList();
                return Ok(clients);
            }
            else
            {
                return NotFound("Did not found any clients!");
            }
        }
    }
}
