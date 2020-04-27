using Data.DbAccess;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class OrdenService : ISingleModelSystemService<Orden>
    {
        public Orden FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Orden orden)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                context.Ordenes.Add(orden);

                context.SaveChanges();
            }
        }

        public IEnumerable<Orden> ListAll()
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var ordenes = context.Ordenes.ToList();

                return ordenes;
            }
        }

        public IEnumerable<Orden> ListSortedByGivenCategoryId(string usernameCliente)
        {
            var cliente = GetService.GetClienteService().GetClienteFromUserName(usernameCliente);

            using (var context = GetService.GetRestauranteEntityService())
            {
                var ordenesCliente = context.Ordenes.ToList().Where(x => x.CodigoCliente == cliente.CodigoCliente & x.Borrado == false);

                return ordenesCliente;
            }
        }

        public void SoftDelete(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateSingleObject(Orden objectType)
        {
            throw new NotImplementedException();
        }
        public Orden FindLastOrden()
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var maxOrdenCodigo = context.Ordenes.ToList().Max(x => x.CodigoOrden);
                var orden = context.Ordenes.Find(maxOrdenCodigo);

                return orden;
            }
        }
        public IEnumerable<Orden> ListSortedByGivenCategoryId(int idCategory)
        {
            throw new NotImplementedException();
        }
    }
}
