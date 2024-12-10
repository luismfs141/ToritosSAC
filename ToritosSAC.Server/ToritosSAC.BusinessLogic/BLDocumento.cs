using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToritosSAC.DataAccess;
using ToritosSAC.Entities;
using ToritosSAC.Entities.Structures;

namespace ToritosSAC.BusinessLogic
{
    public class BLDocumento
    {
        public Resultado<Documento> BLDOCU_GuardarDocumento(Documento x_documento)
        {
            try
            {
                DADocumento dADocumento = new DADocumento();
                Documento documento = dADocumento.DADOCU_GuardarDocumento(x_documento);
                return new Resultado<Documento>(documento, "Documento guardado exitosamente", true);
            }
            catch (Exception ex)
            {
                return new Resultado<Documento>(null, $"Error al guardar el documento: {ex.Message}", false);
            }
        }
    }
}
