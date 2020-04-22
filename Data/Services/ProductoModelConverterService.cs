using Data.DbAccess;
using Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class ProductoModelConverterService : IModelViewModelConverter<Producto, ProductoViewModel>
    {
        public IEnumerable<ProductoViewModel> ConvertfromListToViewModel(IEnumerable<Producto> original)
        {
            List<ProductoViewModel> viewModel = new List<ProductoViewModel>();

            foreach (var item in original)
            {
                ProductoViewModel productoViewModel = new ProductoViewModel
                {
                    CodigoProducto = item.CodigoProducto,
                    NombreProducto = item.NombreProducto,
                    DescripcionProducto = item.DescripcionProducto,
                    Imagen = GetService.GetImagenService().ListSortedByGivenCategoryId(item.CodigoProducto).FirstOrDefault().Imagen,
                    CodigoCategoria = item.CodigoCategoria
                };
                viewModel.Add(productoViewModel);
            }
            return viewModel;
        }

        public Producto ConvertFromViewModel(ProductoViewModel viewModel)
        {
            Producto producto = new Producto
            {
                NombreProducto = viewModel.NombreProducto,
                DescripcionProducto = viewModel.DescripcionProducto,
                CodigoCategoria = viewModel.CodigoCategoria,
                Costo = viewModel.Costo,
                CodigoEstado = 5,
                Borrado = false
            };
            return producto;
        }
        public IEnumerable<Producto> ConvertListFromViewModel(IEnumerable<ProductoViewModel> viewModel)
        {
            throw new NotImplementedException();
        }
        public ProductoViewModel ConvertToViewModel(Producto original)
        {
            ProductoViewModel productoView = new ProductoViewModel
            {
                CodigoProducto = original.CodigoProducto,
                NombreProducto = original.NombreProducto,
                DescripcionProducto = original.DescripcionProducto,
                Costo = original.Costo,
                CodigoCategoria = original.CodigoCategoria
            };
            return productoView;
        }
    }
}
