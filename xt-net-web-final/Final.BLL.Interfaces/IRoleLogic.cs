using Final.Entities;
using System.Collections.Generic;

namespace Final.BLL.Interfaces
{
    public interface IRoleLogic
    {
        bool AddUserToRole(int userId, int roleId);

        IEnumerable<Role> GetAll();

        Role GetById(int id);

        Role GetByName(string name);

        IEnumerable<Role> GetRolesForUser(int userId);

        bool IsUserInRole(int userId, int roleId);
    }
}