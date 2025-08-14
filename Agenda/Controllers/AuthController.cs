
using Agenda.Dto;
using Agenda.Dto.Request.AuthRequest;
using Agenda.Interface.IAuthRepository;
using Agenda.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Agenda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
 
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var result = await _authRepository.LoginAsync(request);
            if (result == null)
                return Unauthorized(new { message = "Credenciais inválidas" });

            return Ok(result);
        }

        [Authorize(Roles = "Admin, AdminEmpresa")]
        [HttpPost("register-profissional")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var result = await _authRepository.RegisterProfissionalAsync(request);
            if (result == null)
                return BadRequest(new { message = "Email já registrado" });

            return Ok(result);
        }

        [HttpPost("register-cliente")]
        public async Task<IActionResult> RegisterCliente(RegisterClienteRequest request)
        {
            var result = await _authRepository.RegisterClienteAsync(request);
            if (result == null)
                return BadRequest(new { message = "Email já registrado" });

            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("register-admin-empresa")]
        public async Task<IActionResult> RegisterAdminEmpresa(RegisterRequest request)
        {
            var result = await _authRepository.RegisterAdminEmpresa(request);
            if (result == null)
                return BadRequest(new { message = "Email já registrado" });

            return Ok(result);
        }
    }
}