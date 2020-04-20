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

        public void Insert(Orden objectType)
        {
            throw new NotImplementedException();
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
        public Empleado SeleccionarEmpleadoOrden()
        {
            var ordenesPendientes = ListAll().Where(x => x.CodigoEstado == 1024);
            List<Empleado> empleadosOrdenesPendientes = new List<Empleado>();
            List<OrdenEmpleado> ordenEmpleado 

            if(ordenesPendientes.Count() > 0)
            {
                foreach (var item in ordenesPendientes)
                {
                    empleadosOrdenesPendientes 
                }
            }
        }
    }
}
