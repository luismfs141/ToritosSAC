using Microsoft.AspNetCore.Mvc;
using ToritosSAC.BusinessLogic;
using ToritosSAC.Entities;
using ToritosSAC.Entities.Structures;

namespace ToritosSAC.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModeloController
    {
        [HttpGet("ObtenerModelos")]
        public Resultado<List<Modelo>> ObtenerModelos()
        {
            BLModelo bLModelo = new BLModelo();
            return bLModelo.BLMODE_ObtenerModelos();
        }
    }
}
