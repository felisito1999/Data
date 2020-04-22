using Data.DbAccess;
using Data.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.ViewModels
{
    public class RegistrarUsuarioEmpleadoViewModel
    {
        [Key]
        public int CodigoEmpleado{ get; set; }
        [Required]
        [Display(Name = "Nombre:")]
        public string NombreEmpleado { get; set; }
        [Required]
        [Display(Name = "Apellido:")]
        public string ApellidoEmpleado { get; set; }
        [Required]
        [Display(Name = "Correo:")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(25)]
        public string Correo { get; set; }
        [Required]
        [Display(Name = "Nombre de usuario:")]
        [MaxLength(15)]
        public string NombreUsuario { get; set; }
        [Required]
        [Display(Name = "Contraseña:")]
        [DataType(DataType.Password)]
        public string Clave { get; set; }
        [Required]
        [Display(Name = "Fecha de nacimiento:")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        [Display(Name = "Sexo:")]
        public string Sexo { get; set; }
        [Required]
        [Display(Name = "Teléfono:")]
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }
        [Required]
        [Display(Name = "País de origen:")]
        public int CodigoPais { get; set; }
        [Required]
        [Display(Name = "Sucursal asignada:")]
        public int CodigoSucursal { get; set; }
        public Pais Pais
        {
            get
            {
                return GetService.GetPaisService().FindById(CodigoPais);
            }
        }
        public Rol Rol { get; set; }
    }
}

