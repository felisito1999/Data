using Data.Models.ViewModels;
using Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurante.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        [Authorize(Roles = "Administrador")]
        public ActionResult ListaProductos()
        {
            var productos = GetService.GetProductoService().ListAll();
            var productosView = GetService.GetProductoModelConverterService().ConvertfromListToViewModel(productos);
            return View(productosView);
        }
        [Authorize(Roles = "Administrador")]
        public ActionResult AgregarProducto()
        {
            ProductoViewModel producto = new ProductoViewModel();
            return View(producto);
        }
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public ActionResult AgregarProducto(ProductoViewModel productoViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var producto = GetService.GetProductoModelConverterService().ConvertFromViewModel(productoViewModel);
                    var imagen = GetService.GetImagenProductoViewModelService().ConvertFromViewModel(productoViewModel);

                    using (var context = GetService.GetRestauranteEntityService().Database.BeginTransaction())
                    {
                        try
                        {
                            GetService.GetProductoService().Insert(producto);
                            var lastProducto = GetService.GetProductoService().GetLastProducto();
                            imagen.CodigoProducto = lastProducto.CodigoProducto;
                            GetService.GetImagenService().Insert(imagen);

                            context.Commit();

                            return RedirectToAction("ListaProductos");
                        }
                        catch (Exception)
                        {
                            context.Rollback();
                            return View();
                        }
                    }
                }
                catch (Exception)
                {
                    return View();
                } 
            }
            else
            {
                return View();
            }
        }
        [Authorize(Roles = "Administrador")]
        public ActionResult AgregarProductoSucursal(int id)
        {
            var productos = GetService.GetProductoService().ListAll();
            var productosView = GetService.GetProductoProductoMenuModelConverterService().ConvertfromListToViewModel(productos);
            ViewBag.CodigoSucursal = GetService.GetSucursalService().FindById(id).CodigoSucursal;
            return View(productosView);
        }
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public ActionResult AgregarProductoSeleccionadoSucursal(int idProducto, int idSucursal)
        {
            var menu = GetService.GetMenuService().GetMenuBySucursalId(idSucursal);
            var producto = GetService.GetProductoService().FindById(idProducto);
            var productoView = GetService.GetProductoProductoMenuModelConverterService().ConvertToViewModel(producto);
            productoView.CodigoMenu = menu.CodigoMenu;

            return View(productoView);
        }
        public ActionResult AgregarProductoSeleccionadoSucursal(ProductoMenuViewModel productoMenuView)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var productoMenu = GetService.GetProductoMenuModelConverterService().ConvertFromViewModel(productoMenuView);
                    GetService.GetProductoMenuService().Insert(productoMenu);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {

            }
            return View();
        }
        [Authorize(Roles = "Administrador")]
        public ActionResult ActualizarProducto(int id)
        {
            return View();
        }
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public ActionResult ActualizarProducto(ProductoViewModel producto)
        {
            return View();
        }
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public ActionResult BorrarProducto(int id)
        {
            return View();
        }
    }
}