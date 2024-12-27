using System;
using System.Collections.Generic;

namespace ToritosSAC.Entities;

public partial class Cuotum
{
    public int IdCuotaI { get; set; }

    public int IdDetalleGrupo { get; set; }

    public int NumCuotaI { get; set; }

    public decimal MontoCuotaN { get; set; }

    public DateTime FechaInicioD { get; set; }

    public DateTime FechaFinD { get; set; }

    public string EstadoCuotaC { get; set; } = null!;

    public decimal PenalidadN { get; set; }

    public virtual DetalleGrupo IdDetalleGrupoNavigation { get; set; } = null!;
}
