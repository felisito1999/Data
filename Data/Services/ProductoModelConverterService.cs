using Data.DbAccess;
using Data.Models.ViewModels;
using System;
using System.Collections.Generic;
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
                    Imagen = GetService.GetImagenProductoService().ListSortedByGivenCategoryId(item.CodigoProducto).FirstOrDefault().Imagen,
                    CodigoCategoria = item.CodigoCategoria
                };
                viewModel.Add(productoViewModel);
            }
            return viewModel;
        }

        public Producto ConvertFromViewModel(ProductoViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Producto> ConvertListFromViewModel(IEnumerable<ProductoViewModel> viewModel)
        {
            throw new NotImplementedException();
        }

        public ProductoViewModel ConvertToViewModel(Producto original)
        {
            throw new NotImplementedException();
        }
    }
}
