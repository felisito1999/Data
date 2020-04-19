using Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurante.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var sucursales = GetService.GetSucursalService().ListAll();
            var sucursalesViewModel = GetService.GetSucursalModelConverterService().ConvertfromListToViewModel(sucursales);
            return View(sucursalesViewModel);
        }
        public ActionResult MenuPorSucursal(int id)
        {
            if (ModelState.IsValid)
            {
                var menu = GetService.GetMenuService().GetMenuBySucursalId(id);
                var productosMenues = GetService.GetProductoMenuService().ListSortedByGivenCategoryId(menu.CodigoMenu);
                var productosMenuesView = GetService.GetProductoMenuListModelConverter().ConvertfromListToViewModel(productosMenues);

                return View(productosMenuesView);
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}