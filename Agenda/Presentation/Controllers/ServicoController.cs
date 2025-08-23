using Agenda.Domain.Models;
using Agenda.Application.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace Agenda.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        private readonly IGenericService<Servico> _service;
        private readonly IMapper _mapper;
        public ServicoController(IGenericService<Servico> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var servico = await _service.GetAllAsync();

            var map = _mapper.Map<ServicoDto>(servico);

            return Ok(map);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var servico = await _service.GetByIdAsync(id);
            var map = _mapper.Map<ServicoDto>(servico);
            if (servico == null) return NotFound();

            return Ok(map);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ServicoCreate servico)
        {
            var map = _mapper.Map<Servico>(servico);

            var created = await _service.AddAsync(map);

            if (created == null)
                return BadRequest("Não foi possivel criar o serviço");

            var response = _mapper.Map<ServicoDto>(created);

            return CreatedAtAction(nameof(GetById), new { id = created.ServicoId}, response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, ServicoUpdate servico)
        {
            if (id != servico.ServicoId) return BadRequest();

            var map = _mapper.Map<Servico>(servico);

            var updated = await _service.UpdateAsync(map);

            var response = _mapper.Map<ServicoDto>(updated);

            return Ok(response);
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