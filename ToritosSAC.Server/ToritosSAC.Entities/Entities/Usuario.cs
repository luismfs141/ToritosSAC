using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToritosSAC.Entities.Entities
{
    public class Usuario
    {
        public int IdUsuarioI { get; set; }
        public int IdRolI { get; set; }
        //public string NombreRolV { get; set; }
        public string NombreV { get; set; }
        public string TipoDocumentoC { get; set; }
        public string NroDocumentoV { get; set; }
        public string DireccionV { get; set; }
        public string TelefonoC { get; set; }
        public string CorreoV { get; set; }
        public string ClaveVB { get; set; }
        public bool EstadoC { get; set; }
    }

    public class EUsuarioTipoDocumento
    {
        public string NombreV { get; set; }
        public string CodigoC { get; set; }
    }
    public class ELogin
    {
        public int IdUsuarioI { get; set; }
        public int IdRolI { get; set; }
        //public string RolNombre { get; set; }
        public string UsuarioNombreV { get; set; }
        public bool EstadoC { get; set; }
    }
}
