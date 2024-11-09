using System;
using System.Collections.Generic;

namespace ToritosSAC.Entities;

public partial class Modelo
{
    public int IdModeloVehiculoI { get; set; }

    public int IdMarcaI { get; set; }

    public string NombreNv { get; set; } = null!;

    public string TipoC { get; set; } = null!;

    public decimal? PrecioUnidadVehiculoM { get; set; }

    public virtual ICollection<Grupo> Grupos { get; } = new List<Grupo>();

    public virtual Marca IdMarcaINavigation { get; set; } = null!;

    public virtual ICollection<Vehiculo> Vehiculos { get; } = new List<Vehiculo>();
}
