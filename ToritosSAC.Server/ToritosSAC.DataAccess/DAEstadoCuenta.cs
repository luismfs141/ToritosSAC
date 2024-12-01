using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToritosSAC.DataAccess.Context;
using ToritosSAC.Entities;

namespace ToritosSAC.DataAccess
{
    public class DAEstadoCuenta
    {
        public List<DetalleEstadoCuentum> DAESCU_OtenerEstadoCuentaCliente(int idCliente, int idGrupo)
        {
            ToritosDbContext ctx = new ToritosDbContext();

            int idDetalleGrupo = ctx.DetalleGrupos.Where(d => d.IdClienteI == idCliente && d.IdGrupoI == idGrupo).Select(d => d.IdDetalleGrupoI).FirstOrDefault();

            var detallesCuenta = ctx.DetalleEstadoCuenta.Where(dc => dc.IdDetalleGrupoI == idDetalleGrupo).ToList();

            return detallesCuenta;
        }
    }
}
