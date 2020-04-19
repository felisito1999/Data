using Data.DbAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Data.Models.ViewModels
{
    public class ProductoMenuViewModel
    {
        [Key]
        public int CodigoProductoMenu { get; set; }
        public int CodigoProducto { get; set; }
        [Required]
        [Display(Name = "Nombre de producto:")]
        [MaxLength(30)]
        public string NombreProducto { get; set; }
        [Required]
        [Display(Name = "Descripción de producto:")]
        [MaxLength(200)]
        public string DescripcionProducto { get; set; }
        [Required]
        [Display(Name = "Imagen principal:")]
        public byte[] Imagen { get; set; }

        public Producto Producto { get; set; }
        [Required, FileExtensions(Extensions = "jpeg, png, jpg",
                ErrorMessage = "Especificar una imagen")]
        public HttpPostedFileBase Archivo { get; set; }
        [Required]
        [Display(Name = "Precios (RD$):")]
        public decimal Precio { get; set; }
        public ImagenProducto Imagenes { get; set; }
        [Display(Name = "Sucursal:")]
        [Required]
        public int CodigoSucursal { get; set; }
        public Menu Menu { get; set; }
    }
}
