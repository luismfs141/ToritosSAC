using System;
using System.Collections.Generic;

namespace ToritosSAC.Entities;

public partial class Documento
{
    public int IdDocumentoI { get; set; }

    public byte[]? FileDocIdentidadBy { get; set; }

    public byte[]? FileAntecedentesPenalesBy { get; set; }

    public byte[]? FileReciboLuzAguaBy { get; set; }

    public byte[]? FileEquifaxBy { get; set; }

    public string EstadoC { get; set; } = null!;

    public DateTime? FechaAprovacionD { get; set; }

    public virtual ICollection<DetalleGrupo> DetalleGrupos { get; } = new List<DetalleGrupo>();
}
