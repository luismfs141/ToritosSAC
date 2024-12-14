using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToritosSAC.Entities.Structures
{
    public class DetallesGrupoStruct
    {
        public int IdGrupo { get; set; } 
        public string CodigoGrupo { get; set; }
        public string TipoPeriodo { get; set; }
        public string EstadoGrupo { get; set; }
        public decimal MontoCuota { get; set; }
        public int NumeroCuotas { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaInicio { get; set; }
        public Modelo ModeloVehiculo { get; set; }
        public Cliente AdminGrupo { get; set; }
        public List<Cliente> IntegrantesGrupo { get; set; }
        public int NumeroIntegrantes { get; set; }
    }
}
