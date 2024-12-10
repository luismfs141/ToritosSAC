using System;
using System.Collections.Generic;

namespace ToritosSAC.Entities;

public partial class Cliente
{
    public int IdClienteI { get; set; }

    public string CodigoC { get; set; } = null!;

    public string NombreNv { get; set; } = null!;

    public string ApellidoPaternoNv { get; set; } = null!;

    public string ApellidoMaternoNv { get; set; } = null!;

    public string TipoDocumentoC { get; set; } = null!;

    public string NroDocumentoV { get; set; } = null!;

    public string SexoC { get; set; } = null!;

    public DateTime FechaNacimientoD { get; set; }

    public string EstadoCivilC { get; set; } = null!;

    public string NroContactoC { get; set; } = null!;

    public string CorreoNv { get; set; } = null!;

    public bool CorreoAutenticadoBo { get; set; }

    public string DireccionNv { get; set; } = null!;

    public string? DireccionRefNv { get; set; }

    public string IdDistritoC { get; set; } = null!;

    public byte[] PasswordBi { get; set; } = null!;

    public string EstadoC { get; set; } = null!;

    public DateTime? FechaInscripcionD { get; set; }

    public virtual ICollection<DetalleGrupo> DetalleGrupos { get; } = new List<DetalleGrupo>();

    public virtual Distrito? IdDistritoCNavigation { get; set; } = null!;
}
