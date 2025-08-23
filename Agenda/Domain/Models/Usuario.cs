using System;
using System.Collections.Generic;

namespace Agenda.Domain.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string Email { get; set; } = null!;

    public string SenhaHash { get; set; } = null!;

    public string Role { get; set; } = null!;

    public int EmpresaId { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual Empresa Empresa { get; set; } = null!;

    public virtual Profissional? Profissional { get; set; }
}
