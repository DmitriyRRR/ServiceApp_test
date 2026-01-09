using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceApp.Database;
using ServiceApp.Database.Models;
using ServiceApp.Repository;

namespace ServiceApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly IRepository<Device> _repository;
        private readonly IRepository<Part> _partsRepo;
        private readonly ServiceAppContext _context;

        public DeviceController(IRepository<Device> repository, IRepository<Part> parts, ServiceAppContext context)
        {
            _repository = repository;
            _partsRepo = parts;
            _context = context;
        }

        [HttpGet]
        [Route("devices")]
        public async Task<IActionResult> GetaAllDevices()
        {
            //var devices = await _repository.GetAllAsync();
            List<Device>? devices = await _context.Devices.Include(p => p.Parts).ToListAsync();

            if (devices != null)
            {
                return Ok(devices);
            }
            else
            {
                return NotFound("Did not found any devices!");
            }
        }

        [HttpGet]
        [Route("device")]
        public async Task<IActionResult> GerDeviceById(int id)
        {
            Device? device = await _context.Devices.Include(p => p.Parts).FirstOrDefaultAsync(d => d.Id == id);
            if (device != null)
            {
                return Ok(device);
            }
            return BadRequest($"Device {id} did not found");
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddDevice(Device device)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(device);
                await _repository.SaveAsync();
                return Ok(device);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update(Device device)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(device);
                await _repository.SaveAsync();
                return Ok(device);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            Device? device = _repository.GetById(id);
            if (device != null)
            {
                _repository.Delete(device);
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
