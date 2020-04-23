using Data.DbAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.ViewModels
{
    public class OrdenViewModelEmpleado
    {
        [Key]
        public int CodigoOrden { get; set; }
        [Display(Name = "Nombre completo:")]
        public int CodigoEmpleado { get; set; }
        [Display(Name = "Sucursal:")]
        public int CodigoSucursal { get; set; }
        [Display(Name = "Estado:")]
        public int CodigoEstado { get; set; }
        public Empleado Empleado { get; set; }
        [Display(Name = "Sucursal:")]
        public Sucursal Sucursal { get; set; }
        [Display(Name = "Estado:")]
        public Estado Estado { get; set; }
    }
}
