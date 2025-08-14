namespace Agenda.Dto.Request.AuthRequest
{
    public class RegisterRequest
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public int? EmpresaId { get; set; } // Pode ser nulo para Admin
        public string? ImgPerfil { get; set; } // Somente para profissional
    }
}