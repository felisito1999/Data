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
        public ActionResult DetallarOrdenCliente(int idOrden)
        {
            try
            {
                var ordenDetalle = GetService.GetOrdenDetalleService().ListSortedByGivenCategoryId(idOrden);

                return View(ordenDetalle);
            }
            catch (Exception)
            {
                return RedirectToAction("OrdenListaClientes", "Orden");
            }
        }
        public ActionResult DetallarOrdenEmpleado(int idOrden)
        {
            return View();
        }
    }
}