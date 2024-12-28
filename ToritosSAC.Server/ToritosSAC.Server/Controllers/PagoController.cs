using Microsoft.AspNetCore.Mvc;
using ToritosSAC.BusinessLogic;
using ToritosSAC.Entities;
using ToritosSAC.Entities.Structures;

namespace ToritosSAC.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagoController : Controller
    {
        [Route("RealizarPago")]
        [HttpPost]
        public Resultado<Pago> RealizarPago(Pago x_pago, int idEstadoCuenta, int idCuota)
        {
            BLPago bLPago = new BLPago();
            return bLPago.BLPAGO_RealizarPago(x_pago,idEstadoCuenta, idCuota);
        }
    }
}
