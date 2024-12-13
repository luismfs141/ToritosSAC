using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ToritosSAC.Entities;

public partial class Modelo
{
    public int IdModeloVehiculoI { get; set; }

    public int IdMarcaI { get; set; }

    public string NombreNv { get; set; } = null!;

    public string TipoC { get; set; } = null!;

    public decimal? PrecioUnidadVehiculoM { get; set; }
    public string EstadoC { get; set; } = null!;

    public virtual ICollection<Grupo> Grupos { get; } = new List<Grupo>();
    [JsonIgnore]
    public virtual Marca IdMarcaINavigation { get; set; } = null!;

    public virtual ICollection<Vehiculo> Vehiculos { get; } = new List<Vehiculo>();
}
