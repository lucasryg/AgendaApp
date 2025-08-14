using System;
using System.Collections.Generic;

namespace Agenda.Models;

public partial class Agendamento
{
    public int AgendamentoId { get; set; }

    public int? ClienteId { get; set; }

    public int? ProfissionalId { get; set; }

    public int? ServicoId { get; set; }

    public DateTime? DataHora { get; set; }

    public string? Status { get; set; }

    public string? Observacoes { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<Notificacao> Notificacaos { get; set; } = new List<Notificacao>();

    public virtual Profissional? Profissional { get; set; }

    public virtual ICollection<Reagendamento> Reagendamentos { get; set; } = new List<Reagendamento>();

    public virtual Servico? Servico { get; set; }
}
