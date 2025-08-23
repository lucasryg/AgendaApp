using System;
using System.Collections.Generic;

namespace Agenda.Domain.Models;

public partial class Notificacao
{
    public int NotificacaoId { get; set; }

    public int? AgendamentoId { get; set; }

    public string? Tipo { get; set; }

    public DateTime? EnviadoEm { get; set; }

    public string? StatusEnvio { get; set; }

    public virtual Agendamento? Agendamento { get; set; }
}
