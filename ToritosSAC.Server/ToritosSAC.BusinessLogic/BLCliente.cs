using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToritosSAC.DataAccess;
using ToritosSAC.Entities;

namespace ToritosSAC.BusinessLogic
{
    public class BLCliente
    {
        public Cliente BLCLIE_GuardarCliente(Cliente x_cliente)
        {
            DACliente dACliente = new DACliente();

            return dACliente.DACLIE_GuardarCliente(x_cliente);
        }

        public Cliente BLCLIE_LoginCliente(string correo, string password)
        {
            DACliente dACliente = new DACliente();

            return dACliente.DACLIE_LoginCliente(correo, password);
        }
    }
}
