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

        [HttpPost("RealizarPago")]
        public Resultado<Pago> RealizarPago([FromBody] PagoRequest request)
        {
            BLPago bLPago = new BLPago();
            return bLPago.BLPAGO_RealizarPago(request.Pago, request.IdEstadoCuenta, request.IdCuota);
        }
    }

    public class PagoRequest
    {
        public Pago Pago { get; set; }
        public int IdEstadoCuenta { get; set; }
        public int IdCuota { get; set; }
    }
}
