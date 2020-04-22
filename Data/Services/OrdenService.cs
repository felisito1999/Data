using Data.DbAccess;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class OrdenService : ISingleModelSystemService<Orden>
    {
        public Orden FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Orden orden)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                context.Ordenes.Add(orden);

                context.SaveChanges();
            }
        }

        public IEnumerable<Orden> ListAll()
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var ordenes = context.Ordenes.ToList();

                return ordenes;
            }
        }

        public IEnumerable<Orden> ListSortedByGivenCategoryId(int idCategory)
        {
            throw new NotImplementedException();
        }

        public void SoftDelete(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateSingleObject(Orden objectType)
        {
            throw new NotImplementedException();
        }
        public Orden FindLastOrden()
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var maxOrdenCodigo = context.Ordenes.ToList().Max(x => x.CodigoOrden);
                var orden = context.Ordenes.Find(maxOrdenCodigo);

                return orden;
            }
        }
        public Empleado SeleccionarEmpleadoMenorCantidadOrdenPendiente(int idSucursal)
        {

            var empleados = GetService.GetEmpleadoService().ListAll().Where(x => x.CodigoEstado == 3 & GetService.GetUsuarioService().FindById(x.CodigoUsuario).CodigoEstado == 10 & x.CodigoSucursal == idSucursal & x.CodigoEstado == 3);
            int iteracion = 0;
            int minOrdenes = 0;
            int minOrdenesCodigoEmpleado = 0;
            foreach (var item in empleados)
            {
                int CantidadOrdenes = GetService.GetOrdenService().ListAll().Where(x => x.CodigoEstado == 1024 & x.CodigoEmpleado == item.CodigoEmpleado & x.CodigoSucursal == item.CodigoSucursal).Count();

                if (iteracion == 0)
                {
                    minOrdenes = CantidadOrdenes;
                    minOrdenesCodigoEmpleado = item.CodigoEmpleado;
                    iteracion += 1;
                }
                else
                {
                    if (CantidadOrdenes < minOrdenes)
                    {
                        minOrdenes = CantidadOrdenes;
                        minOrdenesCodigoEmpleado = item.CodigoEmpleado;
                    }
                }
            }

            var minOrdenesEmpleado = GetService.GetEmpleadoService().FindById(minOrdenesCodigoEmpleado);
            return minOrdenesEmpleado;
        }
    }
}
