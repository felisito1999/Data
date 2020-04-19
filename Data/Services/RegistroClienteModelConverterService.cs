using Data.DbAccess;
using Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class RegistroClienteModelConverterService : IModelViewModelConverter<Cliente, RegistrarUsuarioClienteViewModel>
    {
        public IEnumerable<RegistrarUsuarioClienteViewModel> ConvertfromListToViewModel(IEnumerable<Cliente> original)
        {
            throw new NotImplementedException();
        }

        public Cliente ConvertFromViewModel(RegistrarUsuarioClienteViewModel viewModel)
        {
            Cliente cliente = new Cliente
            {
                NombreCliente = viewModel.NombreCliente,
                ApellidoCliente = viewModel.ApellidoCliente,
                FechaNacimiento = viewModel.FechaNacimiento,
                Sexo = viewModel.Sexo,
                Telefono = viewModel.Telefono,
                CodigoPaisNacimiento = viewModel.CodigoPais,
                CodigoEstado = 1,
                Borrado = false
            };
            return cliente;
        }

        public IEnumerable<Cliente> ConvertListFromViewModel(IEnumerable<RegistrarUsuarioClienteViewModel> viewModel)
        {
            throw new NotImplementedException();
        }

        public RegistrarUsuarioClienteViewModel ConvertToViewModel(Cliente original)
        {
            throw new NotImplementedException();
        }
    }
}
