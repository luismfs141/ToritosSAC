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
        public EstadoCuentum DAESCU_OtenerEstadoCuentaCliente(int idCliente, int idGrupo)
        {
            ToritosDbContext ctx = new ToritosDbContext();

            int idDetalleGrupo = ctx.DetalleGrupos.Where(d => d.IdClienteI == idCliente && d.IdGrupoI == idGrupo).Select(d => d.IdDetalleGrupoI).FirstOrDefault();

            var estadoCuenta = ctx.EstadoCuenta.SingleOrDefault(dc => dc.IdDetalleGrupoI == idDetalleGrupo);

            return estadoCuenta;
        }

        //public void DAESCU_GuardarEstadoCuenta(List<DetalleEstadoCuentum> detallesEstado, ToritosDbContext ctx, IDbContextTransaction transaction)
        //{
        //    try
        //    {
        //        if (transaction != null)
        //        {
        //            ctx.Database.UseTransaction(transaction.GetDbTransaction());
        //        }

        //        ctx.DetalleEstadoCuenta.AddRange(detallesEstado);
        //        ctx.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ApplicationException("Error al guardar los detalles de estado de cuenta.", ex);
        //    }
        //}

        public EstadoCuentum DAESCU_GuardarEstadoCuenta(EstadoCuentum estadoCuentum)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();

                if(estadoCuentum.IdEstadoCuentaI == 0)
                {
                    ctx.EstadoCuenta.Add(estadoCuentum);
                }
                else
                {
                    EstadoCuentum estadiCuentaOriginal = ctx.EstadoCuenta.SingleOrDefault(e => e.IdEstadoCuentaI == estadoCuentum.IdEstadoCuentaI);
                    ctx.Entry(estadiCuentaOriginal).CurrentValues.SetValues(estadoCuentum);
                }
                ctx.SaveChanges();
                return estadoCuentum;
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error al guardar el estado de cuenta.", ex);
            }
        }

        //public List<DetalleEstadoCuentum> DAESCU_ObtenerEstadoCuentaPorIdClienteGrupo(int idCliente,int idGrupo)
        //{
        //    try
        //    {
        //        ToritosDbContext ctx = new ToritosDbContext();
        //        DetalleGrupo detalleGrupo = ctx.DetalleGrupos.SingleOrDefault(d => d.IdClienteI == idCliente && d.IdGrupoI == idGrupo);
        //        List<DetalleEstadoCuentum> detalleEstados = ctx.DetalleEstadoCuenta.Where(d => d.IdDetalleGrupoI == detalleGrupo.IdDetalleGrupoI).ToList();

        //        return detalleEstados;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ApplicationException("Error al obtener los estados de cuenta.", ex);
        //    }
        //}
    }
}
