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
                var empleadoAsignado = GetService.GetOrdenService().SeleccionarEmpleadoMenorCantidadOrdenPendiente(idSucursal);
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
        [Authorize(Roles = "Cliente")]
        public ActionResult OrdenListaClientes()
        {
            var clienteUser = GetService.GetClienteService().GetClienteFromUserName(User.Identity.Name);
            var ordenes = GetService.GetOrdenService().ListAll().Where(x => x.CodigoCliente == clienteUser.CodigoCliente & x.Borrado == false);

            List<OrdenViewModelCliente> ordenesView = new List<OrdenViewModelCliente>();
            foreach (var item in ordenes)
            {
                var sucursal = GetService.GetSucursalService().FindById(item.CodigoSucursal);
                var cliente = GetService.GetClienteService().FindById(item.CodigoCliente);
                var estado = GetService.GetEstadoService().FindById(item.CodigoEstado);
                OrdenViewModelCliente ordenViewModel = new OrdenViewModelCliente
                {
                    CodigoOrden = item.CodigoOrden,
                    CodigoSucursal = item.CodigoSucursal,
                    CodigoCliente = item.CodigoCliente,
                    CodigoEstado = item.CodigoEstado,
                    Sucursal = sucursal,
                    Cliente = cliente,
                    Estado = estado
                };
                ordenesView.Add(ordenViewModel);
            }
            return View(ordenesView);
        }
        [Authorize(Roles = "Empleado")]
        public ActionResult OrdenListaEmpleados()
        {
            var empleado = GetService.GetEmpleadoService().GetEmpleadoByUserName(User.Identity.Name);
            var ordenes = GetService.GetOrdenService().ListAll().Where(x => x.CodigoEmpleado == empleado.CodigoEmpleado & x.Borrado == false);
            
            List<>
            return View();
        }
        public ActionResult ActualizarEstadoOrden()
        {
            return View();
        }
    }
}