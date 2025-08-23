using Agenda.Domain.Models;
using Agenda.Application.Dto;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Agenda.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfissionalController : ControllerBase
    {
        private readonly IGenericService<Profissional> _service;
        private readonly IMapper _mapper;

        public ProfissionalController(IGenericService<Profissional> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var profissional = await _service.GetAllAsync();

            var map = _mapper.Map<IEnumerable<ProfissionalDto>>(profissional);

            return Ok(profissional);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var profissional = await _service.GetByIdAsync(id);
            if (profissional == null) return NotFound();
            var map = _mapper.Map<ProfissionalDto>(profissional);

            return Ok(map);
        }

        //[HttpPost]
        //public async Task<IActionResult> Create(Profissional profissional)
        //{

        //    var created = await _service.AddAsync(profissional);
        //    if (created == null)
        //        return BadRequest("Não foi possivel criar o serviço");

        //    return CreatedAtAction(nameof(GetById), new { id = created.ProfissionalId }, created);
        //}

        [HttpPut]
        public async Task<IActionResult> Update(int id, ProfissionalUpdate profissional)
        {
            if (id != profissional.ProfissionalId) return BadRequest();

            var map = _mapper.Map<Profissional>(profissional);

            var updated = await _service.UpdateAsync(map);

            var response = _mapper.Map<ProfissionalDto>(updated);

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