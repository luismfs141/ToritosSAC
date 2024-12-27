using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToritosSAC.Entities;
using ToritosSAC.DataAccess.Context;

namespace ToritosSAC.DataAccess
{
    public class DASorteo
    {
        public List<Sorteo> DASORT_ObtenerSorteosPorGrupo(int idGrupo)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();
                List<Sorteo> listaSorteos = ctx.Sorteos.Where(s => s.IdGrupoI == idGrupo).ToList();
                return listaSorteos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Sorteo DASORT_GuardarSorteo(Sorteo x_sorteo)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();
                ctx.Sorteos.Add(x_sorteo);
                ctx.SaveChanges();

                return x_sorteo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
