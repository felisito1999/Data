using Data.Models.ViewModels;
using Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Restaurante.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            UsuarioLoginViewModel usuarioLogin = new UsuarioLoginViewModel();
            return View(usuarioLogin);
        }
        [HttpPost]
        public ActionResult Login(UsuarioLoginViewModel userInfo)
        {
            if (ModelState.IsValid)
            {
                var usuarioLogin = GetService.GetUsuarioLoginModelConverterService().ConvertFromViewModel(userInfo);
                var authentication = GetService.GetUsuarioService().CorrectLoginInfo(usuarioLogin.NombreUsuario, usuarioLogin.Clave);

                if (authentication == true)
                {
                    FormsAuthentication.SetAuthCookie(userInfo.NombreUsuario, false);
                    TempData["LoginData"] = userInfo.NombreUsuario;
                    
                    return RedirectToAction("SucursalIndex", "Sucursal");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            Session.Clear();
            FormsAuthentication.SignOut();
            TempData["LoginData"] = null;
            return RedirectToAction("SucursalIndex", "Sucursal");
        }
        public ActionResult SeleccionRegistro()
        {
            return View();
        }
        public ActionResult RegistrarCliente()
        {
            RegistrarUsuarioClienteViewModel registro = new RegistrarUsuarioClienteViewModel();
            return View(registro);
        }
        [HttpPost]
        public ActionResult RegistrarCliente(RegistrarUsuarioClienteViewModel registroCliente)
        {
            if (ModelState.IsValid)
            {
                using (var transaction = GetService.GetRestauranteEntityService().Database.BeginTransaction())
                {
                    try
                    {
                        var usuario = GetService.GetRegistroUsuarioClienteConverterService().ConvertFromViewModel(registroCliente);
                        var cliente = GetService.GetRegistroClienteConverterService().ConvertFromViewModel(registroCliente);

                        GetService.GetUsuarioService().Insert(usuario);
                        GetService.GetClienteService().Insert(cliente);
                        transaction.Commit();

                        return Redirect("~/");
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return View();
                    }
                }
            }
            else
            {
                return View();
            }
        }
    }
}
