using System;
using System.Collections.Generic;

namespace ToritosSAC.Entities;

public partial class CronogramaGrupo
{
    public int IdCronogramaGrupoI { get; set; }

    public int IdGrupoI { get; set; }

    public DateTime FechaD { get; set; }

    public decimal CuotaIndividualN { get; set; }

    public decimal CuotaGrupalN { get; set; }

    public bool HabilitarSorteoB { get; set; }

    public bool HabilitarMartillazoB { get; set; }

    public virtual Grupo IdGrupoINavigation { get; set; } = null!;
}
