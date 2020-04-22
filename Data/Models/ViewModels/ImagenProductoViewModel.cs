using Data.DbAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Data.Models.ViewModels
{
    public class ImagenProductoViewModel
    {
        [Key]
        public int CodigoImagenProducto { get; set; }
        [Required]
        [Display(Name = "Producto:")]
        public int CodigoProducto { get; set; }
        [Required]
        [Display(Name = "Imagen:")]
        public byte[] Imagen { get; set; }
        [Required]
        [Display(Name = "Imagen:")]
        public HttpPostedFileBase Archivo { get; set; }
        public bool Borrado { get; set; }
        public Producto Producto { get; set; }

    }
}
