﻿using Data.DbAccess;
using Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class ProductoMenuListModelConverterService : IModelViewModelConverter<ProductoMenu, ProductoMenuListViewModel>
    {
        public IEnumerable<ProductoMenuListViewModel> ConvertfromListToViewModel(IEnumerable<ProductoMenu> original)
        {
            List<ProductoMenuListViewModel> productosMenuesView = new List<ProductoMenuListViewModel>();

            foreach (var item in original)
            {
                var producto = GetService.GetProductoService().FindById(item.CodigoProducto);
                var categoriaProducto = GetService.GetCategoriaProductoService().FindById(producto.CodigoCategoria);
                ProductoMenuListViewModel productoMenuView = new ProductoMenuListViewModel
                {
                    CodigoProductoMenu = item.CodigoProductoMenu,
                    CodigoProducto = item.CodigoProducto,
                    ImagenPrincipal = GetService.GetImagenService().ListSortedByGivenCategoryId(item.CodigoProducto).FirstOrDefault().Imagen,
                    Producto = GetService.GetProductoService().FindById(item.CodigoProducto),
                    Precio = item.Precio,
                    Categoria = categoriaProducto
                };
                productosMenuesView.Add(productoMenuView);
            }
            return productosMenuesView;
        }

        public ProductoMenu ConvertFromViewModel(ProductoMenuListViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductoMenu> ConvertListFromViewModel(IEnumerable<ProductoMenuListViewModel> viewModel)
        {
            throw new NotImplementedException();
        }

        public ProductoMenuListViewModel ConvertToViewModel(ProductoMenu original)
        {
            throw new NotImplementedException();
        }
    }
}
