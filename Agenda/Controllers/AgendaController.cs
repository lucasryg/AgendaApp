using Agenda.Models;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private readonly IGenericService<Agendum> _service;
        
        public AgendaController(IGenericService<Agendum> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var agenda = await _service.GetAllAsync();

            return Ok(agenda);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var agenda = await _service.GetByIdAsync(id);
            if (agenda == null) return NotFound();

            return Ok(agenda);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Agendum agenda)
        {

            var created = await _service.AddAsync(agenda);
            if (created == null)
                return BadRequest("Não foi possivel criar o serviço");

            return CreatedAtAction(nameof(GetById), new { id = created.AgendaId}, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Agendum agenda)
        {
            if (id != agenda.AgendaId) return BadRequest();

            var updated = await _service.UpdateAsync(agenda);
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