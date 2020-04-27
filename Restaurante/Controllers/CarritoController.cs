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
    public class CarritoController : Controller
    {
        [Authorize(Roles = "Cliente")]
        public ActionResult AgregarAlCarrito(int idProducto, int idSucursal)
        {
            try
            {
                var menu = GetService.GetMenuService().GetMenuBySucursalId(idSucursal);
                var productoMenu = GetService.GetProductoMenuService().GetProductoMenuByMenuIdProductoId(menu.CodigoMenu, idProducto);

                if (Session["Carrito"] == null)
                {
                    List<ProductoMenu> carrito = new List<ProductoMenu>();
                    carrito.Add(productoMenu);
                    
                    Session["Carrito"] = carrito;
                }
                else
                {
                    List<ProductoMenu> carrito = new List<ProductoMenu>();

                    carrito = (List<ProductoMenu>)Session["Carrito"];


                    if (carrito.Exists(x => x.CodigoMenu == productoMenu.CodigoMenu))
                    {
                        carrito.Add(productoMenu);

                        Session["Carrito"] = carrito;

                        return RedirectToAction("ListarCarrito");
                    }
                }
                return RedirectToAction("ListarCarrito");
            }
            catch (Exception)
            {
                return RedirectToAction("ProductoMenuList","ProductoMenu", new { id= idSucursal});
                throw;
            }
        }
        [Authorize(Roles = "Cliente")]
        public ActionResult ListarCarrito()
        {
            List<ProductoMenu> listaCarrito = new List<ProductoMenu>();
                
            if (Session["Carrito"] != null)
            {
                listaCarrito = (List<ProductoMenu>)Session["Carrito"];

                var listaCarritoView = GetService.GetProductoMenuListModelConverter().ConvertfromListToViewModel(listaCarrito);
                return View(listaCarritoView);
            }
            return View();
        }
        public ActionResult EliminarProducto(int id)
        {
            try
            {
                List<ProductoMenu> listaCarrito = new List<ProductoMenu>();
                listaCarrito = (List<ProductoMenu>)Session["Carrito"];

                var producto = listaCarrito.Where(x => x.CodigoProductoMenu == id).FirstOrDefault();
                listaCarrito.Remove(producto);

                Session["Carrito"] = listaCarrito;
                return RedirectToAction("ListarCarrito");
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}