using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToritosSAC.DataAccess;
using ToritosSAC.Entities;

namespace ToritosSAC.BusinessLogic
{
    public class BLUsuario
    {
        public static DataTable Listar()
        {
            DAUsuario Datos = new DAUsuario();
            return Datos.Listar();
        }

        public static DataTable Buscar(string Valor)
        {
            DAUsuario Datos = new DAUsuario();
            return Datos.Buscar(Valor);
        }
        public static DataTable Login(string Email, string Clave)
        {
            DAUsuario Datos = new DAUsuario();
            return Datos.Login(Email, Clave);
        }

        public static string Insertar(int IdRol, string Nombre, string TipoDocumento, string NroDocumento, string Direccion, string Telefono, string Correo, string Clave)
        {
            DAUsuario Datos = new DAUsuario();

            string Existe = Datos.Existe(Correo);
            if (Existe.Equals("1"))
            {
                return "El usuario con ese correo ya existe.";
            }
            else
            {
                Usuario Obj = new Usuario();
                Obj.IdRolI = IdRol;
                Obj.NombreV = Nombre;
                Obj.TipoDocumentoC = TipoDocumento;
                Obj.NroDocumentoV = NroDocumento;
                Obj.DireccionV = Direccion;
                Obj.TelefonoC = Telefono;
                Obj.CorreoV = Correo;
                byte[] claveBytes = System.Text.Encoding.UTF8.GetBytes(Clave);
                Obj.ClaveVb = claveBytes;
                return Datos.Insertar(Obj);
            }
        }

        public static string Actualizar(int IdUsuario, int IdRol, String Nombre, string TipoDocumento, string NroDocumento, string Direccion, string Telefono, string CorreoAnt, string Correo, string Clave)
        {
            DAUsuario Datos = new DAUsuario();
            Usuario Obj = new Usuario();

            if (CorreoAnt.Equals(Correo))
            {
                Obj.IdUsuarioI = IdUsuario;
                Obj.IdRolI = IdRol;
                Obj.NombreV = Nombre;
                Obj.TipoDocumentoC = TipoDocumento;
                Obj.NroDocumentoV = NroDocumento;
                Obj.DireccionV = Direccion;
                Obj.TelefonoC = Telefono;
                Obj.CorreoV = Correo;
                byte[] claveBytes = System.Text.Encoding.UTF8.GetBytes(Clave);
                Obj.ClaveVb = claveBytes;
                return Datos.Actualizar(Obj);
            }
            else
            {
                string Existe = Datos.Existe(Correo);
                if (Existe.Equals("1"))
                {
                    return "El usuario con ese correo ya existe.";
                }
                else
                {
                    Obj.IdUsuarioI = IdUsuario;
                    Obj.IdRolI = IdRol;
                    Obj.NombreV = Nombre;
                    Obj.TipoDocumentoC = TipoDocumento;
                    Obj.NroDocumentoV = NroDocumento;
                    Obj.DireccionV = Direccion;
                    Obj.TelefonoC = Telefono;
                    Obj.CorreoV = Correo;
                    byte[] claveBytes = System.Text.Encoding.UTF8.GetBytes(Clave);
                    Obj.ClaveVb = claveBytes;
                    return Datos.Actualizar(Obj);
                }
            }

        }

        public static string Eliminar(int Id)
        {
            DAUsuario Datos = new DAUsuario();
            return Datos.Eliminar(Id);
        }

        public static string Activar(int Id)
        {
            DAUsuario Datos = new DAUsuario();
            return Datos.Activar(Id);
        }

        public static string Desactivar(int Id)
        {
            DAUsuario Datos = new DAUsuario();
            return Datos.Desactivar(Id);
        }

        public static DataTable ListarTipoDocumento()
        {
            DAUsuario Datos = new DAUsuario();
            return Datos.ListarTipoDocumento();
        }
    }
}
