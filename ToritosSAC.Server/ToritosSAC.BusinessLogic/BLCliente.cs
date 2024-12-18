using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToritosSAC.DataAccess;
using ToritosSAC.Entities;
using ToritosSAC.Entities.Structures;

namespace ToritosSAC.BusinessLogic
{
    public class BLCliente
    {
        public Cliente BLCLIE_GuardarCliente(Cliente x_cliente)
        {
            DACliente dACliente = new DACliente();

            return dACliente.DACLIE_GuardarCliente(x_cliente);
        }

        public Cliente BLCLIE_LoginCliente(string correo, string password)
        {
            DACliente dACliente = new DACliente();

            return dACliente.DACLIE_LoginCliente(correo, password);
        }
        public Resultado<List<Cliente>> BLCLIE_ObtenerClientesPorIdGrupo(int idGrupo)
        {
            try
            {
                DACliente dACliente=new DACliente();
                List<Cliente> clientes = dACliente.DACLIE_ObtenerClientesPorIdGrupo(idGrupo);
                return new Resultado<List<Cliente>>(clientes, $"Clientes obtenidos exitosamente", true);
            }
            catch (Exception ex)
            {
                return new Resultado<List<Cliente>>(null, $"Error al obtener los clientes del grupo: {ex.Message}", false);
            }
        }



        public static DataTable ListarClientes()
        {

            return DACliente.Listar();
        }


        public static string Activar(int Id)
        {
            try
            {
                return DACliente.Activar(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string Desactivar(int Id)
        {
            try
            {
                return DACliente.Desactivar(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
