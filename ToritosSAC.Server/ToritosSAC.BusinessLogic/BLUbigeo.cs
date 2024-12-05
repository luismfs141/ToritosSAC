using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToritosSAC.Entities;
using ToritosSAC.DataAccess;

namespace ToritosSAC.BusinessLogic
{
    public class BLUbigeo
    {
        public List<Departamento> BLUBIG_ObtenerDepartamentos()
        {
            DAUbigeo dAUbigeo = new DAUbigeo();
            return dAUbigeo.DAUBIG_ObtenerDepartamentos();
        }

        public List<Provincium> BLUBIG_ObtenerProvinciaPorDepartamento(string idDepartamento)
        {
            DAUbigeo dAUbigeo = new DAUbigeo();
            return dAUbigeo.DAUBIG_ObtenetProvinciaPorDepartamento(idDepartamento);
        }
        public List<Distrito> BLUBIG_ObtenerDistritoPorProvincia(string idProvincia)
        {
            DAUbigeo dAUbigeo = new DAUbigeo();
            return dAUbigeo.DAUBIG_ObtenerDistritoPorProvincia(idProvincia);
        }
    }
}
