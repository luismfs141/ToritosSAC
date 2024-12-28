using System;
using System.Collections.Generic;

namespace ToritosSAC.Entities;

public partial class DetalleEstadoCuentum
{
    public int IdDetalleEstadoCuentaI { get; set; }

    public int IdEstadoCuentaI { get; set; }

    public int? ReferenciaOperacionI { get; set; }

    public string TipoOperacionC { get; set; } = null!;

    public decimal Monto { get; set; }

    public DateTime FechaPagoDt { get; set; }

    public string CodigoPagoV { get; set; } = null!;

    public virtual EstadoCuentum IdEstadoCuentaINavigation { get; set; } = null!;
}
