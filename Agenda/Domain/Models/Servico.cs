using System;
using System.Collections.Generic;

namespace Agenda.Domain.Models;

public partial class Servico
{
    public int ServicoId { get; set; }

    public string? Nome { get; set; }

    public int? DuracaoMinutos { get; set; }

    public int? Valor { get; set; }

    public int? EmpresaId { get; set; }

    public virtual ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();

    public virtual Empresa? Empresa { get; set; }
}
