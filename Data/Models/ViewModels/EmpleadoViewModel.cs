using Data.DbAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.ViewModels
{
    public class EmpleadoViewModel
    {
        [Key]
        public int CodigoEmpleado { get; set; }
        [Required]
        [Display(Name = "Nombre de empleado:")]
        public string NombreEmpleado { get; set; }
        [Required]
        [Display(Name = "Apellido de empleado:")]
        public string ApellidoEmpleado { get; set; }
        [Display(Name = "Nombre de usuario:")]
        public int CodigoUsuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}
