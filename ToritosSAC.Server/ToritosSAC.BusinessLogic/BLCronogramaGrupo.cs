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
    public class BLCronogramaGrupo
    {
        public Resultado<bool> BLCRGR_CrearCronogramaGrupo(int idGrupo, DateTime fechaInicio)
        {
            try
            {
                DAGrupo DaGrupo = new DAGrupo();
                DACronogramaGrupo dACronogramaGrupo = new DACronogramaGrupo();
                Grupo grupo = DaGrupo.DAGRUP_ObtenerGrupoPorId(idGrupo);
                List<CronogramaGrupo> listaCronograma = new List<CronogramaGrupo>();

                int numCuota = 1;
                decimal cuotaGrupal = 0;
                decimal montoPeriodo = grupo.PrecioUnidadVehiculoM;
                DateTime dateCuota = fechaInicio;
                for(int i=0; i < grupo.CantidadCuotasI; i++)
                {
                    numCuota = i+1;
                    cuotaGrupal = (decimal)(grupo.MontoCuotaN * grupo.CantMaxIntegrantesI * numCuota);

                    CronogramaGrupo cronogramaGrupo = new CronogramaGrupo
                    {
                        IdGrupoI = idGrupo,
                        FechaD = dateCuota,
                        CuotaIndividualN = (decimal)grupo.MontoCuotaN * numCuota,
                        CuotaGrupalN = cuotaGrupal,
                        HabilitarSorteoB = cuotaGrupal % grupo.PrecioUnidadVehiculoM == 0? true: false,
                        HabilitarMartillazoB = montoPeriodo > grupo.PrecioUnidadVehiculoM &&
                                               montoPeriodo - (grupo.PrecioUnidadVehiculoM / 2) < cuotaGrupal? 
                                               true: false
                    };

                    listaCronograma.Add(cronogramaGrupo);
                    dateCuota = grupo.TipoPeriodoPagoC == "D" ? dateCuota.AddDays(1) :
                                  grupo.TipoPeriodoPagoC == "S" ? dateCuota.AddDays(7) :
                                  grupo.TipoPeriodoPagoC == "Q" ? dateCuota.AddDays(15) :
                                  dateCuota.AddMonths(1);

                    if (cuotaGrupal % grupo.PrecioUnidadVehiculoM == 0)
                    {
                        montoPeriodo = montoPeriodo + grupo.PrecioUnidadVehiculoM;
                    }
                }

                bool estadoGuardado = dACronogramaGrupo.DACRGR_GuardarCronogramaGrupo(listaCronograma);

                grupo.FechaInicioPanderoD = fechaInicio;
                DaGrupo.DAGRUP_IniciarCronogramaGrupo(grupo.IdGrupoI, fechaInicio);
                return new Resultado<bool>(estadoGuardado, "Cronograma generado exitosamente", true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Resultado<List<CronogramaGrupo>> BLCRGR_ObtenerCronogramaGrupo(int idGrupo)
        {
            try
            {
                DACronogramaGrupo dACronogramaGrupo = new DACronogramaGrupo();
                List<CronogramaGrupo> cronogramaGrupos = dACronogramaGrupo.DACRGR_ObtenerListaCronogramaGrupo(idGrupo);

                return new Resultado<List<CronogramaGrupo>>(cronogramaGrupos, "Cronograma obtenido exitosamente", true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
