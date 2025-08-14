using System;
using System.Collections.Generic;

namespace Agenda.Models;

public partial class AdminEmpresa
{
    public int AdminEmpresaId { get; set; }

    public string? Nome { get; set; }

    public string? Telefone { get; set; }

    public int EmpresaId { get; set; }

    public int UsuarioId { get; set; }
}
