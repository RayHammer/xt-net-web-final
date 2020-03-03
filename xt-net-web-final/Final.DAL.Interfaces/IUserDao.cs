using Final.Entities;
using System.Collections.Generic;

namespace Final.DAL.Interfaces
{
    public interface IUserDao
    {
        User Add(User user);

        IEnumerable<User> GetAll();

        User GetByUsername(string username);
    }
}