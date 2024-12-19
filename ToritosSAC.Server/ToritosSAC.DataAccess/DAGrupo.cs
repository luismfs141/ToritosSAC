using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToritosSAC.DataAccess.Context;
using ToritosSAC.Entities;
using ToritosSAC.Entities.Structures;

namespace ToritosSAC.DataAccess
{
    public class DAGrupo
    {
        public List<Grupo> DAGRUP_ObtenerGruposPorCliente(int idCliente)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();

                var idGruposCliente = ctx.DetalleGrupos
                .Where(dg => dg.IdClienteI == idCliente)
                .Select(dg => dg.IdGrupoI)
                .ToList();

                if (idGruposCliente.Count == 0)
                {
                    return new List<Grupo>();
                }

                var grupos = ctx.Grupos
                    .Where(g => idGruposCliente.Contains(g.IdGrupoI))
                    .ToList();

                return grupos;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al obtener el grupo del cliente.", ex);
            }
        }

        public DetallesGrupoStruct DAGRUP_ObtenerDetallesPorIdGrupo(int idGrupo)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();
                DACliente dACliente = new DACliente();

                //List<DetalleGrupo> detallesGrupo = ctx.DetalleGrupos.Where(d => d.IdGrupoI == idGrupo && d.AdmisionC =="A").ToList();
                Grupo grupo = ctx.Grupos.SingleOrDefault(g => g.IdGrupoI == idGrupo);
                Modelo modeloVehiculo = ctx.Modelos.SingleOrDefault(m => m.IdModeloVehiculoI == grupo.IdModeloVehiculoI);
                Cliente adminGrupo = dACliente.DACLIE_ObtenerAdminPorGrupo(idGrupo);
                List<Cliente> listaMiembros = dACliente.DACLIE_ObtenerClientesPorIdGrupo(idGrupo);

                DetallesGrupoStruct grupoStruct = new DetallesGrupoStruct
                {
                    IdGrupo = grupo.IdGrupoI,
                    CodigoGrupo = grupo.CodigoC,
                    TipoPeriodo = grupo.TipoPeriodoPagoC,
                    EstadoGrupo = grupo.EstadoC,
                    MontoCuota = grupo.MontoCuotaN == null ? 0: (decimal)grupo.MontoCuotaN,
                    NumeroCuotas = grupo.CantidadCuotasI,
                    FechaCreacion = grupo.FechaCreacionD,
                    FechaInicio = grupo.FechaInicioPanderoD,
                    ModeloVehiculo = modeloVehiculo,
                    AdminGrupo = adminGrupo,
                    IntegrantesGrupo = listaMiembros,
                    NumeroIntegrantes = grupo.CantMaxIntegrantesI
                };

                return grupoStruct;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al obtener los detalles del grupo.", ex);
            }
        }

        public List<int> DAGRUP_ObtenerListaGruposAdministrados(int idCliente)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();
                List<int> idGrupos = ctx.DetalleGrupos.Where(d => d.IdClienteI == idCliente && d.ClienteAdminBo == true).Select(d => d.IdGrupoI).ToList();
                return idGrupos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de grupos administrados", ex);
            }
        }
        public Grupo DAGRUP_ObtenerGrupoPorCodigo(string x_codigo)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();
                Grupo grupo = ctx.Grupos.SingleOrDefault(g => g.CodigoC == x_codigo);
                return grupo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Grupo DAGRUP_CuardarGrupo(Grupo x_grupo, Cliente x_cliente)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();
                bool nuevoGrupo = false;

                if (x_grupo.IdGrupoI == 0)
                {
                    int totalGrupos = ctx.Grupos.Count() + 1;
                    x_grupo.CodigoC = "G" + totalGrupos.ToString("D6");
                    x_grupo.EstadoC = "E";
                    ctx.Grupos.Add(x_grupo);
                    nuevoGrupo = true;
                }
                else
                {
                    if(x_grupo.EstadoC == "E")
                    {
                        Grupo grupoOriginal = ctx.Grupos.SingleOrDefault(g => g.IdGrupoI == x_grupo.IdGrupoI);
                        if (grupoOriginal != null)
                        {
                            ctx.Entry(grupoOriginal).CurrentValues.SetValues(x_grupo);
                        }
                    }
                }

                ctx.SaveChanges();

                Grupo grupo = ctx.Grupos.SingleOrDefault(g => g.IdGrupoI == x_grupo.IdGrupoI);

                if (nuevoGrupo)
                {
                    DetalleGrupo detalleGrupo = new DetalleGrupo
                    {
                        IdGrupoI = grupo.IdGrupoI,
                        IdClienteI = x_cliente.IdClienteI,
                        ClienteAdminBo = true,
                        AdmisionC = "A"
                    };
                    ctx.DetalleGrupos.Add(detalleGrupo);
                }

                ctx.SaveChanges();
                return grupo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Grupo? DAGRUP_AbrirGrupoAdmin(DetalleGrupo x_detalleGrupo)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();

                Cliente? cliente = ctx.Clientes.SingleOrDefault(c => c.IdClienteI == x_detalleGrupo.IdClienteI);
                Grupo? grupo = ctx.Grupos.SingleOrDefault(g => g.IdGrupoI == x_detalleGrupo.IdGrupoI);
                Documento? documento = ctx.Documentos.SingleOrDefault(d => d.IdDocumentoI == x_detalleGrupo.IdDocumentosI);
               
                if(grupo != null && cliente !=null && documento != null)
                {
                    Grupo nuevoGrupo = grupo;

                    if (cliente.EstadoC == "A" && x_detalleGrupo.ClienteAdminBo == true && grupo.EstadoC == "E" && documento.EstadoC == "A")
                    {
                        nuevoGrupo.EstadoC = "A";
                        ctx.Entry(grupo).CurrentValues.SetValues(nuevoGrupo);
                        ctx.SaveChanges();
                    }
                }
                return ctx.Grupos.SingleOrDefault(g => g.IdGrupoI == x_detalleGrupo.IdGrupoI);
            }
            catch (Exception ex)
            {

                throw ex;
            }          
        }
        public DetalleGrupo? DAGRUP_AgregarGrupoListaCliente(Grupo x_grupo, Cliente x_cliente)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();
                DetalleGrupo? detGrupoOriginal = ctx.DetalleGrupos.SingleOrDefault(d => d.IdGrupoI == x_grupo.IdGrupoI && d.IdClienteI == x_cliente.IdClienteI);

                if (x_grupo.EstadoC == "A" && x_cliente.EstadoC == "A" && detGrupoOriginal == null)
                {
                    DetalleGrupo detGrupo = new DetalleGrupo
                    {
                        IdClienteI = x_cliente.IdClienteI,
                        IdGrupoI = x_grupo.IdGrupoI,
                        ClienteAdminBo = false,
                        AdmisionC = "N"
                    };
                    ctx.DetalleGrupos.Add(detGrupo);
                    ctx.SaveChanges();

                    return detGrupo;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DAGRUP_EliminarGrupoListaCliente(int idDetalleGrupo)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();

                DetalleGrupo detalleGrupo = ctx.DetalleGrupos.SingleOrDefault(d => d.IdDetalleGrupoI == idDetalleGrupo);
                ctx.DetalleGrupos.Remove(detalleGrupo);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DetalleGrupo? DAGRUP_UnirseListaPendienteGrupo(int idCliente, int idGrupo)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();

                Cliente? cliente = ctx.Clientes.SingleOrDefault(c => c.IdClienteI == idCliente);
                Grupo? grupo = ctx.Grupos.SingleOrDefault(g => g.IdGrupoI == idGrupo);
                DetalleGrupo detalleGrupoOriginal = ctx.DetalleGrupos.SingleOrDefault(d => d.IdClienteI == idCliente && d.IdGrupoI == idGrupo);
                Documento? documento = ctx.Documentos.SingleOrDefault(d => d.IdDocumentoI == detalleGrupoOriginal.IdDocumentosI);
                DetalleGrupo detalleGrupoCopia = detalleGrupoOriginal;

                if (grupo != null && cliente != null && documento != null)
                {
                    if (cliente.EstadoC == "A" && grupo.EstadoC == "A" && documento.EstadoC == "A" && detalleGrupoOriginal.AdmisionC != "A" && detalleGrupoOriginal.AdmisionC != "P")
                    {
                        detalleGrupoCopia.AdmisionC = "P";
                        ctx.Entry(detalleGrupoOriginal).CurrentValues.SetValues(detalleGrupoCopia);
                    }
                }

                ctx.SaveChanges();
                return detalleGrupoCopia;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Cliente> DAGRUP_ListarClientesPendientesIdGrupo(int idGrupo)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();

                List<int> idClientes = ctx.DetalleGrupos
               .Where(d => d.IdGrupoI == idGrupo && d.AdmisionC == "P")
               .Select(d => d.IdClienteI)
               .ToList();

                // Consultar los clientes cuyos Id están en la lista obtenida
                List<Cliente> clientesPendientes = ctx.Clientes
                    .Where(c => idClientes.Contains(c.IdClienteI))
                    .ToList();

                return clientesPendientes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DetalleGrupo? DAGRUP_AdmitirClienteGrupo(int idCliente, int idGrupo)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();

                Grupo grupo = ctx.Grupos.SingleOrDefault(g => g.IdGrupoI == idGrupo);
                int integrantesGrupo = ctx.DetalleGrupos.Count(d => d.IdGrupoI == idGrupo && d.AdmisionC == "A");
                DetalleGrupo detalleGrupo = ctx.DetalleGrupos.SingleOrDefault(d => d.IdClienteI == idCliente && d.IdGrupoI == idGrupo);

                if (detalleGrupo.AdmisionC == "P" && grupo.EstadoC == "A" && integrantesGrupo < grupo.CantMaxIntegrantesI)
                {
                    detalleGrupo.AdmisionC = "A";
                    ctx.SaveChanges();
                }
                else
                {
                    if (integrantesGrupo < grupo.CantMaxIntegrantesI)
                    {
                        throw new Exception("El grupo ya tiene el número máximo de integrantes.");
                    }
                }
                return detalleGrupo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DetalleGrupo? DAGRUP_RechazarClienteGrupo(int idCliente, int idGrupo)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();

                Grupo grupo = ctx.Grupos.SingleOrDefault(g => g.IdGrupoI == idGrupo);
                DetalleGrupo detalleGrupo = ctx.DetalleGrupos.SingleOrDefault(d => d.IdClienteI == idCliente && d.IdGrupoI == idGrupo);

                if (detalleGrupo.AdmisionC == "P" && grupo.EstadoC == "A")
                {
                    detalleGrupo.AdmisionC = "R";
                    ctx.SaveChanges();
                }
                return detalleGrupo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Cliente> DAGRUP_ListarClientesAdmitidosGrupo(Grupo x_grupo)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();

                List<int> idClientes = ctx.DetalleGrupos
                    .Where(d => d.IdGrupoI == x_grupo.IdGrupoI && d.AdmisionC == "A")
                    .Select(d => d.IdClienteI).ToList();

                List<Cliente> listaClientes = ctx.Clientes.Where(c => idClientes.Contains(c.IdClienteI)).ToList();

                return listaClientes;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int DAGRUP_ObtenerNumeroIntegrantesIdGrupo(int idGrupo)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();

                int numClientes = ctx.DetalleGrupos
                    .Where(d => d.IdGrupoI == idGrupo && d.AdmisionC == "A").Count();

                return numClientes;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool DAGRUP_EsAdministradorGrupo(int idCliente, int idGrupo)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();

                DetalleGrupo detalleGrupo = ctx.DetalleGrupos.SingleOrDefault(d => d.IdClienteI == idCliente && d.IdGrupoI == idGrupo);

                return detalleGrupo.ClienteAdminBo;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
        }
        public bool DAGRUP_EsMiembroGrupo(int idCliente, int idGrupo)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();

                DetalleGrupo detalleGrupo = ctx.DetalleGrupos.SingleOrDefault(d => d.IdClienteI == idCliente && d.IdGrupoI == idGrupo);

                if(detalleGrupo.AdmisionC == "A")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (FormatException ex)
            {
                throw ex;
            }
        }

        public Grupo DAGRUP_ObtenerGrupoPorId(int idGrupo)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();
                Grupo grupo = ctx.Grupos.SingleOrDefault(g => g.IdGrupoI == idGrupo);
                return grupo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DetalleGrupo> DAGRUP_ObtenerDetallesGrupoPorIdGrupo(int idGrupo)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();
                List<DetalleGrupo> detalleGrupos = ctx.DetalleGrupos.Where(d => d.IdGrupoI == idGrupo && d.AdmisionC == "A").ToList();
                return detalleGrupos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Grupo DAGRUP_IniciarCronogramaGrupo(int idGrupo, DateTime fechaInicio)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();
                Grupo grupo = ctx.Grupos.SingleOrDefault(g => g.IdGrupoI == idGrupo);
                grupo.EstadoC = "F";
                grupo.FechaInicioPanderoD = fechaInicio;
                ctx.SaveChanges();

                return grupo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
