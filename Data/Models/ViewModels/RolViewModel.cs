using Data.DbAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.ViewModels
{
    public class RolViewModel
    {
        [Key]
        public int CodigoRol { get; set; }
        [Required]
        [Display(Name = "Nombre de rol:")]
        public string NombreRol { get; set; }
        [Required]
        [Display(Name = "Estado:")]
        public Estado Estado { get; set; }
        public bool Borrado { get; set; } = false;
    }
}
