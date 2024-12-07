using Microsoft.AspNetCore.Mvc;
using ToritosSAC.BusinessLogic;
using ToritosSAC.Entities;
using ToritosSAC.Entities.Structures;

namespace ToritosSAC.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentoController : Controller
    {
        [Route("GuardarDocumento")]
        [HttpPost]
        public Resultado<Documento> GuardarDocumento(Documento x_documento)
        {
            BLDocumento bLDocumento = new BLDocumento();
            return bLDocumento.BLDOCU_GuardarDocumento(x_documento);
        }
    }
}
