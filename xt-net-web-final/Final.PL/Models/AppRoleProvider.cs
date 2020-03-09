using Final.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Web.Security;

namespace Final.PL.Models
{
    public class AppRoleProvider : RoleProvider
    {
        private static IRoleLogic RoleLogic => AppData.RoleLogic;
        private static IUserLogic UserLogic => AppData.UserLogic;

        public override bool IsUserInRole(string username, string roleName)
        {
            int userId = UserLogic.GetByUsername(username).Id;
            int roleId = RoleLogic.GetByName(roleName).Id;
            return RoleLogic.IsUserInRole(userId, roleId);
        }

        public override string[] GetRolesForUser(string username)
        {
            var roleNames = new List<string>();
            int userId = UserLogic.GetByUsername(username).Id;
            foreach (var role in RoleLogic.GetRolesForUser(userId))
            {
                roleNames.Add(role.Name);
            }
            return roleNames.ToArray();
        }

        #region NOT_IMPLEMENTED

        public override string ApplicationName
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        #endregion NOT_IMPLEMENTED
    }
}