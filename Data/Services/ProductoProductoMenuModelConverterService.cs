using Data.DbAccess;
using Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class ProductoProductoMenuModelConverterService : IModelViewModelConverter<Producto, ProductoMenuViewModel>
    {
        public IEnumerable<ProductoMenuViewModel> ConvertfromListToViewModel(IEnumerable<Producto> original)
        {
            List<ProductoMenuViewModel> productosMenues = new List<ProductoMenuViewModel>();

            foreach (var item in original)
            {
                ProductoMenuViewModel productosMenuesView = new ProductoMenuViewModel
                {
                    CodigoProducto = item.CodigoProducto,
                    NombreProducto = item.NombreProducto,
                    DescripcionProducto = item.DescripcionProducto,
                    Costo = item.Costo
                };
                productosMenues.Add(productosMenuesView);
            }
            return productosMenues;
        }

        public Producto ConvertFromViewModel(ProductoMenuViewModel viewModel)
        {
            Producto productoMenu = new Producto
            {
                NombreProducto = viewModel.NombreProducto,
                DescripcionProducto = viewModel.DescripcionProducto,
                CodigoProducto = viewModel.CodigoProducto
            };
            return productoMenu;
        }

        public IEnumerable<Producto> ConvertListFromViewModel(IEnumerable<ProductoMenuViewModel> viewModel)
        {
            throw new NotImplementedException();
        }

        public ProductoMenuViewModel ConvertToViewModel(Producto original)
        {
            ProductoMenuViewModel productoMenu = new ProductoMenuViewModel
            {
                CodigoProducto = original.CodigoProducto,
                NombreProducto = original.NombreProducto,
                DescripcionProducto = original.DescripcionProducto,
                Costo = original.Costo
            };
            return productoMenu;
        }
    }
}
