using Data.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class ProductoMenuService : ISingleModelSystemService<ProductoMenu>
    {
        public ProductoMenu FindById(int id)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var productoMenu = context.ProductosMenues.Find(id); ;

                return productoMenu;
            }
        }

        public void Insert(ProductoMenu productoMenu)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                context.ProductosMenues.Add(productoMenu);

                context.SaveChanges();
            }
        }

        public IEnumerable<ProductoMenu> ListAll()
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var productos = context.ProductosMenues.ToList().Where(x => x.Borrado == false);

                return productos;
            }
        }

        public IEnumerable<ProductoMenu> ListSortedByGivenCategoryId(int idMenu)
        {
            var productos = ListAll().Where(x => x.CodigoMenu == idMenu);

            return productos;
        }

        public void SoftDelete(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateSingleObject(ProductoMenu objectType)
        {
            throw new NotImplementedException();
        }
    }
}
