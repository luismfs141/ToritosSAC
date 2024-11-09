using System;
using System.Collections.Generic;

namespace ToritosSAC.Entities;

public partial class Grupo
{
    public int IdGrupoI { get; set; }

    public string CodigoC { get; set; } = null!;

    public int IdModeloVehiculoI { get; set; }

    public decimal PrecioUnidadVehiculoM { get; set; }

    public DateTime? FechaCreacionD { get; set; }

    public int CantMaxIntegrantesI { get; set; }

    public DateTime? FechaInicioPanderoD { get; set; }

    public string EstadoC { get; set; } = null!;

    public int CantidadCuotasI { get; set; }

    public decimal PenalidadDc { get; set; }

    public string TipoPeriodoPagoC { get; set; } = null!;

    public virtual ICollection<DetalleGrupo> DetalleGrupos { get; } = new List<DetalleGrupo>();

    public virtual Modelo IdModeloVehiculoINavigation { get; set; } = null!;
}
