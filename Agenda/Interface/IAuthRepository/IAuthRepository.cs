using Agenda.Dto.Request.AuthRequest;
using Agenda.Dto.Response.AuthResponse;

namespace Agenda.Interface.IAuthRepository
{
    public interface IAuthRepository
    {
        Task<AuthResponse> LoginAsync(LoginRequest request);
        Task<UsuarioResponse> RegisterClienteAsync(RegisterClienteRequest request);
        Task<UsuarioResponse> RegisterProfissionalAsync(RegisterRequest request);
        Task<UsuarioResponse> RegisterAdminEmpresa(RegisterRequest request);
    }
}
