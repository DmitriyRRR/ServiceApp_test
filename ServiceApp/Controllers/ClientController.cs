using Microsoft.AspNetCore.Mvc;
using ServiceApp.Models;
using System.Text.Json;

namespace ServiceApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController: ControllerBase
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
            if (_context.Clients.Any())
            {
                var clients = _context.Clients.ToList();
                return (IActionResult)clients;
            }
            else
            {
                return NotFound("No found any clients");
            }
        }
    }
}
