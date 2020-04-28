using Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurante.Controllers
{
    public class OrdenDetalleController : Controller
    {
        // GET: OrdenDetalle
        [Authorize(Roles = "Cliente,Empleado")]
        public ActionResult DetallarOrden(int idOrden)
        {
            try
            {
                var ordenDetalle = GetService.GetOrdenDetalleService().ListSortedByGivenCategoryId(idOrden);
                var ordenDetalleView = GetService.GetOrdenDetalleModelConverterService().ConvertfromListToViewModel(ordenDetalle);

                return View(ordenDetalleView);
            }
            catch (Exception)
            {
                return RedirectToAction("OrdenListaClientes", "Orden");
            }
        }
    }
}