using Data.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class EmpleadoService : ISingleModelSystemService<Empleado>
    {
        public Empleado FindById(int id)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var empleado = context.Empleados.Find(id);
                return empleado;
            }
        }

        public void Insert(Empleado empleado)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                context.Empleados.Add(empleado);
                context.SaveChanges();
            }
        }

        public IEnumerable<Empleado> ListAll()
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var empleados = context.Empleados.ToList().Where(x => x.Borrado == false);
                return empleados;
            }
        }

        public IEnumerable<Empleado> ListSortedByGivenCategoryId(int idCategory)
        {
            throw new NotImplementedException();
        }

        public void SoftDelete(int id)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var empleado = FindById(id);
                empleado.Borrado = true;
                UpdateSingleObject(empleado);
                context.SaveChanges();
            }
        }
        public void UpdateSingleObject(Empleado empleadoModificado)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var empleadoOriginal = FindById(empleadoModificado.CodigoEmpleado);
                empleadoOriginal = empleadoModificado;
                context.SaveChanges();
            }
        }
    }
}
