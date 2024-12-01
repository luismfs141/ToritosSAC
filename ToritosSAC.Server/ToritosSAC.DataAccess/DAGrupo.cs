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
    }
}
