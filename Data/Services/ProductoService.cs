using Data.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class ProductoService : ISingleModelSystemService<Producto>
    {
        public Producto FindById(int id)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var producto = context.Productos.Find(id);

                return producto;
            }
        }

        public void Insert(Producto producto)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                context.Productos.Add(producto);
                context.SaveChanges();
            }
        }

        public IEnumerable<Producto> ListAll()
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var productos = context.Productos.ToList();

                return productos;
            }
        }

        public IEnumerable<Producto> ListSortedByGivenCategoryId(int id)
        {
            throw new NotImplementedException();
        }

        public void SoftDelete(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateSingleObject(Producto objectType)
        {
            throw new NotImplementedException();
        }
        public Producto GetLastProducto()
        {
            using(var context = GetService.GetRestauranteEntityService())
            {
                var producto = context.Productos.ToList().LastOrDefault();

                return producto;
            }
        }
        public List<Producto> GetProductosNotInSucursalMenu(int idMenu)
        {
            var productos = GetService.GetRestauranteEntityService().Productos.ToList().Where(x => x.Borrado == false);
            var sucursalProductoMenu = GetService.GetProductoMenuService().ListSortedByGivenCategoryId(idMenu).Where(x => x.Borrado == false);

            List<Producto> productosNotInSucursalMenu = new List<Producto>();

            foreach (var item in productos)
            {
                Producto producto = new Producto();
                if (sucursalProductoMenu.Where(x => x.CodigoProducto == item.CodigoProducto).Count() == 0)
                {
                    producto = item;
                    productosNotInSucursalMenu.Add(producto);
                }
            }
            return productosNotInSucursalMenu;
        }
    }
}
