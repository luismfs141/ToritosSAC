using Microsoft.AspNetCore.Mvc;
using ToritosSAC.DataAccess;
using ToritosSAC.Entities;

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
    }
}
