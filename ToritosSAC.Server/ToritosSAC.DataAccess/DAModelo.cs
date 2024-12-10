using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToritosSAC.Entities;
using ToritosSAC.DataAccess.Context;

namespace ToritosSAC.DataAccess
{
    public class DAModelo
    {
        public Modelo DAMODE_GuardarModelo(Modelo x_modelo)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();

                if(x_modelo.IdModeloVehiculoI == 0)
                {
                    ctx.Modelos.Add(x_modelo);
                }
                else
                {
                    Modelo modeloOriginal = ctx.Modelos.SingleOrDefault(m => m.IdModeloVehiculoI == x_modelo.IdModeloVehiculoI);
                    ctx.Entry(modeloOriginal).CurrentValues.SetValues(x_modelo);
                }
                ctx.SaveChanges();

                return x_modelo;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al guardar el modelo de vehículo.", ex);
            }
        }
        public List<Modelo> DAMODE_ObtenerModelos()
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();
                return ctx.Modelos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al obtener el modelo de vehículos.", ex);
            }
        }
    }
}
