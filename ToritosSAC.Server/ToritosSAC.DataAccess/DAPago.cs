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
    }
}
