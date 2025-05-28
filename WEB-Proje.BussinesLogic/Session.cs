using WEB_Proje.Domain.Entities.User;
using System.Web;
using WEB_Proje.Domain.Models;


namespace WEB_Proje.BussinesLogic {
    public class Session {
        public static UserDateLogin GetLoggedInUser(HttpContextBase context) {
            if(context == null) return null;

            var userInfo = context.Session["user"] as UserSessionInfo;
            if(userInfo == null) return null;

            return new UserDateLogin {
                Username = userInfo.Username
            };
        }

    }
}
