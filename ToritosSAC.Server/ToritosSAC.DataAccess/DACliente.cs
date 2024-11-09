using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToritosSAC.DataAccess.Context;
using ToritosSAC.Entities;
using System.Security.Cryptography;
using System.Text;

namespace ToritosSAC.DataAccess
{
    public class DACliente
    {
        public List<Cliente> DACLIE_ObtenerClientes()
        {
            ToritosDbContext ctx = new ToritosDbContext();

            var clientes = ctx.Clientes.ToList();

            return clientes;
        }

        public Cliente DACLIE_LoginCliente(string x_usuario, string x_password)
        {
            //Login de clientes
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();

                byte[] passwordBytes = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(x_password));

                var cliente = ctx.Clientes
                    .Where(x => x.NroDocumentoV == x_usuario && x.PasswordBi == passwordBytes)
                    .SingleOrDefault();

                return cliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
