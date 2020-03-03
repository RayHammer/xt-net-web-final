using Final.BLL.Interfaces;
using Final.Entities;
using System.Security.Cryptography;
using System.Text;

namespace Final.PL.Models
{
    public static class AuthModel
    {
        private static IUserLogic userLogic = AppData.UserLogic;

        public static bool Authorize(string username, string password)
        {
            User entry = userLogic.GetByUsername(username);
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

        public static bool Register(string username, string password)
        {
            if (userLogic.GetByUsername(username) != null)
            {
                return false;
            }
            User user = new User() {
                Username = username
            };
            using (var md5 = MD5.Create())
            {
                user.PasswordHash = CreateHash(md5, password);
            }
            userLogic.Add(user);
            return true;
        }

        public static string CreateHash(MD5 md5, string input)
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