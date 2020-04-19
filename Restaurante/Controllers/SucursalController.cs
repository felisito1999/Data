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
                        return View("SucursalIndex");
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
        public ActionResult UpdateSucursal(int id)
        {
            try
            {
                var sucursalOriginal = GetService.GetSucursalService().FindById(id);
                var sucursal = GetService.GetSucursalModelConverterService().ConvertToViewModel(sucursalOriginal);

                return View(sucursal);
            }
            catch (Exception)
            {
                return RedirectToAction("SucursalIndex", "Sucursal");
            }
        }
        [HttpPost]
        [Authorize(Roles ="Administrador")]
        public ActionResult UpdateSucursal(SucursalViewModel viewModel)
        {
            try
            {
                var sucursal = GetService.GetSucursalModelConverterService().ConvertFromViewModel(viewModel);
                GetService.GetSucursalService().UpdateSingleObject(sucursal);

                return RedirectToAction("SucursalIndex");
            }
            catch (Exception)
            {
                return View();
            }

        }
        [Authorize(Roles = "Administrador")]
        public ActionResult DeleteSucursal(int id)
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
                    return View("SucursalIndex");
                }
            }
            else
            {
                return View("SucursalIndex");
            }
        }
    }
}