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
    public class BLModelo
    {
        public static DataTable Listar()
        {
            DAModelo Datos = new DAModelo();
            return Datos.Listar();
        }

        public static DataTable Buscar(string Valor)
        {
            DAModelo Datos = new DAModelo();
            return Datos.Buscar(Valor);
        }

        public static DataTable SeleccionarMarca()
        {
            DAModelo Datos = new DAModelo();
            return Datos.SeleccionarMarca();
        }
        public static DataTable SeleccionarTipoModelo()
        {
            DAModelo Datos = new DAModelo();
            return Datos.SeleccionarTipoModelo();
        }

        public static string Insertar(int Marca, string Nombre, string Tipo, decimal Precio)
        {
            DAModelo Datos = new DAModelo();

            try
            {
                string Existe = Datos.Existe(Nombre);
                if (Existe.Equals("1"))
                {
                    return "El modelo ya existe";
                }
                else
                {
                    Modelo Obj = new Modelo();
                    Obj.IdMarcaI = Marca;
                    Obj.NombreNv = Nombre;
                    Obj.TipoC = Tipo;
                    Obj.PrecioUnidadVehiculoM = Precio;
                    return Datos.Insertar(Obj);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public static string Actualizar(int Id, int Marca, string NombreAnt, string Nombre, string Tipo, decimal Precio)
        {
            DAModelo Datos = new DAModelo();
            Modelo Obj = new Modelo();
            try
            {
                if (NombreAnt.Equals(Nombre))
                {
                    Obj.IdModeloVehiculoI = Id;
                    Obj.IdMarcaI = Marca;
                    Obj.NombreNv = Nombre;
                    Obj.TipoC = Tipo;
                    Obj.PrecioUnidadVehiculoM = Precio;
                    return Datos.Actualizar(Obj);
                }
                else
                {
                    string Existe = Datos.Existe(Nombre);
                    if (Existe.Equals("1"))
                    {
                        return "El modelo ya existe";
                    }
                    else
                    {
                        Obj.IdModeloVehiculoI = Id;
                        Obj.IdMarcaI = Marca;
                        Obj.NombreNv = Nombre;
                        Obj.TipoC = Tipo;
                        Obj.PrecioUnidadVehiculoM = Precio;
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
            DAModelo Datos = new DAModelo();
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
            DAModelo Datos = new DAModelo();
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
            DAModelo Datos = new DAModelo();
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
