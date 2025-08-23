namespace Agenda.Application.Dto.Request.AuthRequest
{
    public class RegisterClienteRequest
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
    }
}