using System;
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
        [Display(Name = "Descripcion del producto")]
        public string DescripcionProducto { get; set; }
        [Required]
        [Display(Name = "Costo:")]
        public decimal Costo { get; set; }
        public byte[] Imagen { get; set; }
        [Required]
        [DataType(DataType.Upload)]
        [Display(Name = "Seleccionar imagen:")]
        public HttpPostedFileBase ArchivoImagen { get; set; }
        [Required]
        [Display(Name = "Categoria:")]
        public int CodigoCategoria { get; set; }
        public ImagenProducto ImagenProducto { get; set; }
        public CategoriaProducto Categoria { get; set; }
    }
}
