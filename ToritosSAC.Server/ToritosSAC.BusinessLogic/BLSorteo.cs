using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToritosSAC.Entities.Structures;
using ToritosSAC.Entities;
using ToritosSAC.DataAccess;

namespace ToritosSAC.BusinessLogic
{
    public class BLSorteo
    {
        public Resultado<List<SorteoStruct>> BLSORT_ObtenerSorteosPorGrupo(int idGrupo)
        {
            try
            {
                DASorteo dASorteo = new DASorteo();
                DAGrupo dAGrupo = new DAGrupo();
                DACliente dACliente = new DACliente();

                List<Sorteo> sorteos = dASorteo.DASORT_ObtenerSorteosPorGrupo(idGrupo);
                List<DetalleGrupo> detallesGrupo = dAGrupo.DAGRUP_ObtenerDetallesGrupoPorIdGrupo(idGrupo);
                List<SorteoStruct> sorteosStruct = new List<SorteoStruct>();

                foreach (Sorteo sorteo in sorteos)
                {
                    int idCliente = detallesGrupo.Find(d => d.IdDetalleGrupoI == sorteo.IdDetalleGrupoI).IdClienteI;
                    Cliente cliente = dACliente.DACLIE_ObtenerClientePorId(idCliente);

                    SorteoStruct sorteoStruct = new SorteoStruct
                    {
                        IdSorteo = sorteo.IdSorteoI,
                        IdCliente = idCliente,
                        IdGrupo = idGrupo,
                        NombreCliente = cliente.NombreNv +" "+cliente.ApellidoPaternoNv+" "+cliente.ApellidoMaternoNv,
                        FechaSorteo = sorteo.FechaD,
                        Modalidad = sorteo.TipoSorteoC
                    };
                    sorteosStruct.Add(sorteoStruct);
                }

                if(sorteosStruct !=null && sorteosStruct.Count() > 0)
                {
                    return new Resultado<List<SorteoStruct>>(sorteosStruct, "Sorteos obtenidos exitosamente.", true);
                }
                else
                {
                    return new Resultado<List<SorteoStruct>>(null, "El grupo no tiene sorteos.", true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Resultado<Sorteo> BLSORT_GuardarSorteo(Sorteo x_sorteo)
        {
            try
            {
                DASorteo dASorteo = new DASorteo();
                Sorteo sorteo = dASorteo.DASORT_GuardarSorteo(x_sorteo);
                return new Resultado<Sorteo>(sorteo, "Sorteo guardado exitosamente.", true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Resultado<DateTime> BLSORT_ObtenerProximoFechaSorteo(int idGrupo)
        {
            try
            {
                DACronogramaGrupo dACronogramaGrupo = new DACronogramaGrupo();
                List<CronogramaGrupo> listaTodoCronograma = dACronogramaGrupo.DACRGR_ObtenerListaCronogramaGrupo(idGrupo);
                DateTime proximaFechaSorteo = listaTodoCronograma.FirstOrDefault(c => c.HabilitarSorteoB == true && c.FechaD >= DateTime.Now).FechaD;

                if(proximaFechaSorteo != null)
                {
                    return new Resultado<DateTime>(proximaFechaSorteo, "Próxima fecha de sorteo obtenida exitosamente.", true);
                }
                else
                {
                    return new Resultado<DateTime>(DateTime.Now, "No tiene fecha de sorteo.", false);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Resultado<MartillazoStruct> BLSORT_ObtenerMartillazoPeriodo(int idGrupo)
        {
            try
            {
                DACronogramaGrupo dACronogramaGrupo = new DACronogramaGrupo();
                List<CronogramaGrupo> listaTodoCronograma = dACronogramaGrupo.DACRGR_ObtenerListaCronogramaGrupo(idGrupo);
                int indiceCronogramaActual = listaTodoCronograma.FindIndex(c => c.FechaD.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"));

                CronogramaGrupo inicioPeriodo = new CronogramaGrupo();
                CronogramaGrupo finPeriodo = new CronogramaGrupo();

                if(indiceCronogramaActual < 0)
                {
                    indiceCronogramaActual = 0;
                }
                
                bool esMartillazo = false;

                if (listaTodoCronograma[indiceCronogramaActual].HabilitarMartillazoB == true)
                {
                    int indiceControl = indiceCronogramaActual;
                    while (listaTodoCronograma[indiceControl].HabilitarMartillazoB)
                    {
                        inicioPeriodo = listaTodoCronograma[indiceControl];
                        indiceControl--;
                    }
                    indiceControl = indiceCronogramaActual;
                    while (listaTodoCronograma[indiceControl].HabilitarMartillazoB)
                    {
                        finPeriodo = listaTodoCronograma[indiceControl];
                        indiceControl++;
                    }

                    MartillazoStruct martillazoStruct = new MartillazoStruct
                    {
                        Id = inicioPeriodo.IdCronogramaGrupoI,
                        FechaApertura = inicioPeriodo.FechaD,
                        FechaCierre = finPeriodo.FechaD,
                        MontoMartillazo = 1000,
                        Estado = true
                    };

                    return new Resultado<MartillazoStruct>(martillazoStruct, "Martillazo obtenido correctamente.", true);
                }
                else
                {
                    int indiceControl = indiceCronogramaActual;
                    while (esMartillazo == false)
                    {
                        if (listaTodoCronograma[indiceControl].HabilitarMartillazoB == true)
                        {
                            inicioPeriodo = listaTodoCronograma[indiceControl];
                            esMartillazo = true;
                        }
                        indiceControl++;
                    }
                    while (esMartillazo)
                    {
                        if (listaTodoCronograma[indiceControl].HabilitarMartillazoB == true)
                        {
                            finPeriodo = listaTodoCronograma[indiceControl];
                            indiceControl++;
                        }
                        else
                        {
                            esMartillazo = false;
                        }
                    }

                    MartillazoStruct martillazoStruct = new MartillazoStruct
                    {
                        Id = inicioPeriodo.IdCronogramaGrupoI,
                        FechaApertura = inicioPeriodo.FechaD,
                        FechaCierre = finPeriodo.FechaD,
                        MontoMartillazo = 1000,
                        Estado = false
                    };

                    return new Resultado<MartillazoStruct>(martillazoStruct, "Martillazo obtenido correctamente.", true);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
