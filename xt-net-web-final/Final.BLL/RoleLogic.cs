using Final.DAL.Interfaces;
using Final.Entities;
using System;
using System.Collections.Generic;

namespace Final.BLL
{
    public class RoleLogic : Interfaces.IRoleLogic
    {
        private readonly IRoleDao dao;
        private readonly IUserRolesDao table;

        public RoleLogic(IRoleDao dao, IUserRolesDao table)
        {
            this.dao = dao;
            this.table = table;
        }

        public bool AddUserToRole(int userId, int roleId)
        {
            return !table.CheckLink(userId, roleId) &&
                table.AddLink(userId, roleId);
        }

        public IEnumerable<Role> GetAll()
        {
            return dao.GetAll();
        }

        public Role GetById(int id)
        {
            return dao.GetById(id);
        }

        public Role GetByName(string name)
        {
            return dao.GetByName(name);
        }

        public IEnumerable<Role> GetRolesForUser(int userId)
        {
            var roles = new List<Role>();
            foreach (var id in table.GetLinksFor(userId))
            {
                roles.Add(GetById(id));
            }
            return roles;
        }

        public bool IsUserInRole(int userId, int roleId)
        {
            return table.CheckLink(userId, roleId);
        }
    }
}