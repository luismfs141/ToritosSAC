using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ToritosSAC.Entities;

public partial class DetalleEstadoCuentum
{
    public int IdDetalleEstadoCuentaI { get; set; }

    public int IdDetalleGrupoI { get; set; }

    public int NroCuotaI { get; set; }

    public decimal MontoCuotaM { get; set; }

    public DateTime FechaPagoProgramadaD { get; set; }

    public DateTime? FechaPagoRealD { get; set; }

    public string EstadoCuotaC { get; set; } = null!;

    public decimal? PenalidadMontoM { get; set; }

    public DateTime? PenalidadFechaPagoD { get; set; }

    public decimal MartillazoMontoM { get; set; }

    public DateTime? MartillazoFechaPagoD { get; set; }
    [JsonIgnore]
    public virtual DetalleGrupo IdDetalleGrupoINavigation { get; set; } = null!;
}
