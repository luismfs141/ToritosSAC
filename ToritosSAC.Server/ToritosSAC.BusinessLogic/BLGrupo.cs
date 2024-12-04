using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToritosSAC.DataAccess;
using ToritosSAC.Entities;

namespace ToritosSAC.BusinessLogic
{
    public class BLGrupo
    {
        public static string msg = string.Empty;
        public string BLGRUP_ObtenerGrupoPorCodigo(string x_codigo)
        {
            DAGrupo dAgrupo = new DAGrupo();

            Grupo grupo = dAgrupo.DAGRUP_ObtenerGrupoPorCodigo(x_codigo);

            if(grupo == null)
            {
                msg = "Error, grupo no encontrado";
            }

            return msg;
        }
        public bool BLGRUP_UnirseGrupo(Grupo x_grupo, Cliente x_cliente, Documento x_documento)
        {
            bool resultado = false; 

            if (x_grupo.EstadoC == "E" && x_cliente.EstadoC == "B" && x_documento.EstadoC == "A")
            {
                DAGrupo dAGrupo = new DAGrupo();
                bool proceso = dAGrupo.DAGRUP_UnirseGrupo(x_grupo, x_cliente, x_documento);
            }
            else
            {
                if (x_grupo.EstadoC == "I") msg = "El grupo ya está inicializado.";
                else if (x_grupo.EstadoC == "F") msg = "El grupo ha finalizado.";

                if (x_cliente.EstadoC == "D") msg = "No puede unirse al grupo, tiene deudas pendientes.";
                else if (x_cliente.EstadoC == "C") msg = "Necesita ser \"Buen Pagador\" para unirse al grupo.";

                if (x_documento.EstadoC == "V") msg = "Su documento aún está en verificación.";
                else if (x_documento.EstadoC == "C") msg = "Su documento ha sido rechazado.";
            }

            if (!string.IsNullOrEmpty(msg))
            {
                throw new Exception(msg);
            }

            return resultado; 
        }
        public string BLGRUP_CrearGrupo(Grupo x_grupo)
        {
            DAGrupo dAGrupo = new DAGrupo();
            Grupo grupo = dAGrupo.DAGRUP_CrearGrupo(x_grupo);

            if (grupo == null)
            {
                msg = "Error, nos se pudo crear el grupo";
            }
            return msg;
        }
    }
}
