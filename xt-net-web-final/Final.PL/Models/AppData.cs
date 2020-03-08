using Final.BLL;
using Final.BLL.Interfaces;
using Final.DAL;
using System.Web.Configuration;

namespace Final.PL.Models
{
    public static class AppData
    {
        static AppData()
        {
            DaoCommon.ConnectionString = WebConfigurationManager.
                ConnectionStrings["sqlDatabase"].ConnectionString;
            UserLogic = new UserLogic(new UserDao());
            ForumThreadLogic = new ForumThreadLogic(new ForumThreadDao());
        }

        public static IUserLogic UserLogic
        {
            get; private set;
        }

        public static IForumThreadLogic ForumThreadLogic
        {
            get; private set;
        }
    }
}