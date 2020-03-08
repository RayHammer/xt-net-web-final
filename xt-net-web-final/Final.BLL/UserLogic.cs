using Final.BLL.Interfaces;
using Final.DAL.Interfaces;
using Final.Entities;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Final.BLL
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserDao dao;

        public UserLogic(IUserDao dao)
        {
            this.dao = dao;
        }

        public User Add(User user, string password)
        {
            if (GetByUsername(user.Username) != null)
            {
                return null;
            }
            using (var md5 = MD5.Create())
            {
                user.PasswordHash = CreateHash(md5, password);
            }
            return dao.Add(user);
        }

        public bool CheckEntry(string username, string password)
        {
            User entry = GetByUsername(username);
            if (entry == null)
            {
                return false;
            }
            using (var md5 = MD5.Create())
            {
                if (entry.PasswordHash == CreateHash(md5, password))
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<User> GetAll()
        {
            return dao.GetAll();
        }

        public User GetById(int id)
        {
            return dao.GetById(id);
        }

        public User GetByUsername(string username)
        {
            return dao.GetByUsername(username);
        }

        private static string CreateHash(MD5 md5, string input)
        {
            byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            var sBuilder = new StringBuilder();
            for (var i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}