using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.ViewModels
{
    public class PaisViewModel
    {
        [Key]
        public int CodigoPais { get; set; }
        [Required]
        [Display(Name = "ISO país")]
        public string ISOPais { get; set; }
        [Required]
        [Display(Name = "Nombre país")]
        public string NombrePais { get; set; }
    }
}
