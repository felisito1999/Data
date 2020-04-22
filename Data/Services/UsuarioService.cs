using Data.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class UsuarioService : ISingleModelSystemService<Usuario>
    {
        public Usuario FindById(int id)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var usuario = context.Usuarios.Find(id);

                return usuario;
            }
        }

        public void Insert(Usuario usuario)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                byte[] data = Encoding.ASCII.GetBytes(usuario.Clave);
                data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
                String hash = Encoding.ASCII.GetString(data);
                usuario.Clave = hash;
                usuario.CodigoUsuario = 0;
                context.Usuarios.Add(usuario);

                context.SaveChanges();
            }
        }
        public IEnumerable<Usuario> ListAll()
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var usuarios = context.Usuarios.ToList().Where(x => x.Borrado == false);
                return usuarios;
            }
        }

        public IEnumerable<Usuario> ListSortedByGivenCategoryId(int idRol)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var usuarios = ListAll().Where(x => x.CodigoRol == idRol);

                return usuarios;
            }
        }

        public void SoftDelete(int id)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var usuario = FindById(id);
                usuario.Borrado = true;

                context.SaveChanges();
            }
        }
        public void UpdateSingleObject(Usuario usuarioModificado)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var usuarioOriginal = FindById(usuarioModificado.CodigoUsuario);
                usuarioOriginal = usuarioModificado;

                context.SaveChanges();
            }
        }
        public bool CorrectLoginInfo(string username, string password)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                byte[] data = Encoding.ASCII.GetBytes(password);
                data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
                String hashPassword = Encoding.ASCII.GetString(data);
                var empleadoInactivo = GetService.GetEmpleadoService().CheckEmpleadoIsInactivo(username);
                var loginInfo = context.Usuarios.ToList().Where(x => (x.NombreUsuario == username | x.Correo == username) & x.Clave == hashPassword & x.Estados.NombreEstado == "Usuario activo").SingleOrDefault();

                if (loginInfo == null | empleadoInactivo == true)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public Usuario FindUserByUsername(string UserName)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var usuario = context.Usuarios.ToList().Where(x => x.NombreUsuario == UserName).SingleOrDefault();
                return usuario;
            }
        }
        public Usuario FindLastUsuario()
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                if (ListAll().Count() > 0)
                {
                    var usuario = context.Usuarios.ToList().FindLast(x => x.Borrado == false);
                    return usuario;
                }
                else
                {
                    throw new Exception();
                }
            }
        }
        public List<Usuario> GetUsersInRole(string rol)
        {
            var foundRole = GetService.GetRolService().FindRolByName(rol);

            var usuarios = ListSortedByGivenCategoryId(foundRole.CodigoRol);
            return (List<Usuario>)usuarios;
        }
        public List<string> UsersRoles(string roleName, string username)
        {
            var rol = GetService.GetRolService().FindRolByName(roleName);
            var user = FindUserByUsername(username);

            var userRoleMatch = ListAll().Where(x => x.CodigoRol == rol.CodigoRol & x.CodigoUsuario == user.CodigoUsuario).ToList();
            List<string> usersMatches = new List<string>();
            foreach (var item in userRoleMatch)
            {
                string userName = item.NombreUsuario;
                usersMatches.Add(userName);
            }
            return usersMatches;
        }
        public List<string> GetUserRoles(string username)
        {
            List<string> roles = new List<string>();
            var user = FindUserByUsername(username);
            var role = GetService.GetRolService().FindById(user.CodigoRol);

            roles.Add(role.NombreRol);

            return roles;
        }
        public bool CheckRole(string username, string roleName)
        {
            var user = FindUserByUsername(username);
            var rol = GetService.GetRolService().FindRolByName(roleName);


            if (user.CodigoRol == rol.CodigoRol)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Usuario GetUsuarioByEmpleadoId(int id)
        {
            using (var context = GetService.GetRestauranteEntityService())
            {
                var empleado = context.Empleados.Find(id);
                var usuario = context.Usuarios.Find(empleado.CodigoUsuario);

                return usuario;
            }
        }
    }
}
