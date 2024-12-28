using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToritosSAC.Entities;
using ToritosSAC.DataAccess.Context;

namespace ToritosSAC.DataAccess
{
    public class DACronogramaGrupo
    {
        public bool DACRGR_GuardarCronogramaGrupo(List<CronogramaGrupo> cronogramaGrupos)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();
                ctx.CronogramaGrupos.AddRange(cronogramaGrupos);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CronogramaGrupo> DACRGR_ObtenerListaCronogramaGrupo(int idGrupo)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();
                List<CronogramaGrupo> cronogramaGrupos = ctx.CronogramaGrupos.Where(cg => cg.IdGrupoI == idGrupo).ToList();

                return cronogramaGrupos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
