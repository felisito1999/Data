using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public int CodigoCliente { get; set; }
        [Display(Name = "Nombre:")]
        public string NombreCliente { get; set; }
        [Display(Name = "Apellido:")]
        public string ApellidoCliente { get; set; }

    }
}
