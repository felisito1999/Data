using Data.DbAccess;
using Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class SucursalModelConverterService : IModelViewModelConverter<Sucursal, SucursalViewModel>
    {
        public IEnumerable<SucursalViewModel> ConvertfromListToViewModel(IEnumerable<Sucursal> original)
        {
            List<SucursalViewModel> viewModel = new List<SucursalViewModel>();
            foreach (var item in original)
            {
                SucursalViewModel model = new SucursalViewModel
                {
                    CodigoSucursal = item.CodigoSucursal,
                    NombreSucursal = item.NombreSucursal,
                    DireccionSucursal = item.DireccionSucursal,
                    Pais = GetService.GetPaisService().FindById(item.CodigoPais),
                    //Provincia = GetService.GetProvinciaService().FindById(item.CodigoProvincia)
                };

                viewModel.Add(model);
            }
            return viewModel;
        }

        public Sucursal ConvertFromViewModel(SucursalViewModel viewModel)
        {
            Sucursal original = new Sucursal
            {
                CodigoSucursal = viewModel.CodigoSucursal,
                NombreSucursal = viewModel.NombreSucursal,
                DireccionSucursal = viewModel.DireccionSucursal,
                CodigoPais = viewModel.Pais.CodigoPais,
                CodigoProvincia = viewModel.CodigoProvincia,
            };
            return original;
        }

        public IEnumerable<Sucursal> ConvertListFromViewModel(IEnumerable<SucursalViewModel> viewModel)
        {
            throw new NotImplementedException();
        }

        public SucursalViewModel ConvertToViewModel(Sucursal original)
        {
            throw new NotImplementedException();
        }
    }
}
