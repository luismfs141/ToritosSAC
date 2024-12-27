using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using ToritosSAC.DataAccess;
using ToritosSAC.DataAccess.Context;
using ToritosSAC.Entities;
using ToritosSAC.Entities.Structures;


namespace ToritosSAC.BusinessLogic
{
    public class BLEstadoCuenta
    {
        public Resultado<int> BLESCU_GenerarEstadosCuentaClienteGrupo(int idGrupo)
        {
            try
            {
                DAGrupo dAGrupo = new DAGrupo();
                DAEstadoCuenta dAEstadoCuenta = new DAEstadoCuenta();

                Grupo grupo = dAGrupo.DAGRUP_ObtenerGrupoPorId(idGrupo);
                List<DetalleGrupo> detalleGrupos = dAGrupo.DAGRUP_ObtenerDetallesGrupoPorIdGrupo(idGrupo);
                List<EstadoCuentum> estadosCuenta = new List<EstadoCuentum>();

                foreach(DetalleGrupo detalleGrupo in detalleGrupos)
                {
                    EstadoCuentum estadoCuentum = new EstadoCuentum
                    {
                        IdDetalleGrupoI = detalleGrupo.IdGrupoI,
                        MontoRecaudadoN = 0,
                        FechaAperturaD = grupo.FechaInicioPanderoD,
                        FechaCierreD = null,
                        MotivoCierreC = null
                    };
                    estadosCuenta.Add(estadoCuentum);
                }
                dAEstadoCuenta.DAESCU_GuardarListaEstadoCuentaPorGrupo(estadosCuenta);

                return new Resultado<int>(detalleGrupos.Count(), "Estados de cuenta generadas correctamente.", true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Resultado<EstadoCuentum> BLESCU_ObtenerEstadoCuentaClienteGrupo(int idCliente, int idGrupo)
        {
            try
            {
                DAEstadoCuenta dAEstadoCuenta = new DAEstadoCuenta();
                EstadoCuentum estadoCuenta = dAEstadoCuenta.DAESCU_OtenerEstadoCuentaCliente(idCliente, idGrupo);

                return new Resultado<EstadoCuentum>(estadoCuenta, "Estado de cuenta obtenido correctamente.", true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Resultado<DetalleEstadoCuentum> BLESCU_RegistrarPagoDetallesEstadoCuenta(int idEstadoCuenta, int idPago)
        {
            try
            {
                DAEstadoCuenta dAEstadoCuenta = new DAEstadoCuenta();
                DAPago dAPago = new DAPago();

                Pago pago = dAPago.DAPAGO_ObtenerPagoPorId(idPago);

                DetalleEstadoCuentum detalleEstadoCuentum = new DetalleEstadoCuentum
                {
                    IdEstadoCuentaI = idEstadoCuenta,
                    ReferenciaOperacionI = idPago,
                    TipoOperacionC = pago.ConceptoC,
                    Monto = pago.MontoPagoN,
                    FechaPagoDt = pago.FechaPagoD,
                    CodigoPagoV = pago.CodigoPagoV
                };

                dAEstadoCuenta.DAESCU_GuardarDetalleEstadoCuenta(detalleEstadoCuentum);

                return new Resultado<DetalleEstadoCuentum>(detalleEstadoCuentum, "Detalle guardado correctamente.", true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Resultado<List<DetalleEstadoCuentum>> BLESCU_ObtenerDetallesCuentaPorIdEstadoCuenta(int idEstadoCuenta)
        {
            try
            {
                DAEstadoCuenta dAEstadoCuenta = new DAEstadoCuenta();
                List<DetalleEstadoCuentum> detallesEstadoCuenta = dAEstadoCuenta.DAESCU_ObtenerDetallesCuentaPorEstadoCuenta(idEstadoCuenta);

                if(detallesEstadoCuenta.Count() > 0)
                {
                    return new Resultado<List<DetalleEstadoCuentum>>(detallesEstadoCuenta, "Detalles obtenidos correctamente.", true);
                }
                else
                {
                    return new Resultado<List<DetalleEstadoCuentum>>(detallesEstadoCuenta, "No tiene detalles.", false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
