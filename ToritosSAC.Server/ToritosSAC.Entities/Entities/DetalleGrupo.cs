﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ToritosSAC.Entities;

public partial class DetalleGrupo
{
    public int IdDetalleGrupoI { get; set; }

    public int IdGrupoI { get; set; }

    public int IdClienteI { get; set; }

    public int? IdDocumentosI { get; set; }

    public int? IdAsignacionI { get; set; }

    public bool ClienteAdminBo { get; set; }

    public string? AdmisionC { get; set; }

    public virtual ICollection<DetalleEstadoCuentum> DetalleEstadoCuenta { get; } = new List<DetalleEstadoCuentum>();

    public virtual Asignacion? IdAsignacionINavigation { get; set; }
    [JsonIgnore]
    public virtual Cliente? IdClienteINavigation { get; set; } = null!;

    public virtual Documento? IdDocumentosINavigation { get; set; }
    [JsonIgnore]
    public virtual Grupo? IdGrupoINavigation { get; set; } = null!;
}
