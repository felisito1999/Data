using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.ViewModels
{
    public class EstadoViewModel
    {
        [Key]
        public int CodigoEstado { get; set; }
        [Required]
        [Display(Name = "Nombre de estado")]
        public string NombreEstado { get; set; }
    }
}
