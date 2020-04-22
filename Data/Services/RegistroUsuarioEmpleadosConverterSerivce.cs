using Data.DbAccess;
using Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class RegistroUsuarioEmpleadosConverterSerivce : IModelViewModelConverter<Usuario, RegistrarUsuarioEmpleadoViewModel>
    {
        public IEnumerable<RegistrarUsuarioEmpleadoViewModel> ConvertfromListToViewModel(IEnumerable<Usuario> original)
        {
            throw new NotImplementedException();
        }

        public Usuario ConvertFromViewModel(RegistrarUsuarioEmpleadoViewModel viewModel)
        {
            Usuario usuario = new Usuario
            {
                NombreUsuario = viewModel.NombreUsuario,
                Clave = viewModel.Clave,
                Correo = viewModel.Correo,
                CodigoRol = 3,
                CodigoEstado = 10,
                Borrado = false
            };
            return usuario;
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
