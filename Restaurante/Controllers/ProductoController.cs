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
        //[Authorize(Roles = "Administrador, Cliente")]
        public ActionResult ListaProductos()
        {
            try
            {
                var productos = GetService.GetProductoService().ListAll();
                var productosView = GetService.GetProductoModelConverterService().ConvertfromListToViewModel(productos);
                return View(productosView);
            }
            catch (Exception)
            {
                return RedirectToAction("SucursalIndex", "Sucursal");
            }
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
            var menu = GetService.GetMenuService().GetMenuBySucursalId(id);
            var productoMenuNotInSucursalMenu = GetService.GetProductoService().GetProductosNotInSucursalMenu(menu.CodigoMenu);
            var productosView = GetService.GetProductoProductoMenuModelConverterService().ConvertfromListToViewModel(productoMenuNotInSucursalMenu);
            ViewBag.CodigoSucursal = GetService.GetSucursalService().FindById(id).CodigoSucursal;
            return View(productosView);
        }
        [Authorize(Roles = "Administrador")]
        public ActionResult AgregarProductoSeleccionadoSucursal(int idProducto, int idSucursal)
        {
            var menu = GetService.GetMenuService().GetMenuBySucursalId(idSucursal);
            var producto = GetService.GetProductoService().FindById(idProducto);
            var productoView = GetService.GetProductoProductoMenuModelConverterService().ConvertToViewModel(producto);

            productoView.CodigoMenu = menu.CodigoMenu;
            productoView.CodigoProducto = producto.CodigoProducto;

            return View(productoView);
        }
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public ActionResult AgregarProductoSeleccionadoSucursal(ProductoMenuViewModel productoMenuView)
        {
            try
            {
                var productoMenu = GetService.GetProductoMenuModelConverterService().ConvertFromViewModel(productoMenuView);
                var menu = GetService.GetMenuService().FindById(productoMenu.CodigoMenu);
                GetService.GetProductoMenuService().Insert(productoMenu);

                return RedirectToAction("ProductoMenuList", "ProductoMenu", new { id = menu.CodigoSucursal });
            }
            catch (Exception)
            {
                return View();
            }
        }
        [Authorize(Roles = "Administrador")]
        public ActionResult BorrarProductoSeleccionadoSucursal(int id, int idSucursal)
        {
            try
            {
                GetService.GetProductoMenuService().SoftDelete(id);

                return RedirectToAction("ProductoMenuList", "ProductoMenu", new { id = idSucursal });
            }
            catch (Exception)
            {
                return RedirectToAction("ProductoMenuList", "ProductoMenu", new { id = idSucursal }); ;
            }
        }
        [Authorize(Roles = "Administrador")]
        public ActionResult ActualizarProducto(int id)
        {
            var producto = GetService.GetProductoService().FindById(id);
            var productoView = GetService.GetProductoModelConverterService().ConvertToViewModel(producto);
            return View(productoView);
        }
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public ActionResult ActualizarProducto(ProductoViewModel productoView)
        {
            try
            {
                var producto = GetService.GetProductoModelConverterService().ConvertFromViewModel(productoView);
                GetService.GetProductoService().UpdateSingleObject(producto);

                return RedirectToAction("ListaProductos");
            }
            catch (Exception)
            {
                return View();
            }
        }
        [Authorize(Roles = "Administrador")]
        public ActionResult BorrarProducto(int id)
        {
            try
            {
                using (var transaction = GetService.GetRestauranteEntityService().Database.BeginTransaction())
                {
                    GetService.GetProductoService().SoftDelete(id);
                }
                return RedirectToAction("ListaProductos");
            }
            catch (Exception)
            {
                return RedirectToAction("ListaProductos");
            }
        }
    }
}