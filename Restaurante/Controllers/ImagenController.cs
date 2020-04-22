﻿using Data.Models.ViewModels;
using Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurante.Controllers
{
    public class ImagenController : Controller
    {
        // GET: Imagen
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VerGaleriaDeProducto(int idProducto)
        {
            var imagenesDeProducto = GetService.GetImagenService().ListSortedByGivenCategoryId(idProducto);
            var imagenesDeProductoViews = GetService.GetImagenViewModelConverterService().ConvertfromListToViewModel(imagenesDeProducto);

            return View(imagenesDeProductoViews);
        }
        [Authorize(Roles = "Administrador")]
        public ActionResult AgregarImagenAproducto(int idProducto)
        {
            ImagenProductoViewModel imagenProducto = new ImagenProductoViewModel
            {
                CodigoProducto = idProducto
            };

            return View(imagenProducto);
        }
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public ActionResult AgregarImagenAproducto(ImagenProductoViewModel imagenProductoView)
        {
            var imagenProducto = GetService.GetImagenViewModelConverterService().ConvertFromViewModel(imagenProductoView);
        }
    }
}