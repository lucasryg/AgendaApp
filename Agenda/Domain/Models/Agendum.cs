using System;
using System.Collections.Generic;

namespace Agenda.Domain.Models;

public partial class Agendum
{
    public int AgendaId { get; set; }

    public int? ProfissionalId { get; set; }

    public DateTime? DataHoraInicio { get; set; }

    public DateTime? DataHoraFim { get; set; }

    public bool? Disponivel { get; set; }

    public virtual Profissional? Profissional { get; set; }
}
