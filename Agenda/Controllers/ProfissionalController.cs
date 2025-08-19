using Agenda.Dto;
using Agenda.Models;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfissionalController : ControllerBase
    {
        private readonly IGenericService<Profissional> _service;

        public ProfissionalController(IGenericService<Profissional> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var profissional = await _service.GetAllAsync();

            return Ok(profissional);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var profissional = await _service.GetByIdAsync(id);
            if (profissional == null) return NotFound();

            return Ok(profissional);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Profissional profissional)
        {

            var created = await _service.AddAsync(profissional);
            if (created == null)
                return BadRequest("Não foi possivel criar o serviço");

            return CreatedAtAction(nameof(GetById), new { id = created.ProfissionalId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Profissional profissional)
        {
            if (id != profissional.ProfissionalId) return BadRequest();

            var updated = await _service.UpdateAsync(profissional);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
