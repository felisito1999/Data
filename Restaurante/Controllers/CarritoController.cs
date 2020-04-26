using Data.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurante.Controllers
{
    public class CarritoController : Controller
    {
        // GET: Carrito
        public ActionResult AgregarAlCarrito(ProductoMenu productoMenu)
        {
            return View();
        }
    }
}