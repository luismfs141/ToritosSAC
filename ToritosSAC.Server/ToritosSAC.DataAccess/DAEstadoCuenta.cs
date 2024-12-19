using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
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

        public void DAESCU_GuardarEstadoCuenta(List<DetalleEstadoCuentum> detallesEstado, ToritosDbContext ctx, IDbContextTransaction transaction)
        {
            try
            {
                if (transaction != null)
                {
                    ctx.Database.UseTransaction(transaction.GetDbTransaction());
                }

                ctx.DetalleEstadoCuenta.AddRange(detallesEstado);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al guardar los detalles de estado de cuenta.", ex);
            }
        }

        public List<DetalleEstadoCuentum> DAESCU_ObtenerEstadoCuentaPorIdClienteGrupo(int idCliente,int idGrupo)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();
                DetalleGrupo detalleGrupo = ctx.DetalleGrupos.SingleOrDefault(d => d.IdClienteI == idCliente && d.IdGrupoI == idGrupo);
                List<DetalleEstadoCuentum> detalleEstados = ctx.DetalleEstadoCuenta.Where(d => d.IdDetalleGrupoI == detalleGrupo.IdDetalleGrupoI).ToList();

                return detalleEstados;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al obtener los estados de cuenta.", ex);
            }
        }
    }
}
