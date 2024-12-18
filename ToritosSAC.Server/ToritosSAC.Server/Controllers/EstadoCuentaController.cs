using Microsoft.AspNetCore.Mvc;
using ToritosSAC.BusinessLogic;
using ToritosSAC.DataAccess;
using ToritosSAC.Entities;
using ToritosSAC.Entities.Structures;

namespace ToritosSAC.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstadoCuentaController
    {
        [HttpGet("GetEstadoCuentaCliente")]
        public List<DetalleEstadoCuentum> GetEstadoCuentaCliente(int idCliente, int idGrupo)
        {
            DAEstadoCuenta dAEstadoCuenta = new DAEstadoCuenta();

            return dAEstadoCuenta.DAESCU_OtenerEstadoCuentaCliente(idCliente,idGrupo);
        }

        [Route("CrearCronograma")]
        [HttpPost]
        public Resultado<bool> CrearCronogramaPorGrupo(int idGrupo, DateTime fechaInicio)
        {

            BLEstadoCuenta bLEstadoCuenta = new BLEstadoCuenta();
            return bLEstadoCuenta.BLESCU_CrearCronogramaPorGrupo(idGrupo, fechaInicio);
        }

        [HttpGet("GetEstadosCuentaIdClienteGrupo")]
        public Resultado<List<DetalleEstadoCuentum>> ObtenerDetallesCuentaPorIdClienteGrupo(int idCliente, int idGrupo)
        {
            BLEstadoCuenta bLEstadoCuenta = new BLEstadoCuenta();

            return bLEstadoCuenta.BLESCU_ObtenerDetallesCuentaPorIdClienteGrupo(idCliente, idGrupo);
        }
    }
}
