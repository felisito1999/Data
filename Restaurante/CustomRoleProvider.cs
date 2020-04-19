using Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Restaurante
{
    public class CustomRoleProvider : RoleProvider
    {
        public override string ApplicationName
        {
            get
            {
                return "RestauranteV4";
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            var users = GetService.GetUsuarioService().UsersRoles(roleName, usernameToMatch);

            return users.ToArray();
        }

        public override string[] GetAllRoles()
        {
            var roles = GetService.GetRolService().GetAllRolesNames();

            return roles.ToArray();
        }

        public override string[] GetRolesForUser(string username)
        {
            var roles = GetService.GetUsuarioService().GetUserRoles(username);

            return roles.ToArray();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            List<string> usuarios = new List<string>();
            var users = GetService.GetUsuarioService().GetUsersInRole(roleName);

            foreach (var item in users)
            {
                string usuario = item.NombreUsuario;
                usuarios.Add(usuario);
            }
            return usuarios.ToArray();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            var check = GetService.GetUsuarioService().CheckRole(username, roleName);

            return check;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            var check = GetService.GetRolService().CheckExists(roleName);

            return check;
        }
    }
}