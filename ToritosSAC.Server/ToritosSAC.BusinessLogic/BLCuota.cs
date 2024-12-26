using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToritosSAC.Entities;
using ToritosSAC.DataAccess;
using ToritosSAC.Entities.Structures;

namespace ToritosSAC.BusinessLogic
{
    public class BLCuota
    {
        public Resultado<int> BLCUOT_GenerarCuotasClientesGrupo(int idGrupo)
        {
            try
            {
                DAGrupo dAGrupo = new DAGrupo();
                DACuota dACuota = new DACuota();

                List<DetalleGrupo> detalleGrupos = new List<DetalleGrupo>();
                List<Cuotum> listaCuotas = new List<Cuotum>();
                Grupo grupo = new Grupo();

                detalleGrupos = dAGrupo.DAGRUP_ObtenerDetallesGrupoPorIdGrupo(idGrupo);
                grupo = dAGrupo.DAGRUP_ObtenerGrupoPorId(idGrupo);

                foreach(DetalleGrupo detalleGrupo in detalleGrupos)
                {
                    List<Cuotum> cuotasCliente = new List<Cuotum>();
                    DateTime fechaInic = (DateTime)grupo.FechaInicioPanderoD;
                    for(int i=0; i<grupo.CantidadCuotasI; i++)
                    {
                        DateTime fechaFin = grupo.TipoPeriodoPagoC == "D" ? fechaInic.AddDays(1) :
                                            grupo.TipoPeriodoPagoC == "S" ? fechaInic.AddDays(7) :
                                            grupo.TipoPeriodoPagoC == "Q" ? fechaInic.AddDays(15) :
                                            fechaInic.AddMonths(1);

                        Cuotum cuotum = new Cuotum
                        {
                            IdDetalleGrupo = detalleGrupo.IdDetalleGrupoI,
                            NumCuotaI = i + 1,
                            MontoCuotaN = (decimal)grupo.MontoCuotaN,
                            FechaInicioD = fechaInic,
                            FechaFinD = fechaFin,
                            EstadoCuotaC = "P",
                            PenalidadN = 0
                        };

                        fechaInic = grupo.TipoPeriodoPagoC == "D" ? fechaInic.AddDays(1) :
                                            grupo.TipoPeriodoPagoC == "S" ? fechaInic.AddDays(7) :
                                            grupo.TipoPeriodoPagoC == "Q" ? fechaInic.AddDays(15) :
                                            fechaInic.AddMonths(1);
                        cuotasCliente.Add(cuotum);
                    }
                    listaCuotas.AddRange(cuotasCliente);
                }

                int cuotasCreadas = dACuota.DACUOT_GuardarCuotas(listaCuotas);

                return new Resultado<int>(cuotasCreadas, "Cuotas generadas correctamente.", true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Resultado<List<Cuotum>> BLCUOT_ListarCuotasClienteGrupo(int idCliente, int idGrupo)
        {
            try
            {
                DACuota dACuota = new DACuota();
                List<Cuotum> cuotas = dACuota.DACUOT_ListarCuotasClienteGrupo(idCliente, idGrupo);

                return new Resultado<List<Cuotum>>(cuotas, "Cuotas obtenidas correctamente.", true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Resultado<int> BLCUOT_RecalcularCuotasClienteGrupo(int idCliente, int idGrupo, decimal montoPagado)
        {
            try
            {
                DACuota dACuota = new DACuota();

                List<Cuotum> listaCuotas = dACuota.DACUOT_ListarCuotasClienteGrupo(idCliente, idGrupo);

                decimal montoCalcular = montoPagado - listaCuotas[0].MontoCuotaN;
                int numCuotasEliminar = (int)Math.Floor(montoCalcular / listaCuotas[0].MontoCuotaN);
                decimal montoRestanteCuota = montoCalcular % listaCuotas[0].MontoCuotaN;

                List<Cuotum> cuotasAEliminar = new List<Cuotum>();

                for (int i = listaCuotas.Count - 1; i >= 0 && numCuotasEliminar > 0; i--)
                {
                    cuotasAEliminar.Add(listaCuotas[i]);
                    numCuotasEliminar--;
                }

                if(montoCalcular % listaCuotas[0].MontoCuotaN != 0)
                {
                    Cuotum cuota = listaCuotas[(listaCuotas.Count)-numCuotasEliminar];
                    cuota.MontoCuotaN = montoCalcular % listaCuotas[0].MontoCuotaN;
                    dACuota.DACOUT_GuardarCuota(cuota);
                }

                foreach(Cuotum cuota in listaCuotas)
                {
                    if(cuota.EstadoCuotaC == "P")
                    {
                        cuota.EstadoCuotaC = "A";
                        dACuota.DACOUT_GuardarCuota(cuota);
                        break;
                    }
                }

                dACuota.DACUOT_EliminarCuotas(cuotasAEliminar);

                return new Resultado<int>(numCuotasEliminar, "Las cuotas han sido actualizadas.", true);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<Cuotum> BLCUOT_EliminarCuotasPendientes(List<Cuotum> cuotas)
        {
            DACuota dACuota = new DACuota();

            List<Cuotum> listaCuotasPendientes = cuotas.Where(c => c.EstadoCuotaC == "P").ToList();

            dACuota.DACUOT_EliminarCuotas(listaCuotasPendientes);
            cuotas.RemoveAll(c => c.EstadoCuotaC == "P");

            return cuotas;
        }
    }
}
