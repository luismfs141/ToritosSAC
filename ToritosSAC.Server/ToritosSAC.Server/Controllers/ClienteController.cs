using Microsoft.AspNetCore.Mvc;
using ToritosSAC.BusinessLogic;
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

        [Route("GuardarCliente")]
        [HttpPost]
        public ApiResponse<Cliente> GuardarCliente(Cliente x_cliente)
        {
            BLCliente bLCliente = new BLCliente();
            ApiResponse<Cliente> apiResponse;

            var cliente = bLCliente.BLCLIE_GuardarCliente(x_cliente);

            if (cliente == null)
            {
                apiResponse = new ApiResponse<Cliente>
                {
                    Estado = "Error",
                    Mensaje = "Error al guardar el cliente",
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

        //[Route("LoginCliente")]
        //[HttpPost]
        [HttpGet("LoginCliente")]
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

        [HttpGet("GetClientesPorGrupo")]
        public ApiResponse<List<Cliente>> GetClientesPorGrupo(string x_codigoGrupo)
        {
            DACliente dACliente = new DACliente();
            ApiResponse<List<Cliente>> apiResponse;

            try
            {
                // Obtener la lista de clientes para el grupo dado por el código
                List<Cliente> clientes = dACliente.DACLIE_ObtenerClientesPorGrupo(x_codigoGrupo);

                if (clientes == null || clientes.Count == 0)
                {
                    // Si no se encuentran clientes para el grupo
                    apiResponse = new ApiResponse<List<Cliente>>
                    {
                        Estado = "Error",
                        Mensaje = "No se encontraron clientes para el grupo con el código proporcionado.",
                        Data = null
                    };
                }
                else
                {
                    // Si se encontraron clientes, devolvemos la lista con éxito
                    apiResponse = new ApiResponse<List<Cliente>>
                    {
                        Estado = "Exito",
                        Mensaje = "Clientes obtenidos con éxito.",
                        Data = clientes
                    };
                }
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devolvemos un mensaje de error adecuado
                apiResponse = new ApiResponse<List<Cliente>>
                {
                    Estado = "Error",
                    Mensaje = "Error al obtener clientes para el grupo: " + ex.Message,
                    Data = null
                };
            }

            return apiResponse;
        }
    }
}
