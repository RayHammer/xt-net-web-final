using Final.BLL.Interfaces;
using Final.DAL.Interfaces;
using Final.Entities;
using System.Collections.Generic;

namespace Final.BLL
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserDao userDao;

        public UserLogic(IUserDao userDao)
        {
            this.userDao = userDao;
        }

        public User Add(User user)
        {
            // check if the entry's valid

            return userDao.Add(user);
        }

        public IEnumerable<User> GetAll()
        {
            return userDao.GetAll();
        }
    }
}