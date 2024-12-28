using System;
using System.Collections.Generic;

namespace ToritosSAC.Entities;

public partial class Pago
{
    public int IdPagoI { get; set; }

    public int IdClienteI { get; set; }

    public string CodigoPagoV { get; set; } = null!;

    public string ConceptoC { get; set; } = null!;

    public decimal MontoPagoN { get; set; }

    public DateTime FechaPagoD { get; set; }

    public string OpcionPagoC { get; set; } = null!;

    public virtual Cliente? IdClienteINavigation { get; set; }
}
