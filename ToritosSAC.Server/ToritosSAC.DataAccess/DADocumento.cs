using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToritosSAC.Entities;
using ToritosSAC.DataAccess.Context;
using ToritosSAC.Entities.Structures;

namespace ToritosSAC.DataAccess
{
    public class DADocumento
    {
        public Documento DADOCU_GuardarDocumento(DocumentoBase64 x_documento, Cliente x_cliente, Grupo x_grupo)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();
                byte[] docInden = null;
                byte[] docPenales = null;
                byte[] docAguaLuz = null;
                byte[] docFax = null;

                if(x_documento.DocumentoIdentidad != "")
                {
                    docInden = ConvertBase64ToByteArray(x_documento.DocumentoIdentidad);
                }

                if (x_documento.AntecedentesPenales != "")
                {
                    docPenales = ConvertBase64ToByteArray(x_documento.AntecedentesPenales);
                }

                if (x_documento.ReciboAguaLuz != "")
                {
                    docAguaLuz = ConvertBase64ToByteArray(x_documento.ReciboAguaLuz);
                }

                if (x_documento.DocFax != "")
                {
                    docFax = ConvertBase64ToByteArray(x_documento.DocFax);
                }

                DetalleGrupo detalleGrupoOriginal = ctx.DetalleGrupos.FirstOrDefault(d => d.IdClienteI == x_cliente.IdClienteI && d.IdGrupoI == x_grupo.IdGrupoI);


                if (detalleGrupoOriginal.IdDocumentosI == null)
                {
                    Documento documento = new Documento();

                    documento.FileDocIdentidadBy = docInden;
                    documento.FileAntecedentesPenalesBy = docPenales;
                    documento.FileReciboLuzAguaBy = docAguaLuz;
                    documento.FileEquifaxBy = docFax;
                    documento.EstadoC = "P";
                    ctx.Documentos.Add(documento);
                    ctx.SaveChanges();

                    DetalleGrupo detalleGrupoDoc = detalleGrupoOriginal;
                    detalleGrupoDoc.IdDocumentosI = documento.IdDocumentoI;

                    ctx.Entry(detalleGrupoOriginal).CurrentValues.SetValues(detalleGrupoDoc);
                    ctx.SaveChanges();

                    return documento;
                }
                else
                {
                    Documento documentoOriginal = ctx.Documentos.SingleOrDefault(d => d.IdDocumentoI == detalleGrupoOriginal.IdDocumentosI);

                    documentoOriginal.FileDocIdentidadBy = docInden;
                    documentoOriginal.FileAntecedentesPenalesBy = docPenales;
                    documentoOriginal.FileReciboLuzAguaBy = docAguaLuz;
                    documentoOriginal.FileEquifaxBy = docFax;
                    documentoOriginal.EstadoC = "P";

                    ctx.Entry(documentoOriginal).CurrentValues.SetValues(x_documento);
                    ctx.SaveChanges();

                    return documentoOriginal;
                }
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

        public static byte[] ConvertBase64ToByteArray(string base64String)
        {
            // Verificar si la cadena es nula o vacía
            if (string.IsNullOrEmpty(base64String))
            {
                throw new ArgumentException("La cadena Base64 no puede ser nula o vacía.");
            }

            // Eliminar prefijos comunes en Base64, como "data:image/png;base64,"
            if (base64String.Contains("base64,"))
            {
                base64String = base64String.Split("base64,")[1]; // Eliminar todo lo que esté antes de "base64,"
            }

            // Eliminar cualquier espacio en blanco extra
            base64String = base64String.Replace("\n", "").Replace("\r", "").Trim();

            try
            {
                // Convertir la cadena Base64 a un arreglo de bytes
                return Convert.FromBase64String(base64String);
            }
            catch (FormatException ex)
            {
                throw new FormatException("La cadena Base64 no tiene un formato válido.", ex);
            }
        }
    }
}
