using Agenda.Data;
using Agenda.Dto.Request.AuthRequest;
using Agenda.Dto.Response.AuthResponse;
using Agenda.Interface.IAuthRepository;
using Agenda.Models;
using Agenda.Token;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AgendaAppContext _context;
        private readonly TokenJwt _jwt;
        private readonly Mapper _mapper;


        public AuthRepository(AgendaAppContext context, TokenJwt jwt, Mapper mapper)
        {
            _context = context;
            _jwt = jwt;
            _mapper = mapper;
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            var usuario = await _context.Usuarios
            .FirstOrDefaultAsync(x => x.Email == request.Email);

            if (usuario == null || !PasswordHelper.VerifyPassword(request.Senha, usuario.SenhaHash))
                return null;

            var token = _jwt.GenerateToken(usuario.Email, usuario.Role);

            return new AuthResponse
            {
                Token = token,
                Usuario = new UsuarioResponse
                {
                    Id = usuario.UsuarioId,
                    Email = usuario.Email
                }
            };
        }

        public async Task<UsuarioResponse> RegisterAdminEmpresa(RegisterRequest request)
        {

            if (await _context.Usuarios.AnyAsync(u => u.Email == request.Email))
                return null;

            var usuario = new Usuario
            {
                Email = request.Email,
                SenhaHash = PasswordHelper.HashPassword(request.Senha),
                Role = "AdminEmpresa",
                EmpresaId = 1
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            var adminEmpresa = new AdminEmpresa
            {
                Nome = request.Nome,
                Telefone = request.Telefone,
                UsuarioId = usuario.UsuarioId,
                EmpresaId = usuario.EmpresaId
            };
            _context.AdminEmpresa.Add(adminEmpresa);
            await _context.SaveChangesAsync();

            return new UsuarioResponse
            {
                Nome = adminEmpresa.Nome,
                Email = usuario.Email
            };
        }

        public async Task<UsuarioResponse> RegisterClienteAsync(RegisterClienteRequest request)
        {

            if (await _context.Usuarios.AnyAsync(x => x.Email == request.Email))
                return null;


            var usuario = new Usuario
            {
                Email = request.Email,
                SenhaHash = PasswordHelper.HashPassword(request.Senha),
                EmpresaId = 1,
                Role = "Cliente"
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            var cliente = new Cliente
            {
                Nome = request.Nome,
                Telefone = request.Telefone,
                UsuarioId = usuario.UsuarioId
            };
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();


            return new UsuarioResponse
            {
                Nome = cliente.Nome,
                Email = usuario.Email
            };
        }

        public async Task<UsuarioResponse> RegisterProfissionalAsync(RegisterRequest request)
        {
            if (await _context.Usuarios.AnyAsync(x => x.Email == request.Email))
                return null;

            var usuario = new Usuario
            {
                Email = request.Email,
                SenhaHash = PasswordHelper.HashPassword(request.Senha),
                EmpresaId = 1,
                Role = "Profissional"
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            var profissional = new Profissional
            {
                Nome = request.Nome,
                Telefone = request.Telefone,
                ImgPerfil = request.ImgPerfil ?? "",
                UsuarioId = usuario.UsuarioId
            };


            _context.Profissionals.Add(profissional);
            await _context.SaveChangesAsync();

            return new UsuarioResponse
            {
                Id = profissional.UsuarioId,
                Email = usuario.Email,
            };
        }
    }
}