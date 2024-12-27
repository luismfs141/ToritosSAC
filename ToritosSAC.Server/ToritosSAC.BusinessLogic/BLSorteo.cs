using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToritosSAC.Entities.Structures;
using ToritosSAC.Entities;
using ToritosSAC.DataAccess;

namespace ToritosSAC.BusinessLogic
{
    public class BLSorteo
    {
        public Resultado<List<Sorteo>> BLSORT_ObtenerSorteosPorGrupo(int idGrupo)
        {
            try
            {
                DASorteo dASorteo = new DASorteo();
                List<Sorteo> sorteos = dASorteo.DASORT_ObtenerSorteosPorGrupo(idGrupo);
                if(sorteos.Count() > 0)
                {
                    return new Resultado<List<Sorteo>>(sorteos, "Sorteos obtenidos exitosamente.", true);
                }
                else
                {
                    return new Resultado<List<Sorteo>>(null, "El grupo no tiene sorteos.", false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Resultado<Sorteo> BLSORT_GuardarSorteo(Sorteo x_sorteo)
        {
            try
            {
                DASorteo dASorteo = new DASorteo();
                Sorteo sorteo = dASorteo.DASORT_GuardarSorteo(x_sorteo);
                return new Resultado<Sorteo>(sorteo, "Sorteo guardado exitosamente.", true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
