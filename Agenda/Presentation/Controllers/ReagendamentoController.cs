using Agenda.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReagendamentoController : ControllerBase
    {
        private readonly IGenericService<Reagendamento> _service;

        public ReagendamentoController(IGenericService<Reagendamento> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reage = await _service.GetAllAsync();

            return Ok(reage);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var reage = await _service.GetByIdAsync(id);
            if (reage == null) return NotFound();

            return Ok(reage);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Reagendamento reage)
        {

            var created = await _service.AddAsync(reage);
            if (created == null)
                return BadRequest("Não foi possivel criar o serviço");

            return CreatedAtAction(nameof(GetById), new { id = created.ReagendamentoId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Reagendamento reage)
        {
            if (id != reage.ReagendamentoId) return BadRequest();

            var updated = await _service.UpdateAsync(reage);
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
