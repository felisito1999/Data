using Data.DbAccess;
using Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class UsuarioLoginModelConverterService : IModelViewModelConverter<Usuario, UsuarioLoginViewModel>
    {
        public IEnumerable<UsuarioLoginViewModel> ConvertfromListToViewModel(IEnumerable<Usuario> original)
        {
            throw new NotImplementedException();
        }

        public Usuario ConvertFromViewModel(UsuarioLoginViewModel viewModel)
        {
            Usuario usuario = new Usuario
            {
                NombreUsuario = viewModel.NombreUsuario,
                Clave = viewModel.Clave
            };
            return usuario;
        }

        public IEnumerable<Usuario> ConvertListFromViewModel(IEnumerable<UsuarioLoginViewModel> viewModel)
        {
            throw new NotImplementedException();
        }

        public UsuarioLoginViewModel ConvertToViewModel(Usuario original)
        {
            throw new NotImplementedException();
        }
    }
}
