using System;
using System.Collections.Generic;
using ToritosSAC.DataAccess;
using ToritosSAC.Entities;
using Microsoft.Extensions.Logging;
using ToritosSAC.Entities.Structures;

namespace ToritosSAC.BusinessLogic
{
    public class BLGrupo
    {
        public Resultado<List<Grupo>> BLGRUP_ObtenerGruposPorCliente(int idCliente)
        {
            try
            {
                DAGrupo dAGrupo = new DAGrupo();
                var grupos = dAGrupo.DAGRUP_ObtenerGruposPorCliente(idCliente);
                return new Resultado<List<Grupo>>(grupos, "Grupos obtenidos exitosamente", true);
            }
            catch (Exception ex)
            {
                return new Resultado<List<Grupo>>(null, $"Error al obtener los grupos del cliente: {ex.Message}", false);
            }
        }
        public Resultado<DetallesGrupoStruct> BLGRUP_ObtenerDetallesPorIdGrupo(int idGrupo)
        {
            try
            {
                DAGrupo dAGrupo = new DAGrupo();
                DetallesGrupoStruct detallesGrupoStruct = dAGrupo.DAGRUP_ObtenerDetallesPorIdGrupo(idGrupo);
                return new Resultado<DetallesGrupoStruct>(detallesGrupoStruct, "Detalles obtenidos exitosamente", true);
            }
            catch (Exception ex)
            {
                return new Resultado<DetallesGrupoStruct>(null, $"Error al obtener los detalles del grupo: {ex.Message}", false);
            }
        }

        public Resultado<List<int>> BLGRUP_ObtenerListaGruposAdministrados(int idCliente)
        {
            try
            {
                DAGrupo dAGrupo = new DAGrupo();
                List<int> idGrupos = dAGrupo.DAGRUP_ObtenerListaGruposAdministrados(idCliente);

                return new Resultado<List<int>>(idGrupos, "Grupos obtenidos exitosamente", true);
            }
            catch (Exception ex)
            {
                return new Resultado<List<int>>(null, $"Error al obtener los grupos administrados: {ex.Message}", false);
            }
        }
        public Resultado<Grupo> BLGRUP_ObtenerGrupoPorCodigo(string x_codigo)
        {
            try
            {
                DAGrupo dAGrupo = new DAGrupo();
                var grupo = dAGrupo.DAGRUP_ObtenerGrupoPorCodigo(x_codigo);
                return new Resultado<Grupo>(grupo, "Grupo obtenido exitosamente", true);
            }
            catch (Exception ex)
            {
                return new Resultado<Grupo>(null, $"Error al obtener el grupo por código: {ex.Message}", false);
            }
        }

        public Resultado<Grupo> BLGRUP_GuardarGrupo(Grupo x_grupo, Cliente x_cliente)
        {
            try
            {
                DAGrupo dAGrupo = new DAGrupo();
                var grupo = dAGrupo.DAGRUP_CuardarGrupo(x_grupo, x_cliente);
                return new Resultado<Grupo>(grupo, "Grupo guardado exitosamente", true);
            }
            catch (Exception ex)
            {
                return new Resultado<Grupo>(null, $"Error al guardar el grupo: {ex.Message}", false);
            }
        }

        public Resultado<Grupo> BLGRUP_AbrirGrupoAdmin(DetalleGrupo x_detalleGrupo)
        {
            try
            {
                DAGrupo dAGrupo = new DAGrupo();
                var grupo = dAGrupo.DAGRUP_AbrirGrupoAdmin(x_detalleGrupo);
                return new Resultado<Grupo>(grupo, "Grupo administrativo abierto exitosamente", true);
            }
            catch (Exception ex)
            {
                return new Resultado<Grupo>(null, $"Error al abrir el grupo administrativo: {ex.Message}", false);
            }
        }

        public Resultado<DetalleGrupo> BLGRUP_AgregarListaGrupoCliente(Grupo x_grupo, Cliente x_cliente)
        {
            try
            {
                if(x_grupo.EstadoC == "A")
                {
                    DAGrupo dAGrupo = new DAGrupo();
                    var detalleGrupo = dAGrupo.DAGRUP_AgregarGrupoListaCliente(x_grupo, x_cliente);
                    return new Resultado<DetalleGrupo>(detalleGrupo, "Cliente agregado al grupo exitosamente", true);
                }
                else
                {
                    return new Resultado<DetalleGrupo>(null, "Error, el grupo no se encuentra activado.", false);
                }
                
            }
            catch (Exception ex)
            {
                return new Resultado<DetalleGrupo>(null, $"Error al agregar el cliente al grupo: {ex.Message}", false);
            }
        }

