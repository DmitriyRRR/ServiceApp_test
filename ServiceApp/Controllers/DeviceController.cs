using Microsoft.AspNetCore.Mvc;
using ServiceApp.Database;
using ServiceApp.Database.Models;
using ServiceApp.Repository;

namespace ServiceApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly ServiceAppContext _context;
        private readonly IRepository<Device> _repository;

        public DeviceController(IRepository<Device> repository)
        {
            _repository = repository;
        }
        [HttpGet]
        [Route("devices")]
        public async Task<IActionResult> GetaAllDevices()
        {
            var devices = _repository.GetAllItems;

            if (devices == null)
            {
                return NotFound("Did not found any devices!");
            }

            return Ok(devices);
        }

    }
}
