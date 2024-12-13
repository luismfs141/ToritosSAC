using System;
using System.Collections.Generic;

namespace ToritosSAC.Entities;

public partial class Usuario
{
    public int IdUsuarioI { get; set; }

    public int IdRolI { get; set; }

    public string NombreV { get; set; } = null!;

    public string TipoDocumentoC { get; set; } = null!;

    public string NroDocumentoV { get; set; } = null!;

    public string DireccionV { get; set; } = null!;

    public string TelefonoC { get; set; } = null!;

    public string CorreoV { get; set; } = null!;

    public byte[] ClaveVb { get; set; } = null!;

    public string EstadoC { get; set; } = null!;

    public virtual Rol IdRolINavigation { get; set; } = null!;
}
public class EUsuarioTipoDocumento
{
    public string NombreV { get; set; }
    public string CodigoC { get; set; }
}
public class ELogin
{
    public int IdUsuarioI { get; set; }
    public int IdRolI { get; set; }
    //public string RolNombre { get; set; }
    public string UsuarioNombreV { get; set; }
    public bool EstadoC { get; set; }
}
