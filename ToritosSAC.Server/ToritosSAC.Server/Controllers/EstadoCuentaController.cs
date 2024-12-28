
using Microsoft.AspNetCore.Mvc;
using ToritosSAC.BusinessLogic;
using ToritosSAC.Entities;
using ToritosSAC.Entities.Structures;

namespace ToritosSAC.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstadoCuentaController
    {
        [HttpGet("ObtenerEstadoCuentaCliente")]
        public Resultado<EstadoCuentum> ObtenerEstadoCuentaCliente(int idCliente, int idGrupo)
        {
            BLEstadoCuenta bLEstadoCuenta = new BLEstadoCuenta();
            return bLEstadoCuenta.BLESCU_ObtenerEstadoCuentaClienteGrupo(idCliente, idGrupo);
        }

        [HttpGet("ObtenerDetallesEstadoCuentaCliente")]
        public Resultado<List<DetalleEstadoCuentum>> ObtenerDetallesEstadoCuentaCliente(int idEstadoCuenta)
        {
            BLEstadoCuenta bLEstadoCuenta = new BLEstadoCuenta();
            return bLEstadoCuenta.BLESCU_ObtenerDetallesCuentaPorIdEstadoCuenta(idEstadoCuenta);
        }

        [Route("GenerarEstadosCuentaClienteGrupo")]
        [HttpPost]
        public Resultado<int> GenerarEstadosCuentaClienteGrupo(int idGrupo)
        {
            BLEstadoCuenta bLEstadoCuenta = new BLEstadoCuenta();
            return bLEstadoCuenta.BLESCU_GenerarEstadosCuentaClienteGrupo(idGrupo);
        }

        [Route("RegistrarPagoDetallesEstadoCuenta")]
        [HttpPost]
        public Resultado<DetalleEstadoCuentum> RegistrarPagoDetallesEstadoCuenta(int idEstadoCuenta, int idPago)
        {
            BLEstadoCuenta bLEstadoCuenta = new BLEstadoCuenta();
            return bLEstadoCuenta.BLESCU_RegistrarPagoDetallesEstadoCuenta(idEstadoCuenta, idPago);
        }
    }
}
