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
    public class ImagenViewModelConverterService : IModelViewModelConverter<ImagenProducto, ImagenProductoViewModel>
    {
        public IEnumerable<ImagenProductoViewModel> ConvertfromListToViewModel(IEnumerable<ImagenProducto> original)
        {
            List<ImagenProductoViewModel> imagenesProductosViews = new List<ImagenProductoViewModel>();

            foreach (var item in original)
            {
                ImagenProductoViewModel imagenProductoView = new ImagenProductoViewModel
                {
                    CodigoImagenProducto = item.CodigoImagenProducto,
                    CodigoProducto = item.CodigoProducto,
                    Imagen = item.Imagen,
                    Producto = GetService.GetProductoService().FindById(item.CodigoProducto),
                    Borrado = item.Borrado
                };
                imagenesProductosViews.Add(imagenProductoView);
            }
            return imagenesProductosViews;
        }

        public ImagenProducto ConvertFromViewModel(ImagenProductoViewModel viewModel)
        {
            ImagenProducto imagenProducto = new ImagenProducto();

            using (var memory = new MemoryStream())
            {
                viewModel.Archivo.InputStream.CopyTo(memory);
                imagenProducto.Imagen = memory.ToArray();
            }
            imagenProducto.CodigoProducto = viewModel.CodigoProducto;
            imagenProducto.Borrado = false;
            return imagenProducto;
        }

        public IEnumerable<ImagenProducto> ConvertListFromViewModel(IEnumerable<ImagenProductoViewModel> viewModel)
        {
            throw new NotImplementedException();
        }

        public ImagenProductoViewModel ConvertToViewModel(ImagenProducto original)
        {
            throw new NotImplementedException();
        }
    }
}
