using Data.DbAccess;
using Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    class ClienteModelConverterService : IModelViewModelConverter<Cliente, ClienteViewModel>
    {
        public Cliente ConvertFromViewModel(ClienteViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> ConvertListFromViewModel(IEnumerable<ClienteViewModel> viewModelList)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClienteViewModel> ConvertfromListToViewModel(IEnumerable<Cliente> originalList)
        {
            throw new NotImplementedException();
        }

        public ClienteViewModel ConvertToViewModel(Cliente original)
        {
            throw new NotImplementedException();
        }
    }
}
