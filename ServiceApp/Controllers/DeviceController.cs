using Microsoft.AspNetCore.Mvc;
using ServiceApp.Database;

namespace ServiceApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceController: ControllerBase
    {
        private readonly ServiceAppContext _context;

        public DeviceController(ServiceAppContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("devices")]
        public async Task<IActionResult> GetaAllDevices()
        {
            bool isDevice = _context.Devices.Any();
            if (isDevice)
            {
                var devices = _context.Clients.ToList();
                return Ok(devices);
            }
            else
            {
                return NotFound("Did not found any clients!");
            }
        }

    }
}
