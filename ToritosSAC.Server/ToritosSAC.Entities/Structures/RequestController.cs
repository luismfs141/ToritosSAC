using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToritosSAC.Entities.Structures
{
    public class GrupoClienteRequest
    {
        public Grupo Grupo { get; set; }
        public Cliente Cliente { get; set; }
    }

    public class DocumentoClienteController
    {
        public Grupo Grupo { get; set; }
        public Cliente Cliente { get; set; }
        public DocumentoBase64 Documento { get; set; }
    }
}
