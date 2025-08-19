using Agenda.Dto;
using Agenda.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        private readonly IGenericService<Servico> _service;

        public ServicoController(IGenericService<Servico> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var servico = await _service.GetAllAsync();

            return Ok(servico);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var servico = await _service.GetByIdAsync(id);
            if (servico == null) return NotFound();

            return Ok(servico);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Servico servico)
        {

            var created = await _service.AddAsync(servico);
            if (created == null)
                return BadRequest("Não foi possivel criar o serviço");

            return CreatedAtAction(nameof(GetById), new { id = created.ServicoId}, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Servico servico)
        {
            if (id != servico.ServicoId) return BadRequest();

            var updated = await _service.UpdateAsync(servico);
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
