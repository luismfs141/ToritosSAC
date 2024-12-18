using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using ToritosSAC.DataAccess;
using ToritosSAC.DataAccess.Context;
using ToritosSAC.Entities;
using ToritosSAC.Entities.Structures;


namespace ToritosSAC.BusinessLogic
{
    public class BLEstadoCuenta
    {
        public Resultado<bool> BLESCU_CrearCronogramaPorGrupo(int idGrupo, DateTime fechaInicio)
        {
            IDbContextTransaction transaction = null; // Usamos IDbContextTransaction en lugar de SqlTransaction
            try
            {
                bool exito = false;
                DateTime fecha = fechaInicio;

                DAGrupo dAGrupo = new DAGrupo();
                DAModelo dAModelo = new DAModelo();
                DAEstadoCuenta dAEstadoCuenta = new DAEstadoCuenta();

                Grupo grupo = dAGrupo.DAGRUP_ObtenerGrupoPorId(idGrupo);
                Modelo modelo = dAModelo.DAMODE_ObtenerModeloVehiculoPorId(grupo.IdModeloVehiculoI);
                List<DetalleGrupo> detalleGrupos = dAGrupo.DAGRUP_ObtenerDetallesGrupoPorIdGrupo(idGrupo);

                if (grupo.EstadoC != "A")
                {
                    return new Resultado<bool>(false, "El estado del grupo no es el indicado. No se puede iniciar la transacción.", false);
                }

                // Comprobar que el número de integrantes del grupo coincida con el número de detalles
                if (grupo.CantMaxIntegrantesI != detalleGrupos.Count)
                {
                    return new Resultado<bool>(false, "No cumple con el número de integrantes de grupo. No se puede iniciar la transacción.", false);
                }

                int cantCuotas = grupo.CantidadCuotasI;
                decimal montoTotal = (decimal)modelo.PrecioUnidadVehiculoM;
                int periodoEnDias = ObtenerPeriodoEnDias(grupo.TipoPeriodoPagoC);

                // Inicializamos el contexto de la base de datos
                using (ToritosDbContext ctx = new ToritosDbContext())
                {
                    // Iniciar la transacción en el DbContext
                    transaction = ctx.Database.BeginTransaction(); // Usamos BeginTransaction() de EF

                    List<DetalleEstadoCuentum> detallesEstadoCuentum = new List<DetalleEstadoCuentum>(); // Lista para almacenar los detalles

                    // Crear las cuotas para el cronograma
                    for (int i = 0; i < cantCuotas; i++)
                    {
                        foreach (DetalleGrupo detalleGrupo in detalleGrupos)
                        {
                            DetalleEstadoCuentum det = new DetalleEstadoCuentum
                            {
                                IdDetalleGrupoI = detalleGrupo.IdDetalleGrupoI,
                                NroCuotaI = i + 1,
                                MontoCuotaM = (decimal)grupo.MontoCuotaN,
                                FechaPagoProgramadaD = fechaInicio.AddDays(periodoEnDias * i),
                                FechaPagoRealD = null,
                                EstadoCuotaC = "D",
                                PenalidadMontoM = 0,
                                PenalidadFechaPagoD = null,
                                MartillazoMontoM = 0,
                                MartillazoFechaPagoD = null
                            };

                            detallesEstadoCuentum.Add(det);  // Agregar el detalle a la lista
                        }
                    }

                    // Guardar todos los detalles de estado de cuenta en bloque dentro de la transacción
                    dAEstadoCuenta.DAESCU_GuardarEstadoCuenta(detallesEstadoCuentum, ctx, transaction);

                    // Confirmar la transacción si todo fue exitoso
                    transaction.Commit();
                    exito = true;

                    dAGrupo.DAGRUP_IniciarCronogramaGrupo(grupo.IdGrupoI, fecha);

                    return new Resultado<bool>(exito, "Cronograma creado con éxito.", exito);
                }
            }
            catch (Exception ex)
            {
                // Si ocurre una excepción, revertir la transacción
                transaction?.Rollback();

                // Registrar el error y lanzar la excepción
                throw new ApplicationException("Error al crear el cronograma por grupo.", ex);
            }
        }

        public Resultado<List<DetalleEstadoCuentum>> BLESCU_ObtenerDetallesCuentaPorIdClienteGrupo(int idCliente, int idGrupo)
        {
            try
            {
                DAEstadoCuenta dAEstadoCuenta = new DAEstadoCuenta();
                List<DetalleEstadoCuentum> detalleEstados = dAEstadoCuenta.DAESCU_ObtenerEstadoCuentaPorIdClienteGrupo(idCliente, idGrupo);

                if (detalleEstados.Count > 0)
                {
                    return new Resultado<List<DetalleEstadoCuentum>>(detalleEstados, "Detalles obtenidos con exito.", true);
                }
                else
                {
                    return new Resultado<List<DetalleEstadoCuentum>>(null, "El cliente no tiene estados de cuenta.", false);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al obtener los estados de cuenta.", ex);
            }
        }

        // Método auxiliar para obtener los días del periodo según el tipo
        private int ObtenerPeriodoEnDias(string tipoPeriodo)
        {
            var periodos = new Dictionary<string, int>
            {
                { "D", 1 },
                { "S", 7 },
                { "Q", 15 },
                { "M", 30 }
            };

            return periodos.ContainsKey(tipoPeriodo) ? periodos[tipoPeriodo] : 0;
        }
    }
}
