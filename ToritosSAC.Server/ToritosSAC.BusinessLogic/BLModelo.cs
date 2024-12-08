using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToritosSAC.Entities;
using ToritosSAC.DataAccess;
using ToritosSAC.Entities.Structures;

namespace ToritosSAC.BusinessLogic
{
    public class BLModelo
    {
        public Resultado<List<Modelo>> BLMODE_ObtenerModelos()
        {
            try
            {
                DAModelo dAModelo = new DAModelo();
                var modelos = dAModelo.DAMODE_ObtenerModelos();
                return new Resultado<List<Modelo>>(modelos, "Modelos obtenidos exitosamente", true);
            }
            catch (Exception ex)
            {
                return new Resultado<List<Modelo>>(null, $"Error al obtener los modelos: {ex.Message}", false);
            }
        }
    }
}
