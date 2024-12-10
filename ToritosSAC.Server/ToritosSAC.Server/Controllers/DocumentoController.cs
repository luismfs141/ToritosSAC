using Microsoft.AspNetCore.Mvc;
using ToritosSAC.BusinessLogic;
using ToritosSAC.Entities;
using ToritosSAC.Entities.Structures;

namespace ToritosSAC.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentoController 
    {
        [Route("GuardarDocumento")]
        [HttpPost]
        public Resultado<Documento> GuardarDocumento([FromBody] GrupoClienteRequest request)
        {
            Grupo grupo = request.Grupo;
            Cliente cliente = request.Cliente;
            Documento documento = request.Documento();

            BLDocumento bLDocumento = new BLDocumento();
            return bLDocumento.BLDOCU_GuardarDocumento(documento,cliente,grupo);
        }

        [Route("ObtenerDocumentoPorClienteGrupo")]
        [HttpPost]
        public Resultado<Documento> ObtenerDocumentoPorClienteGrupo([FromBody] GrupoClienteRequest request)
        {
            Grupo grupo = request.Grupo;
            Cliente cliente = request.Cliente;

            BLDocumento bLDocumento = new BLDocumento();
            return bLDocumento.BLDOCU_ObtenerDocumentoPorClienteGrupo(cliente, grupo);
        }
    }
}
