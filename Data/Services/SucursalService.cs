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
                var sucursales = context.Sucursales.ToList().Where(x => x.Borrado == false);

                return sucursales;
            }
        }

        public IEnumerable<Sucursal> ListSortedByGivenCategoryId(int idCategory)
        {
            throw new NotImplementedException();
        }

        public void SoftDelete(int id)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var sucursal = context.Sucursales.Find(id);
                sucursal.Borrado = true;

                context.SaveChanges();
            }
        }
        public void UpdateSingleObject(Sucursal sucursalNueva)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var sucursalOriginal = context.Sucursales.Find(sucursalNueva.CodigoSucursal);
                sucursalOriginal.NombreSucursal = sucursalNueva.NombreSucursal;
                sucursalOriginal.DireccionSucursal = sucursalNueva.DireccionSucursal;
                sucursalOriginal.CodigoPais = sucursalNueva.CodigoPais;
                sucursalOriginal.CodigoProvincia = sucursalNueva.CodigoProvincia;
                context.SaveChanges();
            }
        }
        public Sucursal GetLastSucursal()
        {
            var lastSucursal = ListAll().Last();

            return lastSucursal;
        }
    }
}
