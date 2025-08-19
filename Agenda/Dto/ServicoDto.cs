using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Agenda.Dto
{
    public class ServicoDto
    {
        public int ServicoId { get;set; }
        public string Nome { get; set; }
        public int DuracaoMinutos { get; set; }
        public int Valor { get; set; }
        public int EmpresaId { get; set; }
    }
}
