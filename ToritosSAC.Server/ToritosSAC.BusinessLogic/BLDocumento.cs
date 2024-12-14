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
        public Resultado<DocumentoBase64> BLDOCU_GuardarDocumento(DocumentoBase64 x_documento, Cliente x_cliente, Grupo x_grupo)
        {
            try
            {
                DADocumento dADocumento = new DADocumento();
                Documento documento = dADocumento.DADOCU_GuardarDocumento(x_documento, x_cliente, x_grupo);

                DocumentoBase64 documentoBase64 = new DocumentoBase64
                {
                    IdDocumento = documento.IdDocumentoI,
                    ReciboAguaLuz = "",
                    AntecedentesPenales = "",
                    DocFax = "",
                    DocumentoIdentidad = "",
                    Estado = documento.EstadoC,
                    FechaAprobacion = documento.FechaAprovacionD
                };

                if (documento != null)
                {
                    return new Resultado<DocumentoBase64>(documentoBase64, "Documento guardado exitosamente", true);
                }
                else
                {
                    return new Resultado<DocumentoBase64>(null, "Error al guardar el documento", false);
                }
            }
            catch (Exception ex)
            {
                return new Resultado<DocumentoBase64>(null, $"Error al guardar el documento: {ex.Message}", false);
            }
        }
        public Resultado<DocumentoBase64> BLDOCU_ObtenerDocumentoPorClienteGrupo(Cliente x_cliente, Grupo x_grupo)
        {
            try
            {
                DADocumento dADocumento = new DADocumento();
                Documento documento = dADocumento.DADOCU_ObtenerDocumentoPorClienteGrupo(x_cliente, x_grupo);

                DocumentoBase64 documentoBase64 = new DocumentoBase64
                {
                    IdDocumento = documento.IdDocumentoI,
                    ReciboAguaLuz = "",
                    AntecedentesPenales = "",
                    DocFax = "",
                    DocumentoIdentidad = "",
                    Estado = documento.EstadoC,
                    FechaAprobacion = documento.FechaAprovacionD
                };

                if(documento != null)
                {
                    return new Resultado<DocumentoBase64>(documentoBase64, "Documento obtenido exitosamente", true);
                }
                else
                {
                    return new Resultado<DocumentoBase64>(null, "Documento no existe", false);
                }
                
            }
            catch (Exception ex)
            {
                return new Resultado<DocumentoBase64>(null, $"Error al obtener el documento: {ex.Message}", false);
            }
        }

        public Resultado<string> BLDOCU_ObtenerEstadoDocumentoClienteGrupo(int idCliente, int idGrupo)
        {
            try
            {
                DADocumento dADocumento = new DADocumento();
                string estadoDoc = dADocumento.DADOCU_ObtenerEstadoDocumentoClienteGrupo(idCliente, idGrupo);
                return new Resultado<string>(estadoDoc, $"Estado obtenido exitosamente", true);
            }
            catch (Exception ex)
            {
                return new Resultado<string>(null, $"Error al obtener el estado del documento: {ex.Message}", false);
            }
        }
    }
}
