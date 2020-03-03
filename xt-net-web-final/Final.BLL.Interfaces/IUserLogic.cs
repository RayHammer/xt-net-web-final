using Final.Entities;
using System.Collections.Generic;

namespace Final.BLL.Interfaces
{
    public interface IUserLogic
    {
        User Add(User user);

        IEnumerable<User> GetAll();

        User GetByUsername(string username);
    }
}