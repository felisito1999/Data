using Data.DbAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.ViewModels
{
    public class ProvinciaViewModel
    {
        [Key]
        public int CodigoProvincia { get; set; }
        [Required]
        [Display(Name = "Nombre provincia")]
        public string NombreProvincia { get; set; }
        public Pais Pais { get; set; }
    }
}
