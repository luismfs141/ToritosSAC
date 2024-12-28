using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToritosSAC.Entities;
using ToritosSAC.DataAccess.Context;

namespace ToritosSAC.DataAccess
{
    public class DACuota
    {
        public Cuotum DACUOT_ObtenerCuotaPorID(int idCuota)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();
                Cuotum cuota = ctx.Cuota.SingleOrDefault(c => c.IdCuotaI == idCuota);

                return cuota;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public int DACUOT_GuardarCuotas(List<Cuotum> cuotas)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();
                ctx.Cuota.AddRange(cuotas);
                ctx.SaveChanges();
                return cuotas.Count();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Cuotum DACOUT_GuardarCuota(Cuotum cuota)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();
                if(cuota.IdCuotaI == 0)
                {
                    ctx.Cuota.Add(cuota);
                }
                else
                {
                    Cuotum cuotaOriginal = ctx.Cuota.SingleOrDefault(c => c.IdCuotaI == cuota.IdCuotaI);
                    ctx.Entry(cuotaOriginal).CurrentValues.SetValues(cuota);
                }

                ctx.SaveChanges();
                return cuota;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DACUOT_EliminarCuotas(List<Cuotum> cuotas)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();
                ctx.Cuota.RemoveRange(cuotas);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Cuotum> DACUOT_ListarCuotasClienteGrupo(int idCliente, int idGrupo)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();
                DetalleGrupo detalleGrupo = ctx.DetalleGrupos.SingleOrDefault(d => d.IdClienteI == idCliente && d.IdGrupoI == idGrupo);
                List<Cuotum> cuotas = ctx.Cuota.Where(c => c.IdDetalleGrupo == detalleGrupo.IdDetalleGrupoI).ToList();

                return cuotas;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
