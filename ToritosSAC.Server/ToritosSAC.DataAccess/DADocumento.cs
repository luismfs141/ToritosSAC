using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToritosSAC.Entities;
using ToritosSAC.DataAccess.Context;
using ToritosSAC.Entities.Structures;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ToritosSAC.DataAccess
{
    public class DADocumento
    {
        public Documento DADOCU_GuardarDocumento(DocumentoBase64 x_documento, Cliente x_cliente, Grupo x_grupo)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();
                byte[] docInden = null;
                byte[] docPenales = null;
                byte[] docAguaLuz = null;
                byte[] docFax = null;

                if (x_documento.DocumentoIdentidad != "")
                {
                    docInden = ConvertBase64ToByteArray(x_documento.DocumentoIdentidad);
                }

                if (x_documento.AntecedentesPenales != "")
                {
                    docPenales = ConvertBase64ToByteArray(x_documento.AntecedentesPenales);
                }

                if (x_documento.ReciboAguaLuz != "")
                {
                    docAguaLuz = ConvertBase64ToByteArray(x_documento.ReciboAguaLuz);
                }

                if (x_documento.DocFax != "")
                {
                    docFax = ConvertBase64ToByteArray(x_documento.DocFax);
                }

                DetalleGrupo detalleGrupoOriginal = ctx.DetalleGrupos.FirstOrDefault(d => d.IdClienteI == x_cliente.IdClienteI && d.IdGrupoI == x_grupo.IdGrupoI);


                if (detalleGrupoOriginal.IdDocumentosI == null)
                {
                    Documento documento = new Documento();

                    documento.FileDocIdentidadBy = docInden;
                    documento.FileAntecedentesPenalesBy = docPenales;
                    documento.FileReciboLuzAguaBy = docAguaLuz;
                    documento.FileEquifaxBy = docFax;
                    documento.EstadoC = "P";
                    ctx.Documentos.Add(documento);
                    ctx.SaveChanges();

                    DetalleGrupo detalleGrupoDoc = detalleGrupoOriginal;
                    detalleGrupoDoc.IdDocumentosI = documento.IdDocumentoI;

                    ctx.Entry(detalleGrupoOriginal).CurrentValues.SetValues(detalleGrupoDoc);
                    ctx.SaveChanges();

                    return documento;
                }
                else
                {
                    Documento documentoOriginal = ctx.Documentos.SingleOrDefault(d => d.IdDocumentoI == detalleGrupoOriginal.IdDocumentosI);

                    documentoOriginal.FileDocIdentidadBy = docInden;
                    documentoOriginal.FileAntecedentesPenalesBy = docPenales;
                    documentoOriginal.FileReciboLuzAguaBy = docAguaLuz;
                    documentoOriginal.FileEquifaxBy = docFax;
                    documentoOriginal.EstadoC = "P";

                    ctx.Entry(documentoOriginal).CurrentValues.SetValues(x_documento);
                    ctx.SaveChanges();

                    return documentoOriginal;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al guardar el documento.", ex);
            }
        }

        public Documento DADOCU_ObtenerDocumentoPorClienteGrupo(Cliente x_cliente, Grupo x_grupo)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();
                DetalleGrupo detalleGrupo = ctx.DetalleGrupos.SingleOrDefault(d => d.IdClienteI == x_cliente.IdClienteI && d.IdGrupoI == x_grupo.IdGrupoI);

                return ctx.Documentos.SingleOrDefault(d => d.IdDocumentoI == detalleGrupo.IdDocumentosI);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al obtener el documento.", ex);
            }
        }

        private static byte[] ConvertBase64ToByteArray(string base64String)
        {
            // Verificar si la cadena es nula o vacía
            if (string.IsNullOrEmpty(base64String))
            {
                throw new ArgumentException("La cadena Base64 no puede ser nula o vacía.");
            }

            // Eliminar prefijos comunes en Base64, como "data:image/png;base64,"
            if (base64String.Contains("base64,"))
            {
                base64String = base64String.Split("base64,")[1]; // Eliminar todo lo que esté antes de "base64,"
            }

            // Eliminar cualquier espacio en blanco extra
            base64String = base64String.Replace("\n", "").Replace("\r", "").Trim();

            try
            {
                // Convertir la cadena Base64 a un arreglo de bytes
                return Convert.FromBase64String(base64String);
            }
            catch (FormatException ex)
            {
                throw new FormatException("La cadena Base64 no tiene un formato válido.", ex);
            }
        }
        public string DADOCU_ObtenerEstadoDocumentoClienteGrupo(int idCliente, int idGrupo)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();

                DetalleGrupo detalleGrupo = ctx.DetalleGrupos.SingleOrDefault(d => d.IdClienteI == idCliente && d.IdGrupoI == idGrupo);

                Documento documento = ctx.Documentos.SingleOrDefault(d => d.IdDocumentoI == detalleGrupo.IdDocumentosI);

                if (documento != null)
                {
                    return documento.EstadoC;
                }
                else
                {
                    return "";
                }
            }
            catch (FormatException ex)
            {
                throw ex;
            }
        }

        public string AprobarDNI(int Id)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("DocumentoAprobarDNI", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@IdDocumento_i", SqlDbType.Int).Value = Id;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo aprobar el registro";
            }
            catch (Exception ex)
            {
                Rpta = "No se pudo aprobar el registro en la base de datos, contactar con el administrador.";
                //instertar error  db 
                throw new Exception(Rpta);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }
        public string RechazarDNI(int Id)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("DocumentoRechazarDNI", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@IdDocumento_i", SqlDbType.Int).Value = Id;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo rechazar el registro";
            }
            catch (Exception ex)
            {
                Rpta = "No se pudo rechazar el registro en la base de datos, contactar con el administrador.";
                //instertar error  db 
                throw new Exception(Rpta);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }
        public string ObservarDNI(int Id)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("DocumentoObservarDNI", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@IdDocumento_i", SqlDbType.Int).Value = Id;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo observar el registro";
            }
            catch (Exception ex)
            {
                Rpta = "No se pudo observar el registro en la base de datos, contactar con el administrador.";
                //instertar error  db 
                throw new Exception(Rpta);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }
        public string AprobarRecibo(int Id)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("DocumentoAprobarRecibo", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@IdDocumento_i", SqlDbType.Int).Value = Id;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo aprobar el registro";
            }
            catch (Exception ex)
            {
                Rpta = "No se pudo aprobar el registro en la base de datos, contactar con el administrador.";
                //instertar error  db 
                throw new Exception(Rpta);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }
        public string RechazarRecibo(int Id)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("DocumentoRechazarRecibo", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@IdDocumento_i", SqlDbType.Int).Value = Id;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo rechazar el registro";
            }
            catch (Exception ex)
            {
                Rpta = "No se pudo rechazar el registro en la base de datos, contactar con el administrador.";
                //instertar error  db 
                throw new Exception(Rpta);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }
        public string ObservarRecibo(int Id)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("DocumentoObservarRecibo", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@IdDocumento_i", SqlDbType.Int).Value = Id;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo observar el registro";
            }
            catch (Exception ex)
            {
                Rpta = "No se pudo observar el registro en la base de datos, contactar con el administrador.";
                //instertar error  db 
                throw new Exception(Rpta);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }
        public string AprobarAntecedentes(int Id)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("DocumentoAprobarAntecedentes", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@IdDocumento_i", SqlDbType.Int).Value = Id;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo aprobar el registro";
            }
            catch (Exception ex)
            {
                Rpta = "No se pudo aprobar el registro en la base de datos, contactar con el administrador.";
                //instertar error  db 
                throw new Exception(Rpta);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }
        public string RechazarAntecedentes(int Id)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("DocumentoRechazarAntecedentes", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@IdDocumento_i", SqlDbType.Int).Value = Id;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo rechazar el registro";
            }
            catch (Exception ex)
            {
                Rpta = "No se pudo rechazar el registro en la base de datos, contactar con el administrador.";
                //instertar error  db 
                throw new Exception(Rpta);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }
        public string ObservarAntecedentes(int Id)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("DocumentoObservarAntecedentes", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@IdDocumento_i", SqlDbType.Int).Value = Id;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo observar el registro";
            }
            catch (Exception ex)
            {
                Rpta = "No se pudo observar el registro en la base de datos, contactar con el administrador.";
                //instertar error  db 
                throw new Exception(Rpta);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }

        public string Aprobar(int Id)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("DocumentoAprobar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@IdDocumento_i", SqlDbType.Int).Value = Id;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo aprobar el registro";
            }
            catch (Exception ex)
            {
                Rpta = "No se pudo aprobar el registro en la base de datos, contactar con el administrador.";
                //instertar error  db 
                throw new Exception(Rpta);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }
    }
}
