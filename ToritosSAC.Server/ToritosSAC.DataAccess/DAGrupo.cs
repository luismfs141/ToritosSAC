using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToritosSAC.DataAccess.Context;
using ToritosSAC.Entities;

namespace ToritosSAC.DataAccess
{
    public class DAGrupo
    {
        public Grupo DAGRUP_ObtenerGrupoPorCliente(int idCliente)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();

                int? idGrupoCliente = ctx.DetalleGrupos
                    .Where(dg => dg.IdClienteI == idCliente)
                    .Select(dg => dg.IdGrupoI)
                    .FirstOrDefault();

                if (!idGrupoCliente.HasValue)
                {
                    return null;
                }

                var grupo = ctx.Grupos
                    .Where(g => g.IdGrupoI == idGrupoCliente.Value)
                    .FirstOrDefault();

                return grupo;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al obtener el grupo del cliente.", ex);
            }
        }

        public Grupo DAGRUP_GuardarGrupo(Grupo x_grupo)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();

                if (x_grupo.IdGrupoI == 0)
                {
                    ctx.Grupos.Add(x_grupo);
                }
                else
                {
                    Grupo grupoOriginal = ctx.Grupos.SingleOrDefault(g => g.IdGrupoI == x_grupo.IdGrupoI);

                    if (grupoOriginal != null)
                    {
                        ctx.Entry(grupoOriginal).CurrentValues.SetValues(x_grupo);
                    }
                }

                ctx.SaveChanges();
                return ctx.Grupos.SingleOrDefault(g => g.IdGrupoI == x_grupo.IdGrupoI);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public Grupo DAGRUP_BuscarGrupoPorCodigo(string x_codigo)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();

                Grupo grupo = ctx.Grupos.SingleOrDefault(g => g.CodigoC == x_codigo);

                return grupo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool DAGRUP_UnirseGrupo(Grupo x_grupo)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();

                return true;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
