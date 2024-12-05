using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToritosSAC.DataAccess.Context;
using ToritosSAC.Entities;

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
                    .Where(g => idGruposCliente.Contains(g.IdGrupoI) && g.EstadoC != "F")
                    .ToList();

                return grupos;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al obtener el grupo del cliente.", ex);
            }
        }

        public Grupo DAGRUP_CrearGrupo(Grupo x_grupo)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();

                if (x_grupo.IdGrupoI == 0)
                {
                    ctx.Grupos.Add(x_grupo);
                }
                else
                {
                    Grupo grupoOriginal = ctx.Grupos.SingleOrDefault(g => g.IdGrupoI == x_grupo.IdGrupoI);

                    if (grupoOriginal != null)
                    {
                        ctx.Entry(grupoOriginal).CurrentValues.SetValues(x_grupo);
                    }
                }

                ctx.SaveChanges();
                return ctx.Grupos.SingleOrDefault(g => g.IdGrupoI == x_grupo.IdGrupoI);
            }
            catch (Exception ex)
            {

                throw ex;
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

        public bool DAGRUP_UnirseGrupo(Grupo x_grupo, Cliente x_cliente, Documento x_documento)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();
                bool proceso = false;

                DetalleGrupo detalleGrupo = new DetalleGrupo{
                    IdGrupoI = x_grupo.IdGrupoI,
                    IdClienteI = x_cliente.IdClienteI,
                    IdDocumentosI = x_documento.IdDocumentoI,
                    IdAsignacionI = null,
                    ClienteAdminBo = false,
                    AdmisionC = "P"
                };

                DetalleGrupo detalleOriginal = ctx.DetalleGrupos.SingleOrDefault(d => d.IdGrupoI == x_grupo.IdGrupoI &&
                                                d.IdClienteI == x_cliente.IdClienteI);

                if(detalleOriginal == null)
                {
                    ctx.DetalleGrupos.Add(detalleGrupo);
                    proceso = true;
                }
                else
                {
                    ctx.Entry(detalleOriginal).CurrentValues.SetValues(detalleGrupo);
                    proceso = true;
                }
                
                ctx.SaveChanges();

                return proceso;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
