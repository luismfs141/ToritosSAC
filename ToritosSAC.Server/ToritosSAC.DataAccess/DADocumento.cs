using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToritosSAC.Entities;
using ToritosSAC.DataAccess.Context;

namespace ToritosSAC.DataAccess
{
    public class DADocumento
    {
        public Documento DADOCU_GuardarDocumento(Documento x_documento, Cliente x_cliente, Grupo x_grupo)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();

                if(x_documento.IdDocumentoI == 0)
                {
                    DetalleGrupo detalleGrupoOriginal = ctx.DetalleGrupos.SingleOrDefault(d => d.IdClienteI == x_cliente.IdClienteI && d.IdGrupoI == x_grupo.IdGrupoI);

                    x_documento.EstadoC = "P";
                    ctx.Documentos.Add(x_documento);
                    ctx.SaveChanges();

                    DetalleGrupo detalleGrupoDoc = detalleGrupoOriginal;
                    detalleGrupoDoc.IdDocumentosI = x_documento.IdDocumentoI;

                    ctx.Entry(detalleGrupoOriginal).CurrentValues.SetValues(detalleGrupoDoc);
                    ctx.SaveChanges();
                }
                else
                {
                    Documento documentoOriginal = ctx.Documentos.SingleOrDefault(d => d.IdDocumentoI == x_documento.IdDocumentoI);
                    ctx.Entry(documentoOriginal).CurrentValues.SetValues(x_documento);
                    ctx.SaveChanges();
                }

                

                return ctx.Documentos.SingleOrDefault(d => d.IdDocumentoI == x_documento.IdDocumentoI);
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
    }
}
