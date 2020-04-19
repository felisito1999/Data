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
            //ProductoMenu productoMenu = new ProductoMenu
            //{
            //    CodigoProductoMenu = viewModel.CodigoProductoMenu,
            //    CodigoProducto = viewModel.CodigoProducto,
            //    Precio = viewModel.Precio,
            //    CodigoMenu = viewModel.Men

            //}
            throw new NotImplementedException();
        }

        public IEnumerable<ProductoMenu> ConvertListFromViewModel(IEnumerable<ProductoMenuViewModel> viewModel)
        {
            throw new NotImplementedException();
        }

        public ProductoMenuViewModel ConvertToViewModel(ProductoMenu original)
        {
            throw new NotImplementedException();
        }
    }
}
