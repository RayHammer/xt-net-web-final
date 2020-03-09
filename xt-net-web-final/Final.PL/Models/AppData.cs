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
            RoleLogic = new RoleLogic(new RoleDao(), new UserRolesDao());
            ThreadPostLogic = new ThreadPostLogic(new ThreadPostDao());
        }

        public static IForumThreadLogic ForumThreadLogic
        {
            get; private set;
        }

        public static IRoleLogic RoleLogic
        {
            get; private set;
        }

        public static IThreadPostLogic ThreadPostLogic
        {
            get; private set;
        }

        public static IUserLogic UserLogic
        {
            get; private set;
        }

        public static string GetContentAuthorName(int? id)
        {
            string authorName = "Anonymous";
            if (id.HasValue)
            {
                var user = UserLogic.GetById(id.Value);
                if (user != null)
                {
                    authorName = UserLogic.GetById(id.Value).Username;
                }
            }
            return authorName;
        }
    }
}