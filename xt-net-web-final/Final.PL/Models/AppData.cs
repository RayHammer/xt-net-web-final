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
        }

        public static IUserLogic UserLogic
        {
            get; private set;
        }
    }
}