using System;
using System.Collections.Generic;

namespace ToritosSAC.Entities;

public partial class Distrito
{
    public string IdDistritoC { get; set; } = null!;

    public string IdProvinciaC { get; set; } = null!;

    public string NombreNv { get; set; } = null!;

    public virtual ICollection<Cliente> Clientes { get; } = new List<Cliente>();

    public virtual Provincium IdProvinciaCNavigation { get; set; } = null!;
}
