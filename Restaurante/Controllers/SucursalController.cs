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
    public class SucursalController : Controller
    {
        // GET: Sucursal
        public ActionResult SucursalIndex()
        {
            var sucursales = GetService.GetSucursalService().ListAll();
            var sucursalesViewModel = GetService.GetSucursalModelConverterService().ConvertfromListToViewModel(sucursales);
            return View(sucursalesViewModel);
        }
        [Authorize(Roles = "Administrador")]
        public ActionResult AgregarSucursal()
        {
            return View();
        }
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public ActionResult AgregarSucursal(SucursalViewModel sucursalView)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var context = GetService.GetRestauranteEntityService().Database.BeginTransaction())
                    {
                        var sucursal = GetService.GetSucursalModelConverterService().ConvertFromViewModel(sucursalView);
                        GetService.GetSucursalService().Insert(sucursal);
                        Menu menu = new Menu
                        {
                            CodigoSucursal = GetService.GetSucursalService().GetLastSucursal().CodigoSucursal,
                            Borrado = false
                        };
                        GetService.GetMenuService().Insert(menu);
                        return RedirectToAction("SucursalIndex", "Sucursal");
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
        public ActionResult DeleteSusursal(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    GetService.GetSucursalService().SoftDelete(id);
                    return RedirectToAction("SucursalIndex");
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
    }
}