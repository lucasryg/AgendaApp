using Agenda.Application.Dto.Request.AuthRequest;
using Agenda.Application.Dto.Response.AuthResponse;

namespace Agenda.Application.Interface.IAuthRepository
{
    public interface IAuthRepository
    {
        Task<AuthResponse> LoginAsync(LoginRequest request);
        Task<UsuarioResponse> RegisterClienteAsync(RegisterClienteRequest request);
        Task<UsuarioResponse> RegisterProfissionalAsync(RegisterRequest request);
        Task<UsuarioResponse> RegisterAdminEmpresa(RegisterRequest request);
    }
}
