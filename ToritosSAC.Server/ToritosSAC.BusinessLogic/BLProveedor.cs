﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToritosSAC.DataAccess;
using ToritosSAC.Entities;

namespace ToritosSAC.BusinessLogic
{
    public class BLProveedor
    {
        public static DataTable Listar()
        {
            DAProveedor Datos = new DAProveedor();
            return Datos.Listar();
        }

        public static DataTable Buscar(string Valor)
        {
            DAProveedor Datos = new DAProveedor();
            return Datos.Buscar(Valor);
        }

        public static DataTable SeleccionarPais()
        {
            DAProveedor Datos = new DAProveedor();
            return Datos.SeleccionarPais();
        }

        public static string Insertar(string Nombre, string Contacto, string Cargo, string Direccion, string Pais)
        {
            DAProveedor Datos = new DAProveedor();

            try
            {
                string Existe = Datos.Existe(Nombre);
                if (Existe.Equals("1"))
                {
                    return "El proveedor ya existe";
                }
                else
                {
                    Proveedor Obj = new Proveedor();
                    Obj.NombreNv = Nombre;
                    Obj.ContactoV = Contacto;
                    Obj.CargoContactoNv = Cargo;
                    Obj.DireccionNv = Direccion;
                    Obj.IdPaisI = Pais;
                    return Datos.Insertar(Obj);
                }
            }
            catch (Exception ex)
            {
                throw new Exception( ex.Message);
            }

        }

        public static string Actualizar(int Id, string NombreAnt, string Nombre, string Contacto, string Cargo, string Direccion, string Pais)
        {
                DAProveedor Datos = new DAProveedor();
                Proveedor Obj = new Proveedor();
            try
            {
                if (NombreAnt.Equals(Nombre))
                {
                    Obj.IdProveedorI = Id;
                    Obj.NombreNv = Nombre;
                    Obj.ContactoV = Contacto;
                    Obj.CargoContactoNv = Cargo;
                    Obj.DireccionNv = Direccion;
                    Obj.IdPaisI = Pais;
                    return Datos.Actualizar(Obj);
                }
                else
                {
                    string Existe = Datos.Existe(Nombre);
                    if (Existe.Equals("1"))
                    {
                        return "El proveedor ya existe";
                    }
                    else
                    {
                        Obj.IdProveedorI = Id;
                        Obj.NombreNv = Nombre;
                        Obj.ContactoV = Contacto;
                        Obj.CargoContactoNv = Cargo;
                        Obj.DireccionNv = Direccion;
                        Obj.IdPaisI = Pais;
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
            DAProveedor Datos = new DAProveedor();
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
            DAProveedor Datos = new DAProveedor();
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
            DAProveedor Datos = new DAProveedor();
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
