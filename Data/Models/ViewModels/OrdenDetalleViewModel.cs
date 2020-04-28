using Data.DbAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.ViewModels
{
    public class OrdenDetalleViewModel
    {
        public int CodigoOrdenDetalle { get; set; }
        [Display(Name = "Nombre de producto:")]
        public string NombreProducto { get; set; }
        [Display(Name = "Cantidad:")]
        public int Cantidad { get; set; }
        [Display(Name = "Nombre de sucursal:")]
        public string NombreSucursal { get; set; }
        [Display(Name ="Precio:")]
        public decimal Precio { get; set; }
        [Display(Name = "Subtotal(RD$):")]
        public decimal SubTotal {
            get
            {
                if ((Cantidad * Precio) > 0)
                {
                    return Cantidad * Precio;
                }
                else
                {
                    return 0;
                }
            }
                }
        public OrdenDetalle OrdenDetalle { get; set; }
        [Display(Name = "Producto")]
        public Producto Producto { get; set; }
        public byte[] ImagenPrincipal { get; set; }
    }
}
