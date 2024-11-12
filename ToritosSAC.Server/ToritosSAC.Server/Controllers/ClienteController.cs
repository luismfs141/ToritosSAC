using Microsoft.AspNetCore.Mvc;
using ToritosSAC.DataAccess;
using ToritosSAC.Entities;
using ToritosSAC.Entities.Structures;

namespace ToritosSAC.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController
    {
        [HttpGet("GetClientes")]
        public List<Cliente> GetClientes()
        {
            DACliente dACliente = new DACliente();

            return dACliente.DACLIE_ObtenerClientes();
        }

        [Route("LoginCliente")]
        [HttpPost]
        public ApiResponse<Cliente> LoginCliente(string x_usuario, string x_password)
        {
            DACliente dACliente = new DACliente();
            ApiResponse<Cliente> apiResponse;
        
            var cliente = dACliente.DACLIE_LoginCliente(x_usuario, x_password);

            if(cliente == null)
            {
                apiResponse = new ApiResponse<Cliente>
                {
                    Estado = "Error",
                    Mensaje = "Usuario o clave incorrecta",
                    Data = null
                };
            }
            else
            {
                apiResponse = new ApiResponse<Cliente>
                {
                    Estado = "Exito",
                    Mensaje = "Login exitoso",
                    Data = (Cliente)cliente 
                };
            }

            return apiResponse;
        }
    }
}
