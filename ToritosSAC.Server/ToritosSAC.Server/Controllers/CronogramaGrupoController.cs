using Microsoft.AspNetCore.Mvc;
using ToritosSAC.BusinessLogic;
using ToritosSAC.Entities;
using ToritosSAC.Entities.Structures;

namespace ToritosSAC.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CronogramaGrupoController : Controller
    {
        [Route("GenerarCronogramaGrupo")]
        [HttpPost]
        public Resultado<bool> GenerarCronogramaGrupo(int idGrupo, DateTime fechaInicio)
        {
            BLCronogramaGrupo bLCronogramaGrupo = new BLCronogramaGrupo();
            return bLCronogramaGrupo.BLCRGR_CrearCronogramaGrupo(idGrupo, fechaInicio);
        }

        [HttpGet("ObtenerCronogramaGrupo")]
        public Resultado<List<CronogramaGrupo>> ObtenerCronogramaGrupo(int idGrupo)
        {
            BLCronogramaGrupo bLCronogramaGrupo = new BLCronogramaGrupo();
            return bLCronogramaGrupo.BLCRGR_ObtenerCronogramaGrupo(idGrupo);
        }
    }
}
