using Microsoft.AspNetCore.Mvc;
using ToritosSAC.BusinessLogic;
using ToritosSAC.Entities;
using ToritosSAC.Entities.Structures;

namespace ToritosSAC.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GrupoController
    {
        //[HttpGet("UnirseGrupo")]
        //public bool UnirseGrupo(Grupo x_grupo, Cliente x_cliente, Documento x_documento)
        //{
        //    try
        //    {
        //        bool resultado = false;
        //        BLGrupo blGrupo = new BLGrupo();
        //        resultado = blGrupo.BLGRUP_UnirseGrupo(x_grupo, x_cliente, x_documento);

        //        return resultado;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
