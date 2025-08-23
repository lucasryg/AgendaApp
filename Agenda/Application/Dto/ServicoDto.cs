using Agenda.Domain.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Agenda.Application.Dto
{
    public class ServicoDto
    {
        public int ServicoId { get;set; }
        public string Nome { get; set; }
        public int DuracaoMinutos { get; set; }
        public int Valor { get; set; }
        public int EmpresaId { get; set; }
    }

    public class ServicoCreate
    {
        public string? Nome { get; set; }

        public int? DuracaoMinutos { get; set; }

        public int? Valor { get; set; }

        public int? EmpresaId { get; set; }
    }
    public class ServicoUpdate
    {
        public int ServicoId { get; set; }

        public string? Nome { get; set; }

        public int? DuracaoMinutos { get; set; }

        public int? Valor { get; set; }

        public int? EmpresaId { get; set; }
    }

}
