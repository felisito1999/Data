using Data.Models.ViewModels;
using Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurante.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Administrador")]
        public ActionResult EmpleadosEsperandoActivacion()
        {
            var empleadosInactivos = GetService.GetEmpleadoService().GetEmpleadosInactivos();
            var empleadosInactivosView = GetService.GetEmpleadoConverterService().ConvertfromListToViewModel(empleadosInactivos);
            return View(empleadosInactivosView);
        }
        [Authorize(Roles = "Administrador")]
        public ActionResult ActivarEmpleado(int idEmpleado)
        {
            try
            {
                GetService.GetEmpleadoService().GrantPermissionToEmpleado(idEmpleado);

                return RedirectToAction("EmpleadosEsperandoActivacion");
            }
            catch (Exception)
            {
                return RedirectToAction("EmpleadosEsperandoActicacion");
            }
        }
    }
}