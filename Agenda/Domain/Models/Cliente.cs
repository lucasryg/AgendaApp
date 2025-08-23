using System;
using System.Collections.Generic;

namespace Agenda.Domain.Models;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public string? Nome { get; set; }

    public string? Telefone { get; set; }

    public int UsuarioId { get; set; }

    public virtual ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();

    public virtual Usuario Usuario { get; set; } = null!;
}
