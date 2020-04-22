using Data.DbAccess;
using Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class RegistroUsuarioModelEmpleadosConverterSerivce : IModelViewModelConverter<Usuario, RegistrarUsuarioEmpleadoViewModel>
    {
        public IEnumerable<RegistrarUsuarioEmpleadoViewModel> ConvertfromListToViewModel(IEnumerable<Usuario> original)
        {
            throw new NotImplementedException();
        }

        public Usuario ConvertFromViewModel(RegistrarUsuarioEmpleadoViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> ConvertListFromViewModel(IEnumerable<RegistrarUsuarioEmpleadoViewModel> viewModel)
        {
            throw new NotImplementedException();
        }

        public RegistrarUsuarioEmpleadoViewModel ConvertToViewModel(Usuario original)
        {
            throw new NotImplementedException();
        }
    }
}
