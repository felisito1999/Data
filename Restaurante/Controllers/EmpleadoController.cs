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
            EmpleadoViewModel empleadoView = new EmpleadoViewModel();
            return View(empleadoView);
        }
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public ActionResult ActivarEmpleado(int idEmpleado)
        {
            try
            {
                GetService.
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}