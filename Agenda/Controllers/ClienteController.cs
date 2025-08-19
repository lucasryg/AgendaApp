using Agenda.Dto;
using Agenda.Dto.Response.ClienteResponse;
using Agenda.Models;
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

    [HttpPost]
    public async Task<IActionResult> Create(ClienteCreateDto cliente)
    {
        var map = _mapper.Map<Cliente>(cliente);

        var created = await _service.AddAsync(map);

        var response = _mapper.Map<ClienteDto>(created);

        return CreatedAtAction(nameof(GetById), new { id = response.ClienteId }, response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Cliente cliente)
    {
        if (id != cliente.ClienteId) return BadRequest();

        var updated = await _service.UpdateAsync(cliente);
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
