using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceApp.Database.Models;
using ServiceApp.Repository;
namespace ServiceApp.Controllers
{
    public class PartController : ControllerBase
    {
        private readonly IRepository<Part> _repository;

        public PartController(IRepository<Part> repository)
        {
            _repository = repository;
        }
        [HttpGet]
        [Route("parts")]
        public async Task<IActionResult> GetAllParts()
        {
            var parts = await _repository.GetAllAsync();
            if (parts.Any())
            {
                return Ok(parts);
            }
            else
            {
                return NotFound("No parts in the list");
            }
        }

        [HttpGet]
        [Route("part")]
        public async Task<IActionResult> GetPartById(int id)
        {
            Part? part = await _repository.GetByIdAsync(id);
            if (part == null)
            {
                return NotFound();
            }
            return Ok(part);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddPart(Part part)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(new Part
                {
                    Name = part.Name,
                    Description = part.Description,
                    DeviceId = part.DeviceId
                });
                await _repository.SaveAsync();
                return Ok(part);
            }
            return BadRequest("Update problem");
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdatePart(Part part)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(part);
                await _repository.SaveAsync();
                return Ok(part);
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeletePart(int id)
        {
            if (id > 0)
            {
                Part? part = await _repository.GetByIdAsync(id);
                if (part != null)
                {
                    _repository.Delete(part);
                }
                else
                return BadRequest("delete problem");

            }
            return BadRequest("delete problem");
        }
    }
}
