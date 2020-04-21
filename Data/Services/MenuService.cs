using Data.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class MenuService : ISingleModelSystemService<Menu>
    {
        public Menu FindById(int id)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var menu = context.Menues.Find(id);

                return menu;
            }
        }

        public void Insert(Menu menu)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                context.Menues.Add(menu);

                context.SaveChanges();
            }
        }

        public IEnumerable<Menu> ListAll()
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var menues = context.Menues.ToList().Where(x => x.Borrado == false);

                return menues;
            }
        }

        public IEnumerable<Menu> ListSortedByGivenCategoryId(int idSucursal)
        {
            throw new NotImplementedException();
        }

        public void SoftDelete(int id)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var usuario = FindById(id);
                usuario.Borrado = true;
                context.SaveChanges();
            }
        }

        public void UpdateSingleObject(Menu objectType)
        {
            throw new NotImplementedException();
        }
        public Menu GetMenuBySucursalId(int idSucursal)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var menuSucursal = ListAll().Where(x => x.CodigoSucursal == idSucursal).SingleOrDefault();

                return menuSucursal;
            }
        }
    }
}
