using Data.DbAccess;
using Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class RegistroUsuarioModelClienteConverterService : IModelViewModelConverter<Usuario, RegistrarUsuarioClienteViewModel>
    {
        public Usuario ConvertFromViewModel(RegistrarUsuarioClienteViewModel viewModel)
        {
            Usuario usuario = new Usuario
            {
                NombreUsuario = viewModel.NombreUsuario,
                Clave = viewModel.Clave,
                Correo = viewModel.Correo,
                CodigoRol = 2,
                CodigoEstado = 10,
                Borrado = false
            };
            return usuario;
        }

        public IEnumerable<Usuario> ConvertListFromViewModel(IEnumerable<RegistrarUsuarioClienteViewModel> viewModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RegistrarUsuarioClienteViewModel> ConvertfromListToViewModel(IEnumerable<Usuario> original)
        {
            throw new NotImplementedException();
        }

        public RegistrarUsuarioClienteViewModel ConvertToViewModel(Usuario original)
        {
            throw new NotImplementedException();
        }
    }
}
