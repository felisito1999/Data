using Data.DbAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.ViewModels
{
    public class ProductoMenuListViewModel
    {
        [Key]
        public int CodigoProductoMenu { get; set; }
        public int CodigoProducto { get; set; }
        [Display(Name = "Imagen principal:")]
        public byte[] ImagenPrincipal { get; set; }
        [Display(Name = "Nombre de producto:")]
        public Producto Producto { get; set; }
        [Display(Name = "Descripcion de producto:")]
        public string DescripcionProducto
        {
            get
            {
                if (Producto != null)
                {
                    return Producto.DescripcionProducto;
                }
                else
                {
                    return null;
                }
            }
        }
        [Display(Name = "Precio (RD$):")]
        public decimal Precio { get; set; }
        public ImagenProducto Imagenes { get; set; }
    }
}
