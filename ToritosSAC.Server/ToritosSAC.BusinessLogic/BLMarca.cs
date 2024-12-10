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
    public class BLMarca
    {
        public static DataTable Listar()
        {
            DAMarca Datos = new DAMarca();
            return Datos.Listar();
        }

        public static DataTable Buscar(string Valor)
        {
            DAMarca Datos = new DAMarca();
            return Datos.Buscar(Valor);
        }

        public static string Insertar(string Nombre, string SitioWeb)
        {
            DAMarca Datos = new DAMarca();

            try
            {
                string Existe = Datos.Existe(Nombre);
                if (Existe.Equals("1"))
                {
                    return "La marca ya existe";
                }
                else
                {
                    Marca Obj = new Marca();
                    Obj.NombreNv = Nombre;
                    Obj.SitioWebNv = SitioWeb;
                    return Datos.Insertar(Obj);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public static string Actualizar(int Id, string NombreAnt, string Nombre, string SitioWeb)
        {
            DAMarca Datos = new DAMarca();
            Marca Obj = new Marca();
            try
            {
                if (NombreAnt.Equals(Nombre))
                {
                    Obj.IdMarcaI = Id;
                    Obj.NombreNv = Nombre;
                    Obj.SitioWebNv = SitioWeb;
                    return Datos.Actualizar(Obj);
                }
                else
                {
                    string Existe = Datos.Existe(Nombre);
                    if (Existe.Equals("1"))
                    {
                        return "La marca ya existe";
                    }
                    else
                    {
                        Obj.IdMarcaI = Id;
                        Obj.NombreNv = Nombre;
                        Obj.SitioWebNv = SitioWeb;
                        return Datos.Actualizar(Obj);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public static string Eliminar(int Id)
        {
            DAMarca Datos = new DAMarca();
            try
            {
                return Datos.Eliminar(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string Activar(int Id)
        {
            DAMarca Datos = new DAMarca();
            try
            {
                return Datos.Activar(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string Desactivar(int Id)
        {
            DAMarca Datos = new DAMarca();
            try
            {
                return Datos.Desactivar(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
