using Final.Entities;
using System.Collections.Generic;

namespace Final.DAL.Interfaces
{
    public interface IUserDao
    {
        User Add(User user);

        bool Delete(int id);

        IEnumerable<User> GetAll();

        User GetById(int id);

        User GetByUsername(string username);

        User Update(int id, User user);
    }
}