using Final.Entities;
using System.Collections.Generic;

namespace Final.BLL.Interfaces
{
    public interface IUserLogic
    {
        User Add(User user, string password);

        bool CheckEntry(string username, string password);

        IEnumerable<User> GetAll();

        User GetById(int id);

        User GetByUsername(string username);
    }
}