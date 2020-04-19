using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    interface IModelViewModelConverter<T,T1>
        where T : class
        where T1 : class
    {
        T ConvertFromViewModel(T1 viewModel);
        T1 ConvertToViewModel(T original);
        IEnumerable<T> ConvertListFromViewModel(IEnumerable<T1> viewModel);
        IEnumerable<T1> ConvertfromListToViewModel(IEnumerable<T> original);
    }
}
