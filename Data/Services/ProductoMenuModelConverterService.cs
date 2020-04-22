using Data.DbAccess;
using Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class ProductoMenuModelConverterService : IModelViewModelConverter<ProductoMenu, ProductoMenuViewModel>
    {
        public IEnumerable<ProductoMenuViewModel> ConvertfromListToViewModel(IEnumerable<ProductoMenu> original)
        {
            throw new NotImplementedException();
        }

        public ProductoMenu ConvertFromViewModel(ProductoMenuViewModel viewModel)
        {
            ProductoMenu productoMenu = new ProductoMenu
            {
                CodigoProductoMenu = viewModel.CodigoProductoMenu,
                CodigoProducto = viewModel.CodigoProducto,
                Precio = viewModel.Precio,
                CodigoMenu = viewModel.CodigoMenu,
                Borrado = false
            };
            return productoMenu;
        }

        public IEnumerable<ProductoMenu> ConvertListFromViewModel(IEnumerable<ProductoMenuViewModel> viewModel)
        {
            throw new NotImplementedException();
        }

        public ProductoMenuViewModel ConvertToViewModel(ProductoMenu original)
        {
            ProductoMenuViewModel productoMenuView = new ProductoMenuViewModel
            {
                CodigoProductoMenu = original.CodigoProductoMenu,
                CodigoProducto = original.CodigoProducto,
                NombreProducto = GetService.GetProductoService().FindById(original.CodigoProducto).NombreProducto,
                DescripcionProducto = GetService.GetProductoService().FindById(original.CodigoProducto).DescripcionProducto,
                Costo = GetService.GetProductoService().FindById(original.CodigoProducto).Costo,
                CodigoMenu = original.CodigoMenu,
                Precio = original.Precio,
            };
            return productoMenuView;
        }
    }
}
