using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToritosSAC.Entities.Structures
{
    public class DocumentoBase64
    {
        public int IdDocumento { get; set; }
        public string DocumentoIdentidad { get; set; }
        public string AntecedentesPenales { get; set; }
        public string ReciboAguaLuz { get; set; }
        public string DocFax { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaAprobacion { get; set; }
    }
}
