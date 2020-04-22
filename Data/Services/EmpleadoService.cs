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
                var usuario = GetService.GetUsuarioService().FindLastUsuario();
                var empleado = context.Empleados.Find(id);
                empleado.CodigoUsuario = usuario.CodigoUsuario;
                return empleado;
            }
        }

        public void Insert(Empleado empleado)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var lastUsuario = GetService.GetUsuarioService().FindLastUsuario();
                empleado.CodigoUsuario = lastUsuario.CodigoUsuario;
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
        public Empleado GetEmpleadoByUserName(string username)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var usuario = GetService.GetUsuarioService().FindUserByUsername(username);
                var empleado = context.Empleados.Where(x => x.CodigoUsuario == usuario.CodigoUsuario).SingleOrDefault();

                return empleado;
            }
        }
        public bool CheckEmpleadoIsInactivo(string username)
        {
            var empleado = GetEmpleadoByUserName(username);
            if (empleado != null)
            {
                if (empleado.CodigoEstado == 4)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
