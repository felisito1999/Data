using Data.DbAccess;
using Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class EmpleadoModelConverterService : IModelViewModelConverter<Empleado, EmpleadoViewModel>
    {
        public IEnumerable<EmpleadoViewModel> ConvertfromListToViewModel(IEnumerable<Empleado> original)
        {
            throw new NotImplementedException();
        }

        public Empleado ConvertFromViewModel(EmpleadoViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Empleado> ConvertListFromViewModel(IEnumerable<EmpleadoViewModel> viewModel)
        {
            throw new NotImplementedException();
        }

        public EmpleadoViewModel ConvertToViewModel(Empleado original)
        {
            throw new NotImplementedException();
        }
    }
}
