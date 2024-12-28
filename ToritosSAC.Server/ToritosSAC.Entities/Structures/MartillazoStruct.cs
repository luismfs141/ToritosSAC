using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToritosSAC.Entities.Structures
{
    public class MartillazoStruct
    {
        public int Id { get; set; }
        public DateTime FechaApertura { get; set; }
        public DateTime FechaCierre { get; set; }
        public decimal MontoMartillazo { get; set; }
        public bool Estado { get; set; }
    }
}
