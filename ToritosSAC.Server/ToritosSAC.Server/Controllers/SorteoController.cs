using Microsoft.AspNetCore.Mvc;
using ToritosSAC.Entities;
using ToritosSAC.Entities.Structures;
using ToritosSAC.BusinessLogic;

namespace ToritosSAC.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SorteoController : Controller
    {
        [HttpGet("ObtenerSorteosPorGrupo")]
        public Resultado<List<Sorteo>> ObtenerSorteosPorGrupo(int idGrupo)
        {
            BLSorteo bLSorteo = new BLSorteo();
            return bLSorteo.BLSORT_ObtenerSorteosPorGrupo(idGrupo);
        }

        [Route("GuardarSorteo")]
        [HttpPost]
        public Resultado<Sorteo> GuardarSorteo(Sorteo x_sorteo)
        {
            BLSorteo bLSorteo = new BLSorteo();
            return bLSorteo.BLSORT_GuardarSorteo(x_sorteo);
        }
    }
}
