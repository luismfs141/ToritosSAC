using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ToritosSAC.Entities;

public partial class DetalleGrupo
{
    public int IdDetalleGrupoI { get; set; }

    public int IdGrupoI { get; set; }

    public int IdClienteI { get; set; }

    public int? IdDocumentosI { get; set; }

    public bool ClienteAdminBo { get; set; }

    public string? AdmisionC { get; set; }

    public bool EsGanadorB { get; set; }

    public bool EstadoPropietarioB { get; set; }

    public virtual ICollection<Cuotum> Cuota { get; } = new List<Cuotum>();

    public virtual ICollection<EstadoCuentum> EstadoCuenta { get; } = new List<EstadoCuentum>();
    [JsonIgnore]
    public virtual Cliente? IdClienteINavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual Documento? IdDocumentosINavigation { get; set; }
    [JsonIgnore]
    public virtual Grupo? IdGrupoINavigation { get; set; } = null!;

    public virtual ICollection<Sorteo> Sorteos { get; } = new List<Sorteo>();
}
