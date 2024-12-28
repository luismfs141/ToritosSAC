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
        public Resultado<List<SorteoStruct>> ObtenerSorteosPorGrupo(int idGrupo)
        {
            BLSorteo bLSorteo = new BLSorteo();
            return bLSorteo.BLSORT_ObtenerSorteosPorGrupo(idGrupo);
        }

        [HttpGet("ObtenerProximoFechaSorteo")]
        public Resultado<DateTime> ObtenerProximoFechaSorteo(int idGrupo)
        {
            BLSorteo bLSorteo = new BLSorteo();
            return bLSorteo.BLSORT_ObtenerProximoFechaSorteo(idGrupo);
        }

        [HttpGet("ObtenerMartillazoPeriodo")]
        public Resultado<MartillazoStruct> ObtenerMartillazoPeriodo(int idGrupo)
        {
            BLSorteo bLSorteo = new BLSorteo();
            return bLSorteo.BLSORT_ObtenerMartillazoPeriodo(idGrupo);
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
