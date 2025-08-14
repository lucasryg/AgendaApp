using System;
using System.Collections.Generic;

namespace Agenda.Models;

public partial class Empresa
{
    public int EmpresaId { get; set; }

    public string? Nome { get; set; }

    public string? LogoUrl { get; set; }

    public string? CorPrimaria { get; set; }

    public string? CorSecundaria { get; set; }

    public virtual ICollection<Servico> Servicos { get; set; } = new List<Servico>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
