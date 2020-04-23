using Data.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class OrdenDetalleService : ISingleModelSystemService<OrdenDetalle>
    {
        public OrdenDetalle FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(OrdenDetalle ordenDetalle)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                context.OrdenesDetalles.Add(ordenDetalle);

                context.SaveChanges();
            }
        }

        public IEnumerable<OrdenDetalle> ListAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrdenDetalle> ListSortedByGivenCategoryId(int codigoOrden)
        {

            using (var context = GetService.GetRestauranteEntityService())
            {
                var ordenesDetalles = context.OrdenesDetalles.ToList().Where(x => x.CodigoOrden == codigoOrden & x.Borrado == false);

                return ordenesDetalles;
            }
        }

        public void SoftDelete(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateSingleObject(OrdenDetalle objectType)
        {
            throw new NotImplementedException();
        }
    }
}
