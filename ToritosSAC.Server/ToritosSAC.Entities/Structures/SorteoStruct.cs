using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToritosSAC.Entities.Structures
{
    public class SorteoStruct
    {
        public int IdSorteo { get; set; }
        public int IdCliente { get; set; }
        public int IdGrupo { get; set; }
        public string NombreCliente { get; set; }
        public DateTime FechaSorteo { get; set; }
        public string Modalidad { get; set; }
    }
}
