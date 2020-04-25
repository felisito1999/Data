using Data.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public static class GetService
    {
        public static RestauranteEntities GetRestauranteEntityService()
        {
            return new RestauranteEntities();
        }
        public static UsuarioService GetUsuarioService()
        {
            return new UsuarioService();
        }
        public static ClienteService GetClienteService()
        {
            return new ClienteService();
        }
        public static EmpleadoService GetEmpleadoService()
        {
            return new EmpleadoService();
        }
        public static SucursalService GetSucursalService()
        {
            return new SucursalService();
        }
        public static PaisService GetPaisService()
        {
            return new PaisService();
        }
        public static ProvinciaService GetProvinciaService()
        {
            return new ProvinciaService();
        }
        public static EstadoService GetEstadoService()
        {
            return new EstadoService();
        }
        public static RegistroClienteModelConverterService GetRegistroClienteConverterService()
        {
            return new RegistroClienteModelConverterService();
        }
        public static RolService GetRolService()
        {
            return new RolService();
        }
        public static RegistroUsuarioModelClienteConverterService GetRegistroUsuarioClienteConverterService()
        {
            return new RegistroUsuarioModelClienteConverterService();
        }
        public static SexoService GetSexoService()
        {
            return new SexoService();
        }
        public static SucursalModelConverterService GetSucursalModelConverterService()
        {
            return new SucursalModelConverterService();
        }
        public static ProductoMenuService GetProductoMenuService()
        {
            return new ProductoMenuService();
        }
        public static ProductoMenuModelConverterService GetProductoMenuModelConverterService()
        {
            return new ProductoMenuModelConverterService();
        }
        public static MenuService GetMenuService()
        {
            return new MenuService();
        }
        public static ProductoMenuListModelConverterService GetProductoMenuListModelConverter()
        {
            return new ProductoMenuListModelConverterService();
        }
        public static ProductoService GetProductoService()
        {
            return new ProductoService();
        }
        public static UsuarioLoginModelConverterService GetUsuarioLoginModelConverterService()
        {
            return new UsuarioLoginModelConverterService();
        }
        //public static ImagenProductoService GetImagenProductoService()
        //{
        //    return new ImagenProductoService();
        //}
        public static ProductoModelConverterService GetProductoModelConverterService()
        {
            return new ProductoModelConverterService();
        }
        public static OrdenService GetOrdenService()
        {
            return new OrdenService();
        }
        public static OrdenDetalleService GetOrdenDetalleService()
        {
            return new OrdenDetalleService();
        }
        public static ImagenProductoViewModelConverterService GetImagenProductoViewModelService()
        {
            return new ImagenProductoViewModelConverterService();
        }
        public static ImagenService GetImagenService()
        {
            return new ImagenService();
        }
        public static CategoriaProductoService GetCategoriaProductoService()
        {
            return new CategoriaProductoService();
        }
        public static ProductoProductoMenuModelConverterService GetProductoProductoMenuModelConverterService()
        {
            return new ProductoProductoMenuModelConverterService();
        }
        public static ImagenViewModelConverterService GetImagenViewModelConverterService()
        {
            return new ImagenViewModelConverterService();
        }
        public static RegistroUsuarioEmpleadosConverterSerivce GetRegistroUsuarioEmpleadosConverterSerivce()
        {
            return new RegistroUsuarioEmpleadosConverterSerivce();
        }
        public static RegistroEmpleadoModelConverterService GetRegistroEmpleadoModelConverterService()
        {
            return new RegistroEmpleadoModelConverterService();
        }
        public static EmpleadoModelConverterService GetEmpleadoConverterService()
        {
            return new EmpleadoModelConverterService();
        }
        public static OrdenOrdenEmpleadoModelConverterService GetOrdenOrdenEmpleadoModelConverterService()
        {
            return new OrdenOrdenEmpleadoModelConverterService();
        }
        public static OrdenOrdenClienteModelConverterService GetOrdenOrdenClienteModelConverterService()
        {
            return new OrdenOrdenClienteModelConverterService();
        }
    }
}
