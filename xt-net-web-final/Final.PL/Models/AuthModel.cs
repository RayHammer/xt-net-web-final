using Final.BLL;
using Final.BLL.Interfaces;
using Final.Entities;

namespace Final.PL.Models
{
    public static class AuthModel
    {
        private static readonly IUserLogic userLogic = AppData.UserLogic;

        public static bool Authorize(string username, string password)
        {
            return userLogic.CheckEntry(username, password);
        }

        public static bool Register(string username, string password)
        {
            User user = new User() {
                Username = username
            };
            return userLogic.Add(user, password) != null;
        }

        public static bool Validate(string username, string password)
        {
            User user = new User()
            {
                Username = username
            };
            return UserLogic.Validate(user, password);
        }
    }
}