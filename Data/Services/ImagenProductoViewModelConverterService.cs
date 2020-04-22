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
    public class ImagenProductoViewModelConverterService : IModelViewModelConverter<ImagenProducto, ProductoViewModel>
    {
        public IEnumerable<ProductoViewModel> ConvertfromListToViewModel(IEnumerable<ImagenProducto> original)
        {
            throw new NotImplementedException();
        }

        public ImagenProducto ConvertFromViewModel(ProductoViewModel viewModel)
        {
            ImagenProducto imagenProducto = new ImagenProducto();
            using (var memory = new MemoryStream())
            {
                viewModel.ArchivoImagen.InputStream.CopyTo(memory);
                imagenProducto.Imagen = memory.ToArray();

                return imagenProducto;
            }
        }

        public IEnumerable<ImagenProducto> ConvertListFromViewModel(IEnumerable<ProductoViewModel> viewModel)
        {
            throw new NotImplementedException();
        }

        public ProductoViewModel ConvertToViewModel(ImagenProducto original)
        {
            throw new NotImplementedException();
        }
    }
}
