namespace Agenda.Application.Dto
{
    public class ClienteDto
    {
        public int ClienteId { get; set; }
        public string? Nome { get; set; }

        public string? Telefone { get; set; }
    }

    public class ClienteCreateDto
    {
        public string? Nome { get; set; }

        public string? Telefone { get; set; }
    }

    public class ClienteUpdateDto
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
    }
}