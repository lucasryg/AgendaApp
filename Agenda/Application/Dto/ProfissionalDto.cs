namespace Agenda.Application.Dto
{
    public class ProfissionalDto
    {
        public int ProfissionalId { get; set; }
        public string? Nome { get; set; }
        public int UsuarioId { get; set; }
    }

    public class ProfissionalUpdate
    {
        public int ProfissionalId { get; set; }
        public string? Nome { get; set; }
    }
}