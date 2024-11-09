using System;
using System.Collections.Generic;

namespace ToritosSAC.Entities;

public partial class Vehiculo
{
    public int IdVehiculoI { get; set; }

    public int IdModeloVehiculoI { get; set; }

    public int IdProveedorI { get; set; }

    public string SerieNv { get; set; } = null!;

    public string PlacaC { get; set; } = null!;

    public DateTime AnioFabricacionD { get; set; }

    public decimal? PrecioCompraVehiculoM { get; set; }

    public string ColorC { get; set; } = null!;

    public DateTime FechaIngresoD { get; set; }

    public string EstadoC { get; set; } = null!;

    public virtual ICollection<Asignacion> Asignacions { get; } = new List<Asignacion>();

    public virtual Modelo IdModeloVehiculoINavigation { get; set; } = null!;

    public virtual Proveedor IdProveedorINavigation { get; set; } = null!;
}
