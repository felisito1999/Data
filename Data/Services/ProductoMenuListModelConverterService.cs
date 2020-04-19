using Data.DbAccess;
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
                ProductoMenuListViewModel productoMenuView = new ProductoMenuListViewModel
                {
                    CodigoProductoMenu = item.CodigoProductoMenu,
                    CodigoProducto = item.CodigoProducto,
                    ImagenPrincipal = null,
                    Producto = GetService.GetProductoService().FindById(item.CodigoProducto),
                    Precio = item.Precio
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
