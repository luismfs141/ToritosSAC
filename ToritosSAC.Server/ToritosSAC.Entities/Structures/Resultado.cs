using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToritosSAC.Entities.Structures
{
    public class Resultado<T>
    {
        public T Objeto { get; set; }
        public string Mensaje { get; set; }
        public bool Exito { get; set; }

        public Resultado(T objeto, string mensaje, bool exito)
        {
            Objeto = objeto;
            Mensaje = mensaje;
            Exito = exito;
        }
    }
}
