using Data.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class ClienteService : ISingleModelSystemService<Cliente>
    {
        public Cliente FindById(int id)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var cliente = context.Clientes.Where(x => x.CodigoCliente == id & x.Borrado == false).SingleOrDefault();

                return cliente;
            }
        }

        public void Insert(Cliente cliente)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var usuario = GetService.GetUsuarioService().FindLastUsuario();
                cliente.CodigoUsuario = usuario.CodigoUsuario;
                context.Clientes.Add(cliente);

                context.SaveChanges();
            }
        }

        public IEnumerable<Cliente> ListAll()
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var clientes = context.Clientes.ToList().Where(x => x.Borrado == false);

                return clientes;
            }
        }

        public IEnumerable<Cliente> ListSortedByGivenCategoryId(int id)
        {
            throw new NotImplementedException();
        }

        public void SoftDelete(int id)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var cliente = FindById(id);
                cliente.Borrado = true;
                UpdateSingleObject(cliente);

                context.SaveChanges();
            }
        }
        public void UpdateSingleObject(Cliente clienteModificado)
        {
            GetService.GetRestauranteEntityService().SaveChanges();
            using (var context = GetService.GetRestauranteEntityService())
            {
                var clienteOriginal = FindById(clienteModificado.CodigoCliente);
                clienteOriginal = clienteModificado;

                context.SaveChanges();
            }
        }
        public Cliente GetClienteFromUserName(string username)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var usuario = GetService.GetUsuarioService().FindUserByUsername(username);
                var cliente = context.Clientes.Where(x => x.CodigoUsuario == usuario.CodigoUsuario).SingleOrDefault();

                return cliente;
            }
        }
    }
}
