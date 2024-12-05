using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToritosSAC.DataAccess.Context;
using ToritosSAC.Entities;

namespace ToritosSAC.DataAccess
{
    public class DAUbigeo
    {
        public List<Departamento> DAUBIG_ObtenerDepartamentos()
        {
            ToritosDbContext ctx = new ToritosDbContext();

            return ctx.Departamentos.ToList();        
        }

        public List<Provincium> DAUBIG_ObtenetProvinciaPorDepartamento(string idDepartamento)
        {
            ToritosDbContext ctx = new ToritosDbContext();

            return ctx.Provincia.Where(p => p.IdDepartamentoC == idDepartamento).ToList();
        }

        public List<Distrito> DAUBIG_ObtenerDistritoPorProvincia(string idProvincia)
        {
            ToritosDbContext ctx = new ToritosDbContext();

            return ctx.Distritos.Where(d => d.IdProvinciaC == idProvincia).ToList();
        }
    }
}
