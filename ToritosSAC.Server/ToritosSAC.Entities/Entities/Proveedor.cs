using System;
using System.Collections.Generic;

namespace ToritosSAC.Entities;

public partial class Proveedor
{
    public int IdProveedorI { get; set; }

    public string NombreNv { get; set; } = null!;

    public string ContactoV { get; set; } = null!;

    public string CargoContactoNv { get; set; } = null!;

    public string DireccionNv { get; set; } = null!;

    public string IdPaisI { get; set; } = null!;
    
    public string EstadoC { get; set; } = null!;

    public virtual Pai IdPaisINavigation { get; set; } = null!;

    public virtual ICollection<Vehiculo> Vehiculos { get; } = new List<Vehiculo>();
}
