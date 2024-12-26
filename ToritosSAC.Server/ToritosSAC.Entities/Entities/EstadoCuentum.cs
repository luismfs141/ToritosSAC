using System;
using System.Collections.Generic;

namespace ToritosSAC.Entities;

public partial class EstadoCuentum
{
    public int IdEstadoCuentaI { get; set; }

    public int IdDetalleGrupoI { get; set; }

    public decimal MontoRecaudadoN { get; set; }

    public DateTime? FechaAperturaD { get; set; }

    public DateTime? FechaCierreD { get; set; }

    public string? MotivoCierreC { get; set; }

    public virtual ICollection<DetalleEstadoCuentum> DetalleEstadoCuenta { get; } = new List<DetalleEstadoCuentum>();

    public virtual DetalleGrupo IdDetalleGrupoINavigation { get; set; } = null!;
}
