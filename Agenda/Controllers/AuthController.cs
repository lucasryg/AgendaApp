
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

        //[HttpPost("login")]
        //public async Task<IActionResult> Login([FromBody] UsuarioDto Input)
        //{
        //    var token = await _authRepo.LoginAsync(Input.Email, Input.SenhaHash);

        //    if (token == null)
        //        return Unauthorized("Email ou senha inválidos");

        //    return Ok(new { Token = token });
        //}

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var result = await _authRepository.LoginAsync(request);
            if (result == null)
                return Unauthorized(new { message = "Credenciais inválidas" });

            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
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
    }
}