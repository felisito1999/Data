using Data.Models.ViewModels;
using Data.Services;
using System;
using System.Collections.Generic;
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

                return View(productosMenuesView);
            }
            return RedirectToAction("SucursalIndex", "Sucursal");
        }
        public ActionResult AgregarProductoMenu(int? id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult AgregarProductoMenu(ProductoMenuViewModel viewModel)
        {
            var productoMenu = GetService.GetProductoMenuModelConverterService().ConvertFromViewModel(viewModel);

            using (var context = GetService.GetRestauranteEntityService().Database.BeginTransaction())
            {
                //GetService.GetProductoMenuService()
            }
            return View();
        }
    }
}