using Data.DbAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Services;

namespace Data.Models.ViewModels
{
    public class SucursalViewModel
    {
        [Key]
        public int CodigoSucursal { get; set; }
        [Required]
        [Display(Name = "Nombre de la sucursal:")]
        public string NombreSucursal { get; set; }
        [Required]
        [Display(Name = "Direccion de la sucursal:")]
        public string DireccionSucursal { get; set; }
        [Display(Name = "Pais:")]
        public Pais Pais { get; set; } = GetService.GetPaisService().FindById(65);
        public Provincia Provincia
        {
            get
            {
                return GetService.GetProvinciaService().FindById(CodigoProvincia);
            }
        }
        [Display(Name = "Provincia:")]
        public int CodigoProvincia { get; set; }
    }
}
