using Data.DbAccess;
using Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class RegistroEmpleadoModelConverterService : IModelViewModelConverter<Empleado, RegistrarUsuarioEmpleadoViewModel>
    {
        public IEnumerable<RegistrarUsuarioEmpleadoViewModel> ConvertfromListToViewModel(IEnumerable<Empleado> original)
        {
            throw new NotImplementedException();
        }

        public Empleado ConvertFromViewModel(RegistrarUsuarioEmpleadoViewModel viewModel)
        {
            Empleado empleado = new Empleado
            {
                NombreEmpleado = viewModel.NombreEmpleado,
                ApellidoEmpleado = viewModel.ApellidoEmpleado,
                CodigoEstado = 4,
                CodigoPaisNacimiento = viewModel.CodigoPais,
                CodigoSucursal = viewModel.CodigoSucursal,
                FechaNacimiento = viewModel.FechaNacimiento,
                Sexo = viewModel.Sexo,
                Borrado = false,
                Telefono = viewModel.Telefono
            };
            return empleado;
        }

        public IEnumerable<Empleado> ConvertListFromViewModel(IEnumerable<RegistrarUsuarioEmpleadoViewModel> viewModel)
        {
            throw new NotImplementedException();
        }

        public RegistrarUsuarioEmpleadoViewModel ConvertToViewModel(Empleado original)
        {
            throw new NotImplementedException();
        }
    }
}
