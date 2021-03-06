﻿using Data.DbAccess;
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
            using (var context = GetService.GetRestauranteEntityService())
            {
                var productos = context.ProductosMenues.ToList().Where(x => x.CodigoMenu == idMenu & x.Borrado == false);

                return productos;
            }
        }

        public void SoftDelete(int id)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var productoMenu = context.ProductosMenues.Find(id);
                productoMenu.Borrado = true;

                context.SaveChanges();
            }
        }

        public void UpdateSingleObject(ProductoMenu productoMenu)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var producto = context.ProductosMenues.Find(productoMenu.CodigoProductoMenu);
                producto.Precio = productoMenu.Precio;

                context.SaveChanges();
            }
        }
        public ProductoMenu GetProductoMenuByMenuIdProductoId(int codigoMenu, int codigoProducto)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var productoMenu = context.ProductosMenues.ToList().Where(x => x.CodigoMenu == codigoMenu & x.CodigoProducto == codigoProducto).FirstOrDefault();

                return productoMenu;
            }
        }
    }
}
