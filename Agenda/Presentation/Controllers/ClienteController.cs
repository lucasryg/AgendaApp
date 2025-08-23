using Agenda.Application.Dto;
using Agenda.Domain.Models;
using Agenda.Application.Dto.Response.ClienteResponse;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
    private readonly IGenericService<Cliente> _service;
    private readonly IMapper _mapper;

    public ClienteController(IGenericService<Cliente> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var clientes = await _service.GetAllAsync();

        var map = _mapper.Map<IEnumerable<ClienteDto>>(clientes);

        return Ok(map);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var cliente = await _service.GetByIdAsync(id);
        if (cliente == null) return NotFound();
        var map = _mapper.Map<ClienteDto>(cliente);
        return Ok(map);
    }

    //[HttpPost]
    //public async Task<IActionResult> Create(ClienteCreateDto cliente)
    //{
    //    var map = _mapper.Map<Cliente>(cliente);

    //    var created = await _service.AddAsync(map);

    //    var response = _mapper.Map<ClienteDto>(created);

    //    return CreatedAtAction(nameof(GetById), new { id = response.ClienteId }, response);
    //}

    [HttpPut]
    public async Task<IActionResult> Update(int id, ClienteUpdateDto cliente)
    {
        if (id != cliente.ClienteId) return BadRequest();

        var map = _mapper.Map<Cliente>(cliente);

        var updated = await _service.UpdateAsync(map);

        var response =  _mapper.Map<ClienteDto>(updated);

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
