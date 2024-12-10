using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToritosSAC.DataAccess;

namespace ToritosSAC.BusinessLogic
{
    public class BLRol
    {
        public static DataTable ListarRoles()
        {
            DARol Datos = new DARol();
            return Datos.Listar();
        }
    }
}
