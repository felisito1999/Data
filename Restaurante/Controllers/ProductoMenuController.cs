using Data.Models.ViewModels;
using Data.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurante.Controllers
{
    public class ProductoMenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProductoMenuList(int id)
        {
            if (ModelState.IsValid)
            {
                var menu = GetService.GetMenuService().GetMenuBySucursalId(id);
                var productosMenues = GetService.GetProductoMenuService().ListSortedByGivenCategoryId(menu.CodigoMenu);
                var productosMenuesView = GetService.GetProductoMenuListModelConverter().ConvertfromListToViewModel(productosMenues);
                ViewBag.CodigoSucursal = id;
                return View(productosMenuesView);
            }
            return RedirectToAction("SucursalIndex", "Sucursal");
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

                return RedirectToAction("ProductoMenuList", new { id = menu.CodigoSucursal });
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

                return RedirectToAction("ProductoMenuList", new { id = idSucursal });
            }
            catch (Exception)
            {
                return RedirectToAction("ProductoMenuList", new { id = idSucursal }); 
            }
        }
        [Authorize(Roles = "Administrador")]
        public ActionResult ModificarProductoMenu(int id)
        {
            var productoMenu = GetService.GetProductoMenuService().FindById(id);
            var productoMenuView = GetService.GetProductoMenuModelConverterService().ConvertToViewModel(productoMenu);

            return View(productoMenuView);
        }
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public ActionResult ModificarProductoMenu(ProductoMenuViewModel productoView)
        {
            var sucursal = GetService.GetSucursalService().GetSucursalByMenuId(productoView.CodigoMenu);
            try
            {
                var productoMenu = GetService.GetRestauranteEntityService().ProductosMenues.Find(productoView.CodigoProductoMenu);
                productoMenu = GetService.GetProductoMenuModelConverterService().ConvertFromViewModel(productoView);
                GetService.GetProductoMenuService().UpdateSingleObject(productoMenu);

                return RedirectToAction("ProductoMenuList", new { id = sucursal.CodigoSucursal });
            }
            catch (Exception)
            {
                return RedirectToAction("ModificarProductoMenu", new { id = sucursal.CodigoSucursal });
            }
        }

    }
}