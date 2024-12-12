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
        [HttpGet("ObtenerGruposPorCliente")]
        public Resultado<List<Grupo>> ObtenerGruposPorCliente(int idCliente)
        {
            BLGrupo bLGrupo = new BLGrupo();
            return bLGrupo.BLGRUP_ObtenerGruposPorCliente(idCliente);
        }

        [HttpGet("ObtenerDetallesPorIdGrupo")]
        public Resultado<DetallesGrupoStruct> ObtenerDetallesPorIdGrupo(int idGrupo)
        {
            BLGrupo bLGrupo = new BLGrupo();
            return bLGrupo.BLGRUP_ObtenerDetallesPorIdGrupo(idGrupo);
        }

        [HttpGet("ObtenerGrupoPorCodigo")]
        public Resultado<Grupo> ObtenerGrupoPorCodigo(string codigoGrupo)
        {
            BLGrupo bLGrupo = new BLGrupo();
            return bLGrupo.BLGRUP_ObtenerGrupoPorCodigo(codigoGrupo);
        }

        [HttpGet("ObtenerListaIdGruposAdministrados")]
        public Resultado<List<int>> ObtenerListaIdGruposAdministrados(int idCliente)
        {
            BLGrupo bLGrupo = new BLGrupo();
            return bLGrupo.BLGRUP_ObtenerListaGruposAdministrados(idCliente);
        }

        [Route("GuardarGrupo")]
        [HttpPost]
        public Resultado<Grupo> GuardarGrupo([FromBody] GrupoClienteRequest request)
        {
            Grupo grupo = request.Grupo;
            Cliente cliente = request.Cliente;

            BLGrupo bLGrupo = new BLGrupo();
            return bLGrupo.BLGRUP_GuardarGrupo(grupo, cliente);
        }

        [Route("AbrirGrupoAdmin")]
        [HttpPost]
        public Resultado<Grupo> AbrirGrupoAdmin(DetalleGrupo detalleGrupo)
        {
            BLGrupo bLGrupo = new BLGrupo();
            return bLGrupo.BLGRUP_AbrirGrupoAdmin(detalleGrupo);
        }

        [Route("AgregarListaGrupoCliente")]
        [HttpPost]
        public Resultado<DetalleGrupo> AgregarListaGrupoCliente([FromBody] GrupoClienteRequest request)
        {
            Grupo grupo = request.Grupo;
            Cliente cliente = request.Cliente;

            BLGrupo bLGrupo = new BLGrupo();
            return bLGrupo.BLGRUP_AgregarListaGrupoCliente(grupo, cliente);
        }

        [Route("EliminarListaGrupoCliente")]
        [HttpPost]
        public Resultado<DetalleGrupo> EliminarListaGrupoCliente(int idGrupo)
        {
            BLGrupo bLGrupo = new BLGrupo();
            return bLGrupo.BLGRUP_EliminarListaGrupoCliente(idGrupo);
        }

        [Route("UnirseListaPendienteGrupo")]
        [HttpPost]
        public Resultado<DetalleGrupo> UnirseListaPendienteGrupo(int idCliente, int idGrupo)
        {
            BLGrupo bLGrupo = new BLGrupo();
            return bLGrupo.BLGRUP_UnirseListaPendienteGrupo(idCliente, idGrupo);
        }

        [HttpGet("ListarClientesPendientesIdGrupo")]
        public Resultado<List<Cliente>> ListarClientesPendientesIdGrupo(int idGrupo)
        {
            BLGrupo bLGrupo = new BLGrupo();
            return bLGrupo.BLGRUP_ListarClientesPendientesGrupo(idGrupo);
        }

        [Route("AdmitirClienteGrupo")]
        [HttpPost]
        public Resultado<DetalleGrupo> AdmitirClienteGrupo(int idCliente, int idGrupo)
        {
            BLGrupo bLGrupo = new BLGrupo();
            return bLGrupo.BLGRUP_AdmitirClienteGrupo(idCliente, idGrupo);
        }

        [Route("RechazarClienteGrupo")]
        [HttpPost]
        public Resultado<DetalleGrupo> RechazarClienteGrupo(int idCliente, int idGrupo)
        {
            BLGrupo bLGrupo = new BLGrupo();
            return bLGrupo.BLGRUP_RechazarClienteGrupo(idCliente, idGrupo);
        }

        [HttpGet("ListarClientesAdmitidosGrupo")]
        public Resultado<List<Cliente>> ListarClientesAdmitidosGrupo(Grupo x_grupo)
        {
            BLGrupo bLGrupo = new BLGrupo();
            return bLGrupo.BLGRUP_ListarClientesAdmitidosGrupo(x_grupo);
        }
    }
}