        public Resultado<DetalleGrupo> BLGRUP_EliminarListaGrupoCliente(int idGrupo)
        {
            try
            {
                DAGrupo dAGrupo = new DAGrupo();
                dAGrupo.DAGRUP_EliminarGrupoListaCliente(idGrupo);
                return new Resultado<DetalleGrupo>(null, "Cliente eliminado del grupo exitosamente", true);
            }
            catch (Exception ex)
            {
                return new Resultado<DetalleGrupo>(null, $"Error al eliminar el cliente del grupo: {ex.Message}", false);
            }
        }

        public Resultado<DetalleGrupo> BLGRUP_UnirseListaPendienteGrupo(int idCliente, int idGrupo)
        {
            try
            {
                DAGrupo dAGrupo = new DAGrupo();
                var detalleGrupo = dAGrupo.DAGRUP_UnirseListaPendienteGrupo(idCliente, idGrupo);
                if(detalleGrupo != null)
                {
                    return new Resultado<DetalleGrupo>(detalleGrupo, "Unión a la lista pendiente del grupo exitosa", true);
                }
                else
                {
                    return new Resultado<DetalleGrupo>(null, "Unión a la lista pendiente del grupo fallida", false);
                }
            }
            catch (Exception ex)
            {
                return new Resultado<DetalleGrupo>(null, $"Error al unirse a la lista pendiente del grupo: {ex.Message}", false);
            }
        }

        public Resultado<List<Cliente>> BLGRUP_ListarClientesPendientesGrupo(int idGrupo)
        {
            try
            {
                DAGrupo dAGrupo = new DAGrupo();
                var clientes = dAGrupo.DAGRUP_ListarClientesPendientesIdGrupo(idGrupo);
                return new Resultado<List<Cliente>>(clientes, "Clientes pendientes listados exitosamente", true);
            }
            catch (Exception ex)
            {
                return new Resultado<List<Cliente>>(null, $"Error al listar los clientes pendientes del grupo: {ex.Message}", false);
            }
        }

        public Resultado<DetalleGrupo> BLGRUP_AdmitirClienteGrupo(int idCliente, int idGrupo)
        {
            try
            {
                DAGrupo dAGrupo = new DAGrupo();
                var detalleGrupo = dAGrupo.DAGRUP_AdmitirClienteGrupo(idCliente, idGrupo);
                return new Resultado<DetalleGrupo>(detalleGrupo, "Cliente admitido en el grupo exitosamente", true);
            }
            catch (Exception ex)
            {
                return new Resultado<DetalleGrupo>(null, $"Error al admitir al cliente en el grupo: {ex.Message}", false);
            }
        }

        public Resultado<DetalleGrupo> BLGRUP_RechazarClienteGrupo(int idCliente, int idGrupo)
        {
            try
            {
                DAGrupo dAGrupo = new DAGrupo();
                var detalleGrupo = dAGrupo.DAGRUP_RechazarClienteGrupo(idCliente, idGrupo);
                return new Resultado<DetalleGrupo>(detalleGrupo, "Cliente rechazado del grupo exitosamente", true);
            }
            catch (Exception ex)
            {
                return new Resultado<DetalleGrupo>(null, $"Error al rechazar al cliente en el grupo: {ex.Message}", false);
            }
        }

        public Resultado<List<Cliente>> BLGRUP_ListarClientesAdmitidosGrupo(Grupo x_grupo)
        {
            try
            {
                DAGrupo dAGrupo = new DAGrupo();
                var clientes = dAGrupo.DAGRUP_ListarClientesAdmitidosGrupo(x_grupo);
                return new Resultado<List<Cliente>>(clientes, "Clientes admitidos listados exitosamente", true);
            }
            catch (Exception ex)
            {
                return new Resultado<List<Cliente>>(null, $"Error al listar los clientes admitidos en el grupo: {ex.Message}", false);
            }
        }
    }
}