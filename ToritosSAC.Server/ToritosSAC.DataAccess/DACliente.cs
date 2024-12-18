using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToritosSAC.DataAccess.Context;
using ToritosSAC.Entities;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ToritosSAC.DataAccess
{
    public class DACliente
    {
        public List<Cliente> DACLIE_ObtenerClientes()
        {
            ToritosDbContext ctx = new ToritosDbContext();

            var clientes = ctx.Clientes.ToList();

            return clientes;
        }

        public Cliente DACLIE_LoginCliente(string x_correo, string x_password)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();

                //Codificacion de password
                string decodedPassword = Encoding.UTF8.GetString(Convert.FromBase64String(x_password));

                byte[] passwordBytes = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(decodedPassword));

                var cliente = ctx.Clientes
                    .Where(x => x.CorreoNv == x_correo && x.PasswordBi == passwordBytes)
                    .SingleOrDefault();

                return cliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Cliente DACLIE_GuardarCliente(Cliente x_cliente)
        {
            ToritosDbContext ctx = new ToritosDbContext();

            if(x_cliente.IdClienteI == 0)
            {
                int totalClientes = ctx.Clientes.Count() +1;
                x_cliente.CodigoC = "C" + totalClientes.ToString("D6");
                byte[] passwordBytes = SHA256.Create().ComputeHash(x_cliente.PasswordBi);
                x_cliente.PasswordBi = passwordBytes; 
                ctx.Clientes.Add(x_cliente);
            }
            else
            {
                Cliente clienteOriginal = ctx.Clientes.SingleOrDefault(c => c.IdClienteI == x_cliente.IdClienteI);
                ctx.Entry(clienteOriginal).CurrentValues.SetValues(x_cliente);
            }

            
            ctx.SaveChanges();

            return ctx.Clientes.SingleOrDefault(c => c.IdClienteI == x_cliente.IdClienteI);
        }
        public List<Cliente> DACLIE_ObtenerClientesPorIdGrupo(int idGrupo)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();
                DAGrupo dAGrupo = new DAGrupo();

                // Obtener el grupo con el código proporcionado
                Grupo grupo = ctx.Grupos.SingleOrDefault(g => g.IdGrupoI == idGrupo);

                if (grupo == null)
                {
                    throw new Exception("Grupo no encontrado para el código proporcionado.");
                }

                // Obtener los IDs de los clientes asociados a este grupo
                List<int> idClientes = ctx.DetalleGrupos
                                           .Where(dg => dg.IdGrupoI == grupo.IdGrupoI && dg.AdmisionC == "A")
                                           .Select(dg => dg.IdClienteI)
                                           .ToList();

                // Obtener los clientes que corresponden a esos IDs
                var clientes = ctx.Clientes
                                  .Where(c => idClientes.Contains(c.IdClienteI))
                                  .ToList();

                return clientes;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los clientes para el grupo", ex);
            }
        }

        public Cliente DACLIE_ObtenerClientePorId(int idCliente)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();
                var cliente = ctx.Clientes
                    .Where(x => x.IdClienteI == idCliente)
                    .SingleOrDefault();
                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el cliente", ex);
            }
        }

        public Cliente DACLIE_ObtenerAdminPorGrupo(int idGrupo)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();
                DetalleGrupo detalleGrupoAdmin = ctx.DetalleGrupos.SingleOrDefault(d => d.IdGrupoI == idGrupo && d.ClienteAdminBo == true);

                return ctx.Clientes.SingleOrDefault(c => c.IdClienteI == detalleGrupoAdmin.IdClienteI);
                    
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el administrador del grupo", ex);
            }
        }



        public static DataTable Listar()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("ClienteListar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }

        public static string Activar(int Id)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("ClienteActivar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@IdCliente_i", SqlDbType.Int).Value = Id;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo activar el registro";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }

        public static string Desactivar(int Id)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("ClienteDesactivar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@IdCliente_i", SqlDbType.Int).Value = Id;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo desactivar el registro";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }

    }
}
