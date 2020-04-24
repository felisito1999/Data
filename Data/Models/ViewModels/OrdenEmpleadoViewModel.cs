using Data.DbAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.ViewModels
{
    public class OrdenEmpleadoViewModel
    {
        [Key]
        public int CodigoOrden { get; set; }
        public int CodigoEmpleado { get; set; }
        [Display(Name = "Sucursal:")]
        public int CodigoSucursal { get; set; }
        [Display(Name = "Estado:")]
        public int CodigoEstado { get; set; }
        [Display(Name = "Nombre completo:")]
        public Cliente Cliente { get; set; }
        [Display(Name = "Sucursal:")]
        public Sucursal Sucursal { get; set; }
        [Display(Name = "Fecha:")]
        public DateTime Fecha { get; set; }
        [Display(Name = "Estado:")]
        public Estado Estado { get; set; }
        public OrdenDetalle OrdenDetalle { get; set; }
        [Display(Name = "Nombre de producto")]
        public Producto Producto { get; set; }
        [Display(Name = "Nombre de empleado:")]
        public Empleado Empleado { get; set; }
    }
}
