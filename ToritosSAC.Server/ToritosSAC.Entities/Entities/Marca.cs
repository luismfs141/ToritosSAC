using System;
using System.Collections.Generic;

namespace ToritosSAC.Entities;

public partial class Marca
{
    public int IdMarcaI { get; set; }

    public string NombreNv { get; set; } = null!;

    public string? SitioWebNv { get; set; }

    public string EstadoC { get; set; } = null!;

    public virtual ICollection<Modelo> Modelos { get; } = new List<Modelo>();
}
