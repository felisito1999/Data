using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.ViewModels
{
    public class UsuarioLoginViewModel
    {
        [Required]
        [Display(Name = "Correo electrónico o nombre de usuario:")]
        [MaxLength(25)]
        public string NombreUsuario { get; set; }
        [Required]
        [Display(Name = "Contraseña:")]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        public string Clave { get; set; }
    }
}
