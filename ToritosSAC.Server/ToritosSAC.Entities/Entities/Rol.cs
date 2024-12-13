using System;
using System.Collections.Generic;
using ToritosSAC.Entities.Entities.Mod;

namespace ToritosSAC.Entities;

public partial class Rol
{
    public int IdRolI { get; set; }

    public string NombreV { get; set; } = null!;

    public string? DescripcionV { get; set; }

    public string EstadoC { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
}
