using Microsoft.AspNetCore.Mvc;
using ToritosSAC.BusinessLogic;
using ToritosSAC.Entities;

namespace ToritosSAC.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UbigeoController
    {
        [HttpGet("GetDepartamentos")]
        public List<Departamento> ObtenerDepartamentos()
        {
            BLUbigeo bLUbigeo = new BLUbigeo();
            return bLUbigeo.BLUBIG_ObtenerDepartamentos();
        }
        [HttpGet("GetProvincias")]
        public List<Provincium> ObtenerProvinciasPorDepartamento(string idDepartamento)
        {
            BLUbigeo bLUbigeo = new BLUbigeo();
            return bLUbigeo.BLUBIG_ObtenerProvinciaPorDepartamento(idDepartamento);
        }
        [HttpGet("GetDistritos")]
        public List<Distrito> ObtenerDistritosPorProvincia(string idProvincia)
        {
            BLUbigeo bLUbigeo = new BLUbigeo();
            return bLUbigeo.BLUBIG_ObtenerDistritoPorProvincia(idProvincia);
        }
    }
}
