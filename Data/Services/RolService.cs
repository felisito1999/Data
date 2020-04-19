using Data.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class RolService : ISingleModelSystemService<Rol>
    {
        public Rol FindById(int id)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var rol = context.Roles.Find(id);

                return rol;
            }
        }

        public void Insert(Rol objectType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rol> ListAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rol> ListSortedByGivenCategoryId(int idCategory)
        {
            throw new NotImplementedException();
        }

        public void SoftDelete(int id)
        {
            throw new NotImplementedException();
        }
        public void UpdateSingleObject(Rol objectType)
        {
            throw new NotImplementedException();
        }
        public Rol FindRolByName(string role)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var rol = context.Roles.ToList().Where(x => x.NombreRol == role).SingleOrDefault();

                return rol;
            }
        }
        public List<string> GetAllRolesNames()
        {
            var roles = ListAll();
            List<string> rolesNames = new List<string>();
            foreach (var item in roles)
            {
                string roleName = item.NombreRol;
                rolesNames.Add(roleName);
            }
            return rolesNames;
        }
        public bool CheckExists(string roleName)
        {
            var rol = FindRolByName(roleName);
            if (rol != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
