using System.Collections.Generic;

namespace Final.DAL.Interfaces
{
    public interface IUserRolesDao
    {
        bool AddLink(int userId, int roleId);

        bool CheckLink(int userId, int roleId);

        IEnumerable<int> GetLinksFor(int userId);
    }
}