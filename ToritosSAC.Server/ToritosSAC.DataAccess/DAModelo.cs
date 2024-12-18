using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToritosSAC.Entities;
using ToritosSAC.DataAccess.Context;

namespace ToritosSAC.DataAccess
{
    public class DAModelo
    {
        public DataTable Listar()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("ModeloListar", SqlCon);
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

        public DataTable Buscar(string Valor)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("ModeloBuscar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@Nombre_nv", SqlDbType.VarChar).Value = Valor;
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

        public DataTable SeleccionarMarca()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("ModeloSeleccionarMarca", SqlCon);
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

        public DataTable SeleccionarTipoModelo()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("ModeloSeleccionarTipo", SqlCon);
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

        public string Existe(string Valor)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("ModeloExistente", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@Nombre_nv", SqlDbType.VarChar).Value = Valor;
                SqlParameter ParExiste = new SqlParameter();
                ParExiste.ParameterName = "@Existe";
                ParExiste.SqlDbType = SqlDbType.Int;
                ParExiste.Direction = ParameterDirection.Output;
                Comando.Parameters.Add(ParExiste);
                SqlCon.Open();
                Comando.ExecuteNonQuery();
                Rpta = Convert.ToString(ParExiste.Value);
            }
            catch (Exception ex)
            {
                Rpta = "No se pudo verificar la existencia del registro en la base de datos.";
                //instertar error  db 
                throw new Exception(Rpta);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }

        public string Insertar(Modelo Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("ModeloInsertar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@IdMarca_i", SqlDbType.VarChar).Value = Obj.IdMarcaI;
                Comando.Parameters.Add("@Nombre_nv", SqlDbType.VarChar).Value = Obj.NombreNv;
                Comando.Parameters.Add("@Tipo_c", SqlDbType.VarChar).Value = Obj.TipoC;
                Comando.Parameters.Add("@PrecioUnidadVehiculo_m", SqlDbType.VarChar).Value = Obj.PrecioUnidadVehiculoM;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo ingresar el registro";

            }
            catch (Exception ex)
            {
                Rpta = "No se pudo registrar en la base de datos, verifique los campos.";
                //instertar error  db 
                throw new Exception(Rpta);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }

        public string Actualizar(Modelo Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("ModeloActualizar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@IdModeloVehiculo_i", SqlDbType.Int).Value = Obj.IdModeloVehiculoI;
                Comando.Parameters.Add("@IdMarca_i", SqlDbType.VarChar).Value = Obj.IdMarcaI;
                Comando.Parameters.Add("@Nombre_nv", SqlDbType.VarChar).Value = Obj.NombreNv;
                Comando.Parameters.Add("@Tipo_c", SqlDbType.VarChar).Value = Obj.TipoC;
                Comando.Parameters.Add("@PrecioUnidadVehiculo_m", SqlDbType.VarChar).Value = Obj.PrecioUnidadVehiculoM;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo actualizar el registro";
            }
            catch (Exception ex)
            {
                Rpta = "No se pudo actualizar en la base de datos, verifique los campos.";
                //instertar error  db 
                throw new Exception(Rpta);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }

        public string Eliminar(int Id)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("ModeloEliminar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@IdModeloVehiculo_i", SqlDbType.Int).Value = Id;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo eliminar el registro";
            }
            catch (Exception ex)
            {
                Rpta = "No se pudo eliminar de la base de datos, verifique los campos.";
                //instertar error  db 
                throw new Exception(Rpta);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }

        public string Activar(int Id)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("ModeloActivar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@IdModeloVehiculo_i", SqlDbType.Int).Value = Id;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo activar el registro";
            }
            catch (Exception ex)
            {
                Rpta = "No se pudo activar el registro en la base de datos, contactar con el administrador.";
                //instertar error  db 
                throw new Exception(Rpta);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }

        public string Desactivar(int Id)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("ModeloDesactivar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@IdModeloVehiculo_i", SqlDbType.Int).Value = Id;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo desactivar el registro";
            }
            catch (Exception ex)
            {
                Rpta = "No se pudo desactivar el registro en la base de datos, contactar con el administrador.";
                //instertar error  db 
                throw new Exception(Rpta);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }


        public Modelo DAMODE_GuardarModelo(Modelo x_modelo)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();

                if (x_modelo.IdModeloVehiculoI == 0)
                {
                    ctx.Modelos.Add(x_modelo);
                }
                else
                {
                    Modelo modeloOriginal = ctx.Modelos.SingleOrDefault(m => m.IdModeloVehiculoI == x_modelo.IdModeloVehiculoI);
                    ctx.Entry(modeloOriginal).CurrentValues.SetValues(x_modelo);
                }
                ctx.SaveChanges();

                return x_modelo;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al guardar el modelo de vehículo.", ex);
            }
        }

        public List<Modelo> DAMODE_ObtenerModelos()
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();
                return ctx.Modelos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al obtener el modelo de vehículos.", ex);
            }
        }

        public Modelo DAMODE_ObtenerModeloVehiculoPorId(int idModelo)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();
                Modelo modelo = ctx.Modelos.SingleOrDefault(m => m.IdModeloVehiculoI == idModelo);
                return modelo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
