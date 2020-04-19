using Data.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class SucursalService : ISingleModelSystemService<Sucursal>
    {
        public Sucursal FindById(int id)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var sucursal = context.Sucursales.Find(id);

                return sucursal;
            }
        }

        public void Insert(Sucursal sucursal)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                context.Sucursales.Add(sucursal);

                context.SaveChanges();
            }
        }

        public IEnumerable<Sucursal> ListAll()
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var sucursales = context.Sucursales.ToList();

                return sucursales;
            }
        }

        public IEnumerable<Sucursal> ListSortedByGivenCategoryId(int idCategory)
        {
            throw new NotImplementedException();
        }

        public void SoftDelete(int id)
        {
            throw new NotImplementedException();
        }
        public void UpdateSingleObject(Sucursal objectType)
        {
            throw new NotImplementedException();
        }
        public Sucursal GetLastSucursal()
        {
            var lastSucursal = ListAll().Last();

            return lastSucursal;
        }
    }
}
