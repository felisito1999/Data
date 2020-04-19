using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Data.Services
{
    public class SexoService
    {
        public List<SelectListItem> Sexos()
        {
            List<SelectListItem> sexos = new List<SelectListItem>
            {
                new SelectListItem() { Text = "Masculino", Value = "Masculino" },
                new SelectListItem() { Text = "Femenino", Value = "Femenino" }
            };
            return sexos;
        }
    }
}
