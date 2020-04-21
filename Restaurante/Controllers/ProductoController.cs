using Data.Models.ViewModels;
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
        [Authorize(Roles = "Administrador")]
        public ActionResult ListaProductos()
        {
            var productos = GetService.GetProductoService().ListAll();
            var productosView = GetService.GetProductoModelConverterService().ConvertfromListToViewModel(productos);
            return View(productosView);
        }
        [Authorize(Roles = "Administrador")]
        public ActionResult AgregarProducto()
        {
            ProductoViewModel producto = new ProductoViewModel();
            return View(producto);
        }
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public ActionResult AgregarProducto(ProductoViewModel productoViewModel)
        {
            return View();
        }
        [Authorize(Roles = "Administrador")]
        public ActionResult ActualizarProducto(int id)
        {
            return View();
        }
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public ActionResult ActualizarProducto(ProductoViewModel producto)
        {
            return View();
        }
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public ActionResult BorrarProducto(int id)
        {
            return View();
        }
    }
}