﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Data.DbAccess;

namespace Data.Models.ViewModels
{
    public class ProductoViewModel
    {
        [Key]
        public int CodigoProducto { get; set; }
        [Required]
        [Display(Name = "Nombre del producto:")]
        public string NombreProducto { get; set; }
        [Required]
        [Display(Name= "Descripcion del producto")]
        public string DescripcionProducto { get; set; }
        public byte[] Imagen { get; set; }
        [Required, FileExtensions(Extensions = "jpeg, png, jpg",
                ErrorMessage = "Especificar una imagen")]
        public HttpPostedFileBase ArchivoImagen { get; set; }
        public int CodigoCategoria { get; set; }
        public ImagenProducto ImagenProducto { get; set; }
        public CategoriaProducto Categoria { get; set; }
    }
}
