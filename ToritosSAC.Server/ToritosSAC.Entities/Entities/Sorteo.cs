using System;
using System.Collections.Generic;

namespace ToritosSAC.Entities;

public partial class Sorteo
{
    public int IdSorteoI { get; set; }

    public int IdDetalleGrupoI { get; set; }

    public DateTime FechaD { get; set; }

    public string TipoSorteoC { get; set; } = null!;

    public virtual ICollection<Asignacion> Asignacions { get; } = new List<Asignacion>();

    public virtual DetalleGrupo IdDetalleGrupoINavigation { get; set; } = null!;
}
