using Data.DbAccess;
using Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class OrdenDetalleModelConverterService : IModelViewModelConverter<OrdenDetalle, OrdenDetalleViewModel>
    {
        public IEnumerable<OrdenDetalleViewModel> ConvertfromListToViewModel(IEnumerable<OrdenDetalle> original)
        {
            List<OrdenDetalleViewModel> ordenDetalleCliente = new List<OrdenDetalleViewModel>();
            foreach (var item in original)
            {
                var producto = GetService.GetProductoService().FindById(item.CodigoProducto);
                var imagenPrincipal = GetService.GetImagenService().ListSortedByGivenCategoryId(producto.CodigoProducto).FirstOrDefault();

                OrdenDetalleViewModel ordenDetalleView = new OrdenDetalleViewModel
                {
                    Producto = producto,
                    CodigoOrdenDetalle = item.CodigoOrdenDetalle,
                    Precio = item.PrecioVenta,
                    Cantidad = item.Cantidad,
                    NombreProducto = producto.NombreProducto,
                    ImagenPrincipal = imagenPrincipal.Imagen
                };
                ordenDetalleCliente.Add(ordenDetalleView);
            }
            return ordenDetalleCliente;
        }

        public OrdenDetalle ConvertFromViewModel(OrdenDetalleViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrdenDetalle> ConvertListFromViewModel(IEnumerable<OrdenDetalleViewModel> viewModel)
        {
            throw new NotImplementedException();
        }

        public OrdenDetalleViewModel ConvertToViewModel(OrdenDetalle original)
        {
            throw new NotImplementedException();
        }
    }
}
