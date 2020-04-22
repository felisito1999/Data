using Data.DbAccess;
using Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurante.Controllers
{
    public class OrdenController : Controller
    {
        // GET: Orden
        [Authorize]
        public ActionResult OrdenarProducto(int idProducto, int idSucursal)
        {
            try
            {
                var producto = GetService.GetProductoService().FindById(idProducto);
                var menu = GetService.GetMenuService().GetMenuBySucursalId(idSucursal);
                var productoMenu = GetService.GetProductoMenuService().GetProductoMenuByMenuIdProductoId(menu.CodigoMenu, producto.CodigoProducto);
                var empleado = GetService.GetOrdenService().SeleccionarEmpleadoMenorCantidadOrdenPendiente(idSucursal);
                var cliente = GetService.GetClienteService().GetClienteFromUserName(User.Identity.Name);
                Orden orden = new Orden
                {
                    CodigoEstado = 1024,
                    Borrado = false,
                    CodigoCliente = cliente.CodigoCliente,
                    CodigoEmpleado = empleado.CodigoEmpleado,
                    CodigoSucursal = idSucursal,
                    FechaHora = DateTime.Now
                };
                GetService.GetOrdenService().Insert(orden);
                OrdenDetalle ordenDetalle = new OrdenDetalle
                {
                    CodigoEstado = 1026,
                    Borrado = false,
                    Costo = producto.Costo,
                    CodigoOrden = GetService.GetOrdenService().FindLastOrden().CodigoOrden,
                    Cantidad = 1,
                    CodigoProducto = idProducto,
                    PrecioVenta = productoMenu.Precio
                };
                GetService.GetOrdenDetalleService().Insert(ordenDetalle);
                return RedirectToAction("SucursalIndex", "Sucursal");
            }
            catch (Exception)
            {
                return View();
                throw;
            }
        }
    }
}