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
            List<EmpleadoViewModel> empleadosView = new List<EmpleadoViewModel>();

            foreach(var item in original)
            {
                EmpleadoViewModel view = new EmpleadoViewModel
                {
                    CodigoEmpleado = item.CodigoEmpleado,
                    NombreEmpleado = item.NombreEmpleado,
                    ApellidoEmpleado = item.ApellidoEmpleado,
                    CodigoUsuario = item.CodigoUsuario,
                    Usuario = GetService.GetUsuarioService().FindById(item.CodigoUsuario)
                };
                empleadosView.Add(view);
            }
            return empleadosView;
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
