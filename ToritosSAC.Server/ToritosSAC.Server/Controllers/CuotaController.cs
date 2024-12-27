using Microsoft.AspNetCore.Mvc;
using ToritosSAC.BusinessLogic;
using ToritosSAC.Entities;
using ToritosSAC.Entities.Structures;

namespace ToritosSAC.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuotaController : Controller
    {
        [Route("GenerarCuotasClienteGrupo")]
        [HttpPost]
        public Resultado<int> GenerarCuotasClienteGrupo(int idGrupo)
        {
            BLCuota bLCuota = new BLCuota();
            return bLCuota.BLCUOT_GenerarCuotasClientesGrupo(idGrupo);
        }

        [HttpGet("ListarCuotasClienteGrupo")]
        public Resultado<List<Cuotum>> ListarCuotasClienteGrupo(int idCliente, int idGrupo)
        {
            BLCuota bLCuota = new BLCuota();
            return bLCuota.BLCUOT_ListarCuotasClienteGrupo(idCliente, idGrupo);
        }

        [Route("RecalcularCuotasClienteGrupo")]
        [HttpPost]
        public Resultado<int> RecalcularCuotasClienteGrupo(int idCliente, int idGrupo, decimal montoPagado)
        {
            BLCuota bLCuota = new BLCuota();
            return bLCuota.BLCUOT_RecalcularCuotasClienteGrupo(idCliente, idGrupo, montoPagado);
        }
    }
}
