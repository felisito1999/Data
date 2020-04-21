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
            var ordenesPendientes = ListAll().Where(x => x.CodigoEstado == 1024 & x.CodigoSucursal == idSucursal);
            var empleadosOrdenesPendientes = GetService.GetEmpleadoService().ListAll().Where(x => x.CodigoSucursal == idSucursal);
            List<OrdenEmpleado> ordenesEmpleados = new List<OrdenEmpleado>();

            if(ordenesPendientes.Count() > 0)
            {
                foreach (var item in ordenesPendientes)
                {
                    var empleados = GetService.GetEmpleadoService().FindById(item.CodigoEmpleado);
                    if (ordenesEmpleados.Where(x => x.CodigoEmpleado == item.CodigoEmpleado & empleados.CodigoSucursal == idSucursal).Count() == 0)
                    {
                        OrdenEmpleado empleado = new OrdenEmpleado
                        {
                            CodigoEmpleado = item.CodigoEmpleado,
                            CantidadOrdenes = 1
                        };
                        ordenesEmpleados.Add(empleado);
                    }
                    else if (empleados.CodigoSucursal == idSucursal)
                    {
                        foreach (var ordenEmpleadoItem in ordenesEmpleados.Where(x => x.CodigoEmpleado == item.CodigoEmpleado & empleados.CodigoSucursal == idSucursal))
                        {
                            ordenEmpleadoItem.CantidadOrdenes =+ 1;
                        }
                    }
                }
                int maxOrden = 0;
                int maxOrdenClienteId = 0;
                int iterator = 0;
                foreach (var item in ordenesEmpleados)
                {
                    if (item.CantidadOrdenes > maxOrden & iterator == 0)
                    {
                        maxOrden = item.CantidadOrdenes;
                        maxOrdenClienteId = item.CodigoEmpleado;
                    }
                    else if (item.CantidadOrdenes < maxOrden & iterator > 0)
                    {
                        maxOrden = item.CantidadOrdenes;
                        maxOrdenClienteId = item.CodigoEmpleado;
                    }
                    iterator += 1; 
                }
                //foreach (var item in ordenesPendientes)
                //{
                //    if(ordenesPendientes.Where(listItem => listItem.CodigoCliente == item.CodigoCliente).Count() == 0)
                //    {
                //        OrdenEmpleado empleado = new OrdenEmpleado
                //        {
                //            CodigoEmpleado = item.CodigoEmpleado,
                //            CantidadOrdenes = 1
                //        };
                //        ordenEmpleado.Add(empleado);
                //    }
                //    else
                //    {
                //        foreach( var ordenEmpleadoItem in ordenEmpleado.Where(x => x.CodigoEmpleado == item.CodigoEmpleado))
                //        {
                //            ordenEmpleadoItem.CodigoE += 1;
                //        }
                //    }
                //}
                var empleadoAsignar = GetService.GetEmpleadoService().FindById(maxOrdenClienteId);

                return empleadoAsignar;
            }
            else
            {
                var empleadoAsignar = GetService.GetEmpleadoService().ListAll().FirstOrDefault();

                return empleadoAsignar;
            }
        }
    }
}
