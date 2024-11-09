using System;
using System.Collections.Generic;

namespace ToritosSAC.Entities;

public partial class Asignacion
{
    public int IdAsignacionI { get; set; }

    public string TipoAsignacionC { get; set; } = null!;

    public DateTime FechaAsignacionD { get; set; }

    public DateTime? FechaEntregaVehiculoD { get; set; }

    public int IdVehiculoI { get; set; }

    public virtual ICollection<DetalleGrupo> DetalleGrupos { get; } = new List<DetalleGrupo>();

    public virtual Vehiculo IdVehiculoINavigation { get; set; } = null!;
}
