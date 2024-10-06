﻿using Microsoft.AspNetCore.Mvc;
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
            var clients = _context.Clients.ToList();
            return Ok(clients);
        }

        [HttpGet]
        [Route("client")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = _context.Clients.FirstOrDefault(c => c.Id == id);
            if (client is null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task DeleteClientAsync(int id)
        {
            _repository.DeleteAsync(id);
            _repository.SaveAsync();
        }
    }
}
