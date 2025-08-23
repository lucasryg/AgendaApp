using Agenda.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly IGenericService<Agendamento> _service;
        private readonly IMapper _mapper;

        public AgendamentoController(IGenericService<Agendamento> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var agendamento = await _service.GetAllAsync();

            return Ok(agendamento);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var agendamento = await _service.GetByIdAsync(id);
            if (agendamento == null) return NotFound();

            return Ok(agendamento);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Agendamento agendamento)
        {

            var created = await _service.AddAsync(agendamento);
            if (created == null)
                return BadRequest("Não foi possivel criar o serviço");

            return CreatedAtAction(nameof(GetById), new { id = created.AgendamentoId}, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Agendamento agendamento)
        {
            if (id != agendamento.AgendamentoId) return BadRequest();

            var updated = await _service.UpdateAsync(agendamento);
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
