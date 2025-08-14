using System;
using System.Collections.Generic;

namespace Agenda.Models;

public partial class Reagendamento
{
    public int ReagendamentoId { get; set; }

    public int? AgendamentoId { get; set; }

    public DateTime? DataHoraAntiga { get; set; }

    public DateTime? NovaDataHora { get; set; }

    public DateTime? DataReagendamento { get; set; }

    public virtual Agendamento? Agendamento { get; set; }
}
