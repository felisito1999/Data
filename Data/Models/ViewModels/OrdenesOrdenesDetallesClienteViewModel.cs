using Data.DbAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.ViewModels
{
    public class OrdenesOrdenesDetallesClienteViewModel
    {
        public int CodigoOrden { get; set; }
        public int CodigoOrdenDetalle { get; set; }
        [Display(Name = "Nombre de producto:")]
        public string NombreProducto { get; set; }
        [Display(Name = "Nombre de sucursal:")]
        public string NombreSucursal { get; set; }
        [Display(Name ="Precio:")]
        public decimal Precio { get; set; }
        [Display(Name = "Fecha y hora:")]
        public DateTime FechaHora { get; set; }
        public Orden Orden { get; set; }
        public OrdenDetalle OrdenDetalle { get; set; }
        public Sucursal Sucursal { get; set; }
        public Producto Producto { get; set; }
    }
}
