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
        public void DAESCU_GuardarListaEstadoCuentaPorGrupo(List<EstadoCuentum> estadosCuenta)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();
                ctx.EstadoCuenta.AddRange(estadosCuenta);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DetalleEstadoCuentum DAESCU_GuardarDetalleEstadoCuenta(DetalleEstadoCuentum detalleEstadoCuenta)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();
                ctx.DetalleEstadoCuenta.Add(detalleEstadoCuenta);
                ctx.SaveChanges();

                return detalleEstadoCuenta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DetalleEstadoCuentum> DAESCU_ObtenerDetallesCuentaPorEstadoCuenta(int idEstadoCuenta)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();
                List<DetalleEstadoCuentum> detallesEstadoCuenta = ctx.DetalleEstadoCuenta.Where(d => d.IdEstadoCuentaI == idEstadoCuenta).ToList();
                return detallesEstadoCuenta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public EstadoCuentum DAESCU_OtenerEstadoCuentaCliente(int idCliente, int idGrupo)
        {
            ToritosDbContext ctx = new ToritosDbContext();

            int idDetalleGrupo = ctx.DetalleGrupos.Where(d => d.IdClienteI == idCliente && d.IdGrupoI == idGrupo).Select(d => d.IdDetalleGrupoI).FirstOrDefault();

            var estadoCuenta = ctx.EstadoCuenta.SingleOrDefault(dc => dc.IdDetalleGrupoI == idDetalleGrupo);

            return estadoCuenta;
        }

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

        public EstadoCuentum DAESCU_RecalcularMontoAportado(int idEstadoCuenta)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();
                EstadoCuentum estadoCuentaOriginal = ctx.EstadoCuenta.SingleOrDefault(d => d.IdEstadoCuentaI == idEstadoCuenta);
                List<DetalleEstadoCuentum> listaDetalles = ctx.DetalleEstadoCuenta.Where(dt => dt.IdEstadoCuentaI == idEstadoCuenta && (dt.TipoOperacionC =="C" || dt.TipoOperacionC == "M")).ToList();

                decimal montoAportado = listaDetalles.Sum(ld => ld.Monto);
                estadoCuentaOriginal.MontoRecaudadoN = montoAportado;

                ctx.SaveChanges();

                return estadoCuentaOriginal;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
