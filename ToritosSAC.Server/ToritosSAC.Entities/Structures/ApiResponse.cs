using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToritosSAC.Entities.Structures
{
    public class ApiResponse<T>
    {
        public string Estado { get; set; }
        public string Mensaje { get; set; }
        public T Data { get; set; }
    }
}
