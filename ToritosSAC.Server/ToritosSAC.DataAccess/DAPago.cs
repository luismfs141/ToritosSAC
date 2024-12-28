using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToritosSAC.Entities;
using ToritosSAC.DataAccess.Context;

namespace ToritosSAC.DataAccess
{
    public class DAPago
    {
        public Pago DAPAGO_ObtenerPagoPorId(int idPago)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();
                Pago pago = ctx.Pagos.SingleOrDefault(p => p.IdPagoI == idPago);

                return pago;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Pago DAPAGO_RealizarPago(Pago x_pago)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();

                string codigoPago ="P"+x_pago.ConceptoC + DateTime.Now.Ticks.ToString().Substring(0,13);

                Pago pago = x_pago;
                pago.FechaPagoD = DateTime.Now;
                pago.CodigoPagoV = codigoPago;
                ctx.Pagos.Add(pago);
                ctx.SaveChanges();

                return pago;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
