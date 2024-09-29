using Microsoft.AspNetCore.Mvc;
using ServiceApp.Models;
using System.Text.Json;

namespace ServiceApp.Controllers
{
    public class ClientController: ControllerBase
    {
        private readonly ServiceAppContext _context;
        public ClientController(ServiceAppContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> GetAllClients()
        {
            if (_context.Clients.Any())
            {
                var clients = _context.Clients.ToList();
                return (IActionResult)clients;
            }
            else
            {
                return NotFound();
            }
        }
    }
}
