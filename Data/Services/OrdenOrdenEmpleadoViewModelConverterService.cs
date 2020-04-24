using Data.DbAccess;
using Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class OrdenOrdenEmpleadoViewModelConverterService : IModelViewModelConverter<Orden, OrdenEmpleadoViewModel>
    {
        public IEnumerable<OrdenEmpleadoViewModel> ConvertfromListToViewModel(IEnumerable<Orden> ordenes)
        {
            List<OrdenEmpleadoViewModel> ordenesView = new List<OrdenEmpleadoViewModel>();

            foreach (var item in ordenes)
            {
                var sucursal = GetService.GetSucursalService().FindById(item.CodigoSucursal);
                var cliente = GetService.GetClienteService().FindById(item.CodigoCliente);
                var empleadoOrden = GetService.GetEmpleadoService().FindById(item.CodigoEmpleado);
                var estado = GetService.GetEstadoService().FindById(item.CodigoEstado);
                var ordenDetalle = GetService.GetOrdenDetalleService().ListSortedByGivenCategoryId(item.CodigoOrden).FirstOrDefault();
                var producto = GetService.GetProductoService().FindById(ordenDetalle.CodigoProducto);

                OrdenEmpleadoViewModel ordenView = new OrdenEmpleadoViewModel
                {
                    CodigoOrden = item.CodigoOrden,
                    CodigoEmpleado = item.CodigoEmpleado,
                    CodigoSucursal = item.CodigoSucursal,
                    CodigoEstado = item.CodigoEstado,
                    Empleado = empleadoOrden,
                    Estado = estado,
                    Sucursal = sucursal,
                    Producto = producto,
                    Cliente = cliente,
                    Fecha = item.FechaHora,
                    OrdenDetalle = ordenDetalle
                };
                ordenesView.Add(ordenView);
            }
            var ordenesDesdeMasNueva = ordenesView.OrderByDescending(x => x.CodigoOrden);

            return ordenesDesdeMasNueva;
        }

        public Orden ConvertFromViewModel(OrdenEmpleadoViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Orden> ConvertListFromViewModel(IEnumerable<OrdenEmpleadoViewModel> viewModel)
        {
            throw new NotImplementedException();
        }

        public OrdenEmpleadoViewModel ConvertToViewModel(Orden original)
        {
            throw new NotImplementedException();
        }
    }
}
