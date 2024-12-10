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
        public Documento DADOCU_GuardarDocumento(Documento x_documento)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();

                if(x_documento.IdDocumentoI == 0)
                {
                    x_documento.EstadoC = "P";
                    ctx.Documentos.Add(x_documento);
                }
                else
                {
                    Documento documentoOriginal = ctx.Documentos.SingleOrDefault(d => d.IdDocumentoI == x_documento.IdDocumentoI);
                    ctx.Entry(documentoOriginal).CurrentValues.SetValues(x_documento);
                }

                ctx.SaveChanges();

                return ctx.Documentos.SingleOrDefault(d => d.IdDocumentoI == x_documento.IdDocumentoI);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al guardar el documento.", ex);
            }
        }
    }
}
