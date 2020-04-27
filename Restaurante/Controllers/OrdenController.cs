using Data.DbAccess;
using Data.Models.ViewModels;
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
        [Authorize(Roles = "Cliente")]
        public ActionResult OrdenarProducto(int idProducto, int idSucursal)
        {
            //
            try
            {
                var producto = GetService.GetProductoService().FindById(idProducto);
                var menu = GetService.GetMenuService().GetMenuBySucursalId(idSucursal);
                var productoMenu = GetService.GetProductoMenuService().GetProductoMenuByMenuIdProductoId(menu.CodigoMenu, producto.CodigoProducto);
                var empleadoAsignado = GetService.GetEmpleadoService().SeleccionarEmpleadoMenorCantidadOrdenPendiente(idSucursal);
                var cliente = GetService.GetClienteService().GetClienteFromUserName(User.Identity.Name);
                Orden orden = new Orden
                {
                    CodigoEstado = 1024,
                    Borrado = false,
                    CodigoCliente = cliente.CodigoCliente,
                    CodigoEmpleado = empleadoAsignado.CodigoEmpleado,
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
                    PrecioVenta = productoMenu.Precio,
                    SubTotal = productoMenu.Precio
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
        [Authorize(Roles = "Cliente")]
        public ActionResult OrdenarCarrito()
        {
            try
            {
                var productoListView = (List<ProductoMenu>)Session["Carrito"];
                var productoList = GetService.GetProductoMenuListModelConverter().ConvertfromListToViewModel(productoListView);
                List<OrdenDetalle> ordenDetalles = new List<OrdenDetalle>();

                var cliente = GetService.GetClienteService().GetClienteFromUserName(User.Identity.Name);
                var menu = GetService.GetMenuService().GetMenuByProductoMenu(productoList.ToList()[0].CodigoProductoMenu);
                var sucursal = GetService.GetSucursalService().FindById(menu.CodigoSucursal);
                var empleadoAsignado = GetService.GetEmpleadoService().SeleccionarEmpleadoMenorCantidadOrdenPendiente(sucursal.CodigoSucursal);

                Orden orden = new Orden
                {
                    CodigoCliente = cliente.CodigoCliente,
                    CodigoEmpleado = empleadoAsignado.CodigoEmpleado,
                    CodigoSucursal = sucursal.CodigoSucursal,
                    CodigoEstado = 1024,
                    FechaHora = DateTime.Now,
                    Borrado = false
                };

                GetService.GetOrdenService().Insert(orden);
                var lastOrden = GetService.GetOrdenService().FindLastOrden();

                foreach (var item in productoList)
                {
                    var producto = GetService.GetProductoService().FindById(item.CodigoProducto);

                    if (ordenDetalles.Exists(x => x.CodigoProducto == item.CodigoProducto) == false)
                    {
                        OrdenDetalle ordenDetalle = new OrdenDetalle
                        {
                            CodigoOrden = lastOrden.CodigoOrden,
                            CodigoProducto = producto.CodigoProducto,
                            CodigoEstado = 1026,
                            Cantidad = item.Cantidad,
                            Costo = producto.Costo,
                            Borrado = false,
                            PrecioVenta = item.Precio,
                            SubTotal = item.Precio * item.Cantidad
                        };
                        ordenDetalles.Add(ordenDetalle);
                    }
                    else
                    {
                        continue;
                    }
                }

                if (ordenDetalles.Count() > 0)
                {
                    foreach (var item in ordenDetalles)
                    {
                        GetService.GetOrdenDetalleService().Insert(item);
                    }
                }
                return RedirectToAction("OrdenListaClientes");
            }
            catch (Exception)
            {
                return RedirectToAction("ListarCarrito", "Carrito");
            }
        }
        [Authorize(Roles = "Cliente")]
        public ActionResult OrdenListaClientes()
        {
            var clienteUser = GetService.GetClienteService().GetClienteFromUserName(User.Identity.Name);
            var ordenes = GetService.GetOrdenService().ListAll().Where(x => x.CodigoCliente == clienteUser.CodigoCliente & x.Borrado == false);
            var ordenesView = GetService.GetOrdenOrdenClienteModelConverterService().ConvertfromListToViewModel(ordenes);
           
            return View(ordenesView);
        }
        [Authorize(Roles = "Empleado")]
        public ActionResult OrdenListaEmpleados()
        {
            var empleado = GetService.GetEmpleadoService().GetEmpleadoByUserName(User.Identity.Name);
            var ordenes = GetService.GetOrdenService().ListAll().Where(x => x.CodigoEmpleado == empleado.CodigoEmpleado & x.Borrado == false);
            var ordenesView = GetService.GetOrdenOrdenEmpleadoModelConverterService().ConvertfromListToViewModel(ordenes);

            return View(ordenesView);
        }
        [Authorize(Roles="Empleado")]
        public ActionResult ActualizarEstadoOrden(int id)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var orden = context.Ordenes.Find(id);
                orden.CodigoEstado = 1025;

                context.SaveChanges();
            }
            return RedirectToAction("OrdenListaEmpleados");
        }
    }
}