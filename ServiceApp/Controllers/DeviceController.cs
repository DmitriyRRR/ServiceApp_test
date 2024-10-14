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
            var devices = _repository.GetAll();
            if (devices != null)
            {
                return Ok(devices);
            }
            else
            {
                return NotFound("Did not found any clients!");
            }
        }

        [HttpGet]
        [Route("device")]
        public async Task<IActionResult> GerDeviceById(int id)
        {
            Device? device = _repository.GetById(id);
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
                _repository.Save();
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
                _repository.Save();
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
            Device device = _repository.GetById(id);
            if (device != null)
            {
                _repository.Delete(device);
                _repository.Save();
            return Ok();
            }
            else
            {
                return BadRequest("Delte problem");
            }
        }

    }
}
