using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToritosSAC.DataAccess;
using ToritosSAC.Entities;
using ToritosSAC.Entities.Structures;

namespace ToritosSAC.BusinessLogic
{
    public class BLPago
    {
        public Resultado<Pago> BLPAGO_RealizarPago(Pago x_pago, int idEstadoCuenta, int idCuota)
        {
            try
            {
                DAPago dAPago = new DAPago();
                DACuota dACuota = new DACuota();

                DAEstadoCuenta dAEstadoCuenta = new DAEstadoCuenta();
                DetalleEstadoCuentum registroDetalle = new DetalleEstadoCuentum();

                Pago pago = dAPago.DAPAGO_RealizarPago(x_pago);
                Cuotum cuota = dACuota.DACUOT_ObtenerCuotaPorID(idCuota);

                if (pago != null)
                {
                    DetalleEstadoCuentum detalleEstadoCuentum = new DetalleEstadoCuentum
                    {
                        IdEstadoCuentaI = idEstadoCuenta,
                        ReferenciaOperacionI = idCuota,
                        TipoOperacionC = pago.ConceptoC,
                        Monto = cuota.MontoCuotaN,
                        FechaPagoDt = pago.FechaPagoD,
                        CodigoPagoV = pago.CodigoPagoV
                    };

                    registroDetalle = dAEstadoCuenta.DAESCU_GuardarDetalleEstadoCuenta(detalleEstadoCuentum);
                }

                if(pago != null && registroDetalle != null)
                {
                    dAEstadoCuenta.DAESCU_RecalcularMontoAportado(idEstadoCuenta);
                    cuota.EstadoCuotaC = "A";
                    dACuota.DACOUT_GuardarCuota(cuota);
                    return new Resultado<Pago>(pago, "Pago realizado con éxito.", true);
                }
                else
                {
                    return new Resultado<Pago>(null, "No se registro el pago.", false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
