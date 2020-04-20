using Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurante.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult ListaProductos()
        {
            var productos = GetService.GetProductoService().ListAll();
            var productosView = GetService.GetProductoModelConverterService().ConvertfromListToViewModel(productos);
            return View(productosView);
        }
    }
}