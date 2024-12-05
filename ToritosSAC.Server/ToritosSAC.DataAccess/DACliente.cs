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
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();

                //Codificacion de password
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

        public List<Cliente> DACLIE_ObtenerClientesPorGrupo(int idCliente)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();
                DAGrupo dAGrupo = new DAGrupo();

                Grupo grupo = dAGrupo.DAGRUP_ObtenerGrupoPorCliente(idCliente);

                if (grupo == null)
                {
                    return new List<Cliente>();
                }

                var clientes = (from c in ctx.Clientes
                                join dg in ctx.DetalleGrupos on c.IdClienteI equals dg.IdClienteI
                                where dg.IdGrupoI == grupo.IdGrupoI
                                select c).ToList();

                List<Cliente> x = clientes;

                return clientes;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los clientes para el grupo", ex);
            }
        }

        public Cliente DACLIE_ObtenerClientePorId(int idCliente)
        {
            try
            {
                ToritosDbContext ctx = new ToritosDbContext();
                var cliente = ctx.Clientes
                    .Where(x => x.IdClienteI == idCliente)
                    .SingleOrDefault();
                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el cliente", ex);
            }
        }
    }
}
