using System;
using System.Collections.Generic;

namespace Agenda.Models;

public partial class Profissional
{
    public int ProfissionalId { get; set; }

    public string? Nome { get; set; }

    public string? ImgPerfil { get; set; }

    public string? Telefone { get; set; }

    public int UsuarioId { get; set; }

    public virtual ICollection<Agendum> Agenda { get; set; } = new List<Agendum>();

    public virtual ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();

    public virtual Usuario Usuario { get; set; } = null!;
}